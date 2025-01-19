import { fetchData } from "./main.js";

let timingRecordings = {};

export const observer = new IntersectionObserver(
  (entries) => {
    entries.forEach((entry) => {
      const element = entry.target;
      const elementId = element.id;

      if (entry.isIntersecting) {
        if (!timingRecordings[elementId]) {
          timingRecordings[elementId] = {
            startTime: performance.now() / 1000,
          };
          //timingData rögzítése localStorage-ban
          localStorage.setItem(
            elementId,
            JSON.stringify(timingRecordings[elementId])
          );
        }
      } else {
        if (
          timingRecordings[elementId] &&
          timingRecordings[elementId].startTime
        ) {
          const currentTime = performance.now() / 1000;
          stopClock(elementId, currentTime);
        }
      }
    });
  },
  { threshold: 0.5 }
);

export async function stopClock(elementId, currentTime) {
  const recording = JSON.parse(localStorage.getItem(elementId));
  const duration = parseFloat(currentTime - recording.startTime);

  try {
    await fetchData(`heatmap/timingInfo/${elementId}`, "PUT", duration);
  } catch (error) {
    console.error(`Failed to update timing for section ${elementId}:`, error);
  } finally {
    //töröljük az adatokat az objektumból és a localStorage-ból, hogy új mérésekhez frissítsük
    delete timingRecordings[elementId];
    localStorage.removeItem(elementId);
  }
}
