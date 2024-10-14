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
      let matchingSection = mapSections.find(
        (section) => section.element === entry.target
      );

      if (entry.isIntersecting) {
        if (!startTime) {
          startTime = performance.now() / 1000;
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

function stopClock(section) {
  if (currentTime && startTime) {
    section.timingInfo.totalVisibleTime += currentTime - startTime;
    startTime = null;
    currentTime = null;
  }
  console.log(section.timingInfo);
}
