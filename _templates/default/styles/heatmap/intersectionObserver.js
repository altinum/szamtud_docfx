import { fetchData } from "./main.js";

let timingData = {};

export const observer = new IntersectionObserver(
  (entries) => {
    entries.forEach((entry) => {
      const element = entry.target;
      const elementId = element.id;

      if (entry.isIntersecting) {
        if (!timingData[elementId]) {
          timingData[elementId] = {
            startTime: performance.now() / 1000,
            currentTime: null,
          };
        }
      } else {
        if (timingData[elementId] && timingData[elementId].startTime) {
          timingData[elementId].currentTime = performance.now() / 1000;
          stopClock(elementId);
        }
      }
    });
  },
  { threshold: 0.5 }
);

async function stopClock(elementId) {
  const { startTime, currentTime } = timingData[elementId];
  const duration = parseFloat(currentTime - startTime);

  try {
    await fetchData(`heatmap/timingInfo/${elementId}`, "PUT", duration);
    console.log(
      `Section ${elementId} viewed for ${currentTime - startTime} seconds`
    );
  } catch (error) {
    console.error(`Failed to update timing for section ${elementId}:`, error);
  } finally {
    //töröljük az adatokat az objektumból, hogy új mérésekhez frissítsük
    delete timingData[elementId];
  }
}
