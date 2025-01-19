import { fetchData, getSite, selectRelevantSections } from "./main.js";
import { heatmapPrecedingClass } from "./config.js";

export let site = {};

export async function displayHeatmap() {
  //annak a megkeresése, hogy melyik oldalon vagyunk
  site = await getSite();

  createHeatmap();
  await addMapSections();
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

  const storedSections = await fetchData(`heatmap/sections/${site.siteId}`);
  let domElements = await selectRelevantSections();

  storedSections.forEach((section) => {
    const el = [...domElements].find(
      (el) => el.outerHTML === section.htmlElement
    );

    let mapElement = document.createElement("div");
    mapElement.className = `map-section`;
    mapElement.id = section.sectionId;
    mapElement.style.top = el.closest("table")
      ? `${el.offsetTop + el.offsetParent.offsetTop}px`
      : `${el.offsetTop}px`;
    mapElement.style.height = `${el.offsetHeight}px`;
    heatmap.appendChild(mapElement);
    if (el) {
      //ha megtaláltuk, akkor eltávolítjuk a megtalált elemet a listából, hogy gyorsabban menjen a keresés
      domElements = [...domElements].filter((e) => e !== el);
    }
  });
}

async function colorSections() {
  const visibilityInfos = await fetchData(
    `heatmap/visibilityInfos/${site.siteId}`
  );

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
