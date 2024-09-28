
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

//Intersection Observer API for automatic toggling
const observer = new IntersectionObserver((entries) => {
  entries.forEach(entry => {
    entry.target.style.backgroundColor = entry.isIntersecting ? 'red' : 'green';
  });
}, { threshold: 0.1 });

const targetElement = document.getElementById('target-element');
observer.observe(targetElement);

