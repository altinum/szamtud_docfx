import {
  createHeatmap,
  addMapSections,
  colorSections,
} from "./displayHeatmap.js";
import { manageHtmlChange } from "./manageHtmlChange.js";
import { observer } from "./intersectionObserver.js";

export const applicationUrl = "http://localhost:5215/";
const observedRegion = ".col-md-10";

window.onload = async () => {
  //heatmap megjelenítés feltétele, hogy a heatmap paraméter értéke true legyen
  const urlParams = new URLSearchParams(window.location.search);
  if (urlParams.get("heatmap") == "true") {
    //heatmap létrehozása
    createHeatmap();
    //div létrehozása a hőtérképben minden sectionnek
    await addMapSections();
    //minden section szinezése
    await colorSections();
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
  const response = await fetch(`${applicationUrl}heatmap/types`);
  const elementTypes = await response.json();
  const typeNames = elementTypes.map((type) => type.typeName).join(",");

  //releváns element típusok kiválasztása csak a html-nek abból a részéből, amit meg kívánunk figyelni
  //az observedRegion a script elején módosítható a kód újrafelhasználhatósága érdekében
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
