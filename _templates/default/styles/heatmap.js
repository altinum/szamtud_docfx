console.log("heatmap.js is on");

let startTime;
let currentTime;
let mapSections = [];

class TimingInfo {
  totalVisibleTime = 0;
  lastVisibleTime = null;
  y = 0;
  height = 0;
}

window.onload = () => {
  //heatmap element hozzáadása a dokumentumhoz
  var divBeforeHeatmap = document.getElementsByClassName("col-md-10");
  divBeforeHeatmap[0].insertAdjacentHTML(
    "afterbegin",
    '<div id="heatmap"></div>'
  );

  //heatmapSection osztály hozzáadása a tananyag részekhez
  const heatmapSections = document.querySelectorAll(
    "p, ul, table, iframe, pre"
  );
  heatmapSections.forEach((heatmapSection) => {
    heatmapSection.classList.add("heatmap-section");
  });

  //mapSection objektumok létrehozása id-val, html elementtel és timingInfo-val
  const targetElements = document.querySelectorAll(".heatmap-section");
  targetElements.forEach((element, index) => {
    mapSections.push({
      id: index,
      element: element,
      sectionInHeatmap: null,
      timingInfo: new TimingInfo(),
    });
  });

  mapSections.forEach((section) => observer.observe(section.element));
};

const observer = new IntersectionObserver(
  (entries) => {
    entries.forEach((entry) => {
      //a látszódó mapSection kiválasztása
      let matchingSection = mapSections.find(
        (section) => section.element === entry.target
      );

      if (entry.isIntersecting) {
        if (!startTime) {
          startTime = performance.now() / 1000;
        }

        matchingSection.timingInfo.y = entry.target.offsetTop;
        matchingSection.timingInfo.height = entry.target.offsetHeight;

        //ha még nem látszódott ez az element, akkor a heatmapben létrehozok neki egy div-et
        if (matchingSection.timingInfo.lastVisibleTime == null) {
          matchingSection.sectionInHeatMap = addMapSection(
            matchingSection.timingInfo.y,
            matchingSection.timingInfo.height
          );
        }

        matchingSection.timingInfo.lastVisibleTime = startTime;
      } else {
        currentTime = performance.now() / 1000;
        stopClock(matchingSection);
      }
    });
  },
  { threshold: 0.1 }
);

function addMapSection(y, height) {
  let heatmap = document.getElementById("heatmap");
  let section = document.createElement("div");
  section.classList.add("map-section");

  section.style.top = y - heatmap.offsetTop + "px";
  section.style.height = height + "px";

  heatmap.appendChild(section);
  return section;
}

function stopClock(section) {
  if (currentTime && startTime) {
    section.timingInfo.totalVisibleTime += currentTime - startTime;
    startTime = null;
    currentTime = null;
  }
  updateSectionColor(
    section.sectionInHeatMap,
    section.timingInfo.totalVisibleTime
  );
  console.log(section.timingInfo);
}

function updateSectionColor(section, time) {
  //az elemek közül a maximális és minimális látszódási idő lekérése
  const minTime = Math.min(
    ...mapSections.map((section) => section.timingInfo.totalVisibleTime)
  );
  const maxTime = Math.max(
    ...mapSections.map((section) => section.timingInfo.totalVisibleTime)
  );

  //skálázás 0-1 közé
  const normalizedTime = Math.min(
    Math.max((time - minTime) / (maxTime - minTime), 0),
    1
  );

  //hőtérkép színek beállítása
  const color = getHeatmapColor(normalizedTime);
  section.style.backgroundColor = color;
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
