console.log("heatmap.js is on");

let startTime;
let currentTime;
let mapSections = [];

class TimingInfo {
  totalVisibleTime = 0;
  lastVisibleTime = null;
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
  [...targetElements].forEach((element, index) => {
    mapSections.push({
      id: index,
      element: element,
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

        if (matchingSection.timingInfo.lastVisibleTime == null) {
          addMapSection(
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
}

function stopClock(section) {
  if (currentTime && startTime) {
    section.timingInfo.totalVisibleTime += currentTime - startTime;
    startTime = null;
    currentTime = null;
  }
  console.log(section.timingInfo);
}
