import { displayHeatmap } from "./displayHeatmap.js";
import { manageHtmlChange } from "./manageHtmlChange.js";
import { observer, stopClock } from "./intersectionObserver.js";
import { applicationUrl, observedRegion } from "./config.js";

window.onload = async () => {
  //heatmap megjelenítés feltétele, hogy a heatmap paraméter értéke true legyen
  const urlParams = new URLSearchParams(window.location.search);
  if (urlParams.get("heatmap") == "true") {
    await displayHeatmap();
    return;
  }

  //ha a heatmap paraméter értéke nem true, akkor méri a nézettséget
  const targetElements = await selectRelevantSections();

  //az adatbázisban bizonyos dolgokat csak akkor szeretnék frissíteni,
  //ha valami változott az oldal html-jében az előző megnyitás óta
  await manageHtmlChange(targetElements);

  //az oldal előző bezárásakor mért idők lezárása
  const closingTime = localStorage.getItem("closingTime");

  localStorage.removeItem("closingTime");
  for (const recording of Object.entries(localStorage)) {
    stopClock(recording[0], closingTime);
  }

  setTimeout(() => {
    localStorage.setItem("closingTime", performance.now() / 1000);
  }, 1000);

  targetElements.forEach((element) => observer.observe(element));
};

export async function selectRelevantSections() {
  //megfigyelni kívánt elemtípusok lekérése az adatbázisból
  const elementTypes = await fetchData(`heatmap/types`);
  const typeNames = elementTypes.map((type) => type.typeName).join(",");

  //az observedRegion a configban módosítható a kód újrafelhasználhatósága érdekében
  let heatmapSections = document
    .querySelector(observedRegion)
    .querySelectorAll(typeNames);

  //csak azokat az elemek kellenek, amelyek nincsenek másik kiválasztott elemben
  //pl.: a tr-en belül egy p-t nem figyel meg kétszer, elég a külső elemet figyelni
  heatmapSections = Array.from(heatmapSections).filter((element) => {
    const parentDiv = element.closest("div");
    //specifikusan a hidden iframe videókat nem kell kiválasztani
    if (parentDiv && parentDiv.classList.contains("hidden")) {
      return false;
    }
    return !Array.from(heatmapSections).some(
      (parent) => parent !== element && parent.contains(element)
    );
  });

  //heatmapSection osztálynév hozzáadása a tananyag részekhez
  heatmapSections.forEach((heatmapSection) => {
    heatmapSection.classList.add("heatmap-section");
  });
  return heatmapSections;
}

//helpers
export async function fetchData(endpoint, method = "GET", body = null) {
  const options = {
    method,
    headers: {
      "Content-Type": "application/json",
    },
  };

  if (body) {
    options.body = JSON.stringify(body);
  }

  const response = await fetch(`${applicationUrl}${endpoint}`, options);
  if (!response.ok) {
    throw new Error(`HTTP error! status: ${response.status}`);
  }

  const contentType = response.headers.get("content-type");
  if (contentType && contentType.includes("application/json")) {
    return response.json();
  } else {
    return { status: "ok" };
  }
}

export async function getSite() {
  const sites = await fetchData("heatmap/sites");
  for (const site of sites) {
    if (
      site.siteUrl === String(window.location.origin + window.location.pathname)
    )
      return site;
  }
}
