import { applicationUrl } from "./main.js";

let startTime;
let currentTime;

export const observer = new IntersectionObserver(
  (entries) => {
    entries.forEach((entry) => {
      let element = entry.target;
      if (entry.isIntersecting) {
        if (!startTime) {
          startTime = performance.now() / 1000;
        }
      } else {
        currentTime = performance.now() / 1000;
        const elementId = element.id;
        stopClock(elementId);
      }
    });
  },
  { threshold: 0.5 }
);

function stopClock(sectionId) {
  if (currentTime) {
    fetch(`${applicationUrl}heatmap/timingInfo/${sectionId}`, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: parseFloat(currentTime - startTime),
    });

    startTime = null;
    currentTime = null;
  }
}
