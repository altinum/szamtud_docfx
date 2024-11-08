import { displayHeatmap } from "./displayHeatmap.js";
import { manageHtmlChange } from "./manageHtmlChange.js";
import { observer } from "./intersectionObserver.js";
import { applicationUrl, observedRegion } from "./config.js";

window.onload = async () => {
  //heatmap megjelenítés feltétele, hogy a heatmap paraméter értéke true legyen
  const urlParams = new URLSearchParams(window.location.search);
  if (urlParams.get("heatmap") == "true") {
    await displayHeatmap();
    return;
  }

  //ha a heatmap paraméter értéke nem true, akkor méri a nézettséget
  await selectRelevantSections();
  const targetElements = document.querySelectorAll(".heatmap-section");
  //az adatbázisban bizonyos dolgokat csak akkor szeretnék frissíteni,
  //ha valami változott az oldal html-jében az előző megnyitás óta
  await manageHtmlChange(targetElements);
  targetElements.forEach((element) => observer.observe(element));
};

async function selectRelevantSections() {
  //megfigyelni kívánt elemtípusok lekérése az adatbázisból
  const elementTypes = await fetchData(`heatmap/types`);
  const typeNames = elementTypes.map((type) => type.typeName).join(",");

  //releváns element típusok kiválasztása csak a html-nek abból a részéből, amit meg kívánunk figyelni
  //az observedRegion a configban módosítható a kód újrafelhasználhatósága érdekében
  let heatmapSections = document
    .querySelector(observedRegion)
    .querySelectorAll(typeNames);

  //szűrés, hogy csak azokat az elemeket tartsuk meg, amelyek nincsenek másik kiválasztott elemben
  //pl.: a tr-en belül egy p-t ne figyeljünk meg kétszer, elég a külső elementet figyelni
  //specifikusan a hidden iframe videókat nem kell kiválasztani
  heatmapSections = Array.from(heatmapSections).filter((element) => {
    const parentDiv = element.closest("div");
    if (parentDiv && parentDiv.classList.contains("hidden")) {
      return false;
    }
    return !Array.from(heatmapSections).some(
      (parent) => parent !== element && parent.contains(element)
    );
  });

  //heatmapSection osztálynév hozzáadása a tananyag részekhez a későbbi könnyebben kezelhetőség érdekében
  heatmapSections.forEach((heatmapSection) => {
    heatmapSection.classList.add("heatmap-section");
  });
}

//segítő függvény az api hívásokhoz
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

  //ha van tartalom a válaszban, akkor parse-oljuk JSON-ként
  const contentType = response.headers.get("content-type");
  if (contentType && contentType.includes("application/json")) {
    return response.json();
  } else {
    //ha nincs JSON, csak az OK státuszt jelöljük visszatérési értékként
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
