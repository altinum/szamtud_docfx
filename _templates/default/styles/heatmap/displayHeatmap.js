import { fetchData, getSite } from "./main.js";
import { heatmapPrecedingClass } from "./config.js";

export let site = {};

export async function displayHeatmap() {
  //annak a megkeresése, hogy melyik oldalon vagyunk
  site = await getSite();
  //heatmap létrehozása
  createHeatmap();
  //div létrehozása a hőtérképben minden sectionnek
  await addMapSections();
  //minden section szinezése
  await colorSections();
}

function createHeatmap() {
  //heatmap element hozzáadása a dokumentumhoz
  var divBeforeHeatmap = document.getElementsByClassName(heatmapPrecedingClass);
  divBeforeHeatmap[0].insertAdjacentHTML(
    "afterbegin",
    '<div id="heatmap"></div>'
  );
}

async function addMapSections() {
  const heatmap = document.getElementById("heatmap");
  if (!heatmap || !site.siteId) return;

  const positions = await fetchData(`heatmap/positions/${site.siteId}`);
  for (let position of positions) {
    let section = document.createElement("div");
    section.className = `map-section`;
    section.id = position.sectionId;
    section.style.top = `${position.y - heatmap.offsetTop}px`;
    section.style.height = `${position.height}px`;
    heatmap.appendChild(section);
  }
}

async function colorSections() {
  //összes visibilityInfo lekérése
  const visibilityInfos = await fetchData(
    `heatmap/visibilityInfos/${site.siteId}`
  );

  //az elemek közül a maximális és minimális látszódási idő lekérése
  const [minTime, maxTime] = getMinMaxTime(
    visibilityInfos.map((info) => parseFloat(info.totalVisibleTime))
  );

  visibilityInfos.forEach((visibilityInfo) => {
    //skálázás 0-1 közé
    const normalizedTime = Math.min(
      Math.max(
        (visibilityInfo.totalVisibleTime - minTime) / (maxTime - minTime),
        0
      ),
      1
    );

    //hőtérkép színek beállítása
    const color = getHeatmapColor(normalizedTime);
    const section = document.getElementById(visibilityInfo.sectionId);
    section.style.backgroundColor = color;
  });
}

function getMinMaxTime(times) {
  return [Math.min(...times), Math.max(...times)];
}

function getHeatmapColor(value) {
  const r = value < 0.5 ? 0 : Math.round(255 * (value - 0.5) * 2);
  const g =
    value < 0.5
      ? Math.round(255 * value * 2)
      : Math.round(255 * (1 - value) * 2);
  const b = value < 0.5 ? Math.round(255 * (1 - value * 2)) : 0;

  return `rgb(${r}, ${g}, ${b})`;
}
