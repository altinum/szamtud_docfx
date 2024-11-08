import { applicationUrl } from "./config.js";

let site = {};

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

async function getSite() {
  const response = await fetch(`${applicationUrl}heatmap/sites`);
  const sites = await response.json();
  for (const site of sites) {
    if (
      site.siteUrl === String(window.location.origin + window.location.pathname)
    )
      return site;
  }
}

function createHeatmap() {
  //heatmap element hozzáadása a dokumentumhoz
  var divBeforeHeatmap = document.getElementsByClassName("col-md-10");
  divBeforeHeatmap[0].insertAdjacentHTML(
    "afterbegin",
    '<div id="heatmap"></div>'
  );
}

async function addMapSections() {
  let heatmap = document.getElementById("heatmap");

  const response = await fetch(
    `${applicationUrl}heatmap/positions/${site.siteId}`
  );
  let positions = await response.json();

  for (let position of positions) {
    let section = document.createElement("div");
    section.classList.add(`map-section`);
    section.id = position.sectionId;
    section.style.top = position.y - heatmap.offsetTop + "px";
    section.style.height = position.height + "px";
    heatmap.appendChild(section);
  }
}

async function colorSections() {
  //összes visibilityInfo lekérése
  let response = await fetch(
    `${applicationUrl}heatmap/visibilityInfos/${site.siteId}`
  );
  let visibilityInfos = await response.json();

  //az elemek közül a maximális és minimális látszódási idő lekérése
  const minTime = Math.min(
    ...visibilityInfos.map((visibilityInfo) =>
      parseFloat(visibilityInfo.totalVisibleTime)
    )
  );
  const maxTime = Math.max(
    ...visibilityInfos.map((visibilityInfo) => visibilityInfo.totalVisibleTime)
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

function getHeatmapColor(value) {
  const r = value < 0.5 ? 0 : Math.round(255 * (value - 0.5) * 2);
  const g =
    value < 0.5
      ? Math.round(255 * value * 2)
      : Math.round(255 * (1 - value) * 2);
  const b = value < 0.5 ? Math.round(255 * (1 - value * 2)) : 0;

  return `rgb(${r}, ${g}, ${b})`;
}
