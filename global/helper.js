//Movies
    if (element.tagName === 'A') {
 
        if (endsWithAny(['.webm', '.mkv', '.ogv', '.ogg', '.avi', '.mp4', '.m4v'], element.href)) {
            //alert(element.href);
            try {
 
                if (element.nextElementSibling && element.nextElementSibling.classList.contains("innerVideoContainer")) return false;
 
                var t = document.getElementById("inlineVideo_template").innerHTML;
                let elem = document.createElement("div");
                elem.classList.add("innerVideoContainer");
                elem.innerHTML = t;
                elem.appendAfter(element);
                console.log(elem);
                elem.firstElementChild.src = element.href;
                elem.lastElementChild.addEventListener("click", (e) => {
                    e.target.parentNode.parentNode.removeChild(e.target.parentNode);
                    //console.log(e.target.parentNode);
                });
 
                elem.firstElementChild.addEventListener("play", (e) => {
                    //console.log(`L play ${e.target.currentTime} ${e.target.src}` );
                    
                    if (ws && ws.readyState === 1) ws.send(`L play ${e.target.currentTime} ${e.target.src}`);
                });
                elem.firstElementChild.addEventListener("pause", (e) => {
                    //console.log(`L pause ${e.target.currentTime} ${e.target.src}`);
                    if (ws && ws.readyState === 1) ws.send(`L pause ${e.target.currentTime} ${e.target.src}`);
                });
 
            } catch (e) {
                console.error(e);
            }
            return false; // prevent default action and stop event propagation
        }
    }
 
    //Links in new tab
    if (element.hash != null && element.hash.startsWith("#")) {
        console.log("LOCAL " + element.hash);
        location.hash = element.hash.substring(1);
        return false;
    }
    if (element.href != null) {
        console.log("Link clicked :" + element.href);
        window.open(element.href);
        e.preventDefault();
        return false;
    }
    if (element.href === undefined) {
        return true;
    }
};
