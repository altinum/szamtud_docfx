
console.log("heatmap.js is working");

// Function to check if an element is visible on screen
function isVisible(element) {
  const rect = element.getBoundingClientRect();
  return (
    rect.top >= 0 &&
    rect.left >= 0 &&
    rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) &&
    rect.right <= (window.innerWidth || document.documentElement.clientWidth)
  );
}

// Function to toggle background color based on visibility
function toggleBackgroundColor() {
  const targetElement = document.getElementById('target-element');
  
  const isVisibleNow = isVisible(targetElement);
  
  targetElement.style.backgroundColor = isVisibleNow ? 'red' : 'green';
}

let startTime;
let currentTime;

const timingInfo = {
  totalVisibleTime: 0,
  lastVisibleTime: null
};

const observer = new IntersectionObserver((entries) => {
  entries.forEach((entry) => {
    if (entry.isIntersecting) {
      if (!startTime) {
        startTime = performance.now()/1000;
      }
      
      timingInfo.lastVisibleTime = time;
    } else {
      currentTime = performance.now()/1000;
      stopClock();
    }
  });
}, { threshold: 0.1 });


function stopClock() {
  if (currentTime && startTime) {
    timingInfo.totalVisibleTime += (currentTime - startTime);
    startTime = null;
    currentTime = null;
  }
}

const targetElement = document.getElementById('a-számonkérések-időpontjai');
observer.observe(targetElement);

