function preprocess(){
	hideTOC();
	
	let ps=document.querySelectorAll("p");
	let taskCount=0;
	for(var i=0; i<ps.length; i++){
		if(ps[i].innerHTML.indexOf("(+/-)")==0){
			taskCount++;
			let t=document.createElement("span");
			t.innerHTML="<span class=\"tg_cnt\">#"+taskCount+"</span><span>✓</span><span>?</span>";
			t.classList.add("tg_task");
			t.classList.add("tg_taskctrl");
			t.classList.add("tg_neutral");
			
			
			t.id="task"+taskCount;
			
			let text=ps[i].innerText;
			text=text.substring(6,text.length);
			ps[i].innerHTML="";
			
			ps[i].appendChild(t);
			ps[i].innerHTML+=text;
			ps[i].addEventListener("click", taskClicked);
		}
		else if(ps[i].innerHTML.indexOf("(!Vid)")==0){
			let text=ps[i].innerText;
			let a=document.createElement("a");

			text=text.substring(7,text.length);
			a.innerHTML=text;
			ps[i].innerHTML="";
			ps[i].appendChild(a);
			ps[i].addEventListener("click", videoClicked);
		}
		else if(ps[i].innerHTML.indexOf("(!Hint)")==0){
			taskCount++;
			let t=document.createElement("span");
			t.innerHTML="<span class=\"tg_cnt\">#"+taskCount+"</span><span>✓</span><span>?</span>";
			t.classList.add("tg_task");
			t.classList.add("tg_taskctrl");
			t.classList.add("tg_neutral");
			
			
			t.id="task"+taskCount;
			let hint=ps[i].innerText;
			let text=ps[i].innerText;
			let p=document.createElement("p");

			hint=hint.substring(text.indexOf("[!")+2,hint.length-1);
			text=text.substring(8,text.indexOf("[!")-1);
			p.innerHTML=hint;
			
			p.classList.add("hidden");
			p.classList.add("hint");
			ps[i].innerHTML="";
			ps[i].appendChild(t);
			ps[i].innerHTML+=text;
			ps[i].appendChild(p);
			ps[i].addEventListener("click", taskClicked);
		}
	}
	
	let videos=$(".embeddedvideo");

	for(let i=0;i<videos.length;i++){
		videos[i].classList.add("hidden");
		videos[i].children[0].target=videos[i].children[0].scr;
		videos[i].children[0].scr="";
	}
	
	for(let i=0;i<ps.length;i++){
		if(ps[i].innerHTML.indexOf("(!Stepper)")==0){
			ps[i].innerHTML="";
			ps[i].appendChild(generateStepper());
		}
	}
	
	
}
function taskClicked(e) {
    let el = e.target;
    //console.log(el);
    if (!el.id) {
        el = el.parentNode; //
    }

    let ele = el; //.firstChild
    console.log(e.target.id + " was clicked");
    let newStatus = "";
    if (ele.classList.contains("tg_neutral")) {
        ele.classList.remove("tg_neutral");
        ele.classList.add("tg_success");
        newStatus = "+";

    } else
        if (ele.classList.contains("tg_success")) {
            ele.classList.remove("tg_success");
            ele.classList.add("tg_fail");
            newStatus = "-";
		if(e.target.parentNode.parentNode.children[e.target.parentNode.parentNode.children.length-1].classList.contains("hint")){
			showHint(e.target.parentNode.parentNode.children[e.target.parentNode.parentNode.children.length-1]);
		}
		
        } else if (ele.classList.contains("tg_fail")) {
            ele.classList.remove("tg_fail");
            ele.classList.add("tg_neutral");
            newStatus = "0";
		if(e.target.parentNode.parentNode.children[e.target.parentNode.parentNode.children.length-1].classList.contains("hint")){
			hideHint(e.target.parentNode.parentNode.children[e.target.parentNode.parentNode.children.length-1]);
		}
        }

    //ws.send(`S ${el.id.substring(4)} ${newStatus}`);
}
function showHint(p){
	p.classList.remove("hidden");
}
function hideHint(p){
	p.classList.add("hidden");
}
function videoClicked(e){
	let el = e.target;
	if(el.parentNode.nextElementSibling.classList.contains("hidden")){
		el.parentNode.nextElementSibling.classList.remove("hidden");
		videos[i].children[0].scr=videos[i].children[0].target;
		
	}else{
		el.parentNode.nextElementSibling.classList.add("hidden");
	}
	
}
function hideTOC(){
	let k=0;
	try{
		let tabs=document.getElementById("toc").children[0].children;
		for(let i=6;i<tabs.length;i++){
			tabs[i].classList.add("hidden");
		}
	}catch(er){
		k++;
		setTimeout(hideTOC,k*100);
	}
	
	
}
function generateStepper(){
	// create parent element
	const parentElem = document.createElement("p");
	parentElem.setAttribute("id", "stepper-1");
	parentElem.classList.add("stepper");
	parentElem.classList.add("alert");

	// create child element 1
	const childElem1 = document.createElement("p");
	childElem1.classList.add("stepper-text");
	childElem1.textContent = "This is a sample text.";
	parentElem.appendChild(childElem1);

	// create child element 2
	const childElem2 = document.createElement("div");
	childElem2.classList.add("step-chevron-div");

	// create child element 2.1
	const childElem2_1 = document.createElement("button");
	childElem2_1.classList.add("step-chevron-up");

	// create child element 2.1.1
	const childElem2_1_1 = document.createElement("svg");
	childElem2_1_1.setAttribute("aria-hidden", "true");
	childElem2_1_1.classList.add("svg-icon", "iconArrowUpLg");
	childElem2_1_1.setAttribute("width", "36");
	childElem2_1_1.setAttribute("height", "36");
	childElem2_1_1.setAttribute("viewBox", "0 0 36 36");

	const childElem2_1_1_path = document.createElement("path");
	childElem2_1_1_path.setAttribute("d", "M2 25h32L18 9 2 25Z");
	childElem2_1_1.appendChild(childElem2_1_1_path);

	childElem2_1.appendChild(childElem2_1_1);
	childElem2.appendChild(childElem2_1);

	// create child element 2.2
	const childElem2_2 = document.createElement("div");
	childElem2_2.classList.add("step-counter");
	childElem2_2.textContent = "1.";
	childElem2.appendChild(childElem2_2);

	// create child element 2.3
	const childElem2_3 = document.createElement("button");
	childElem2_3.classList.add("step-chevron-down");

	// create child element 2.3.1
	const childElem2_3_1 = document.createElement("svg");
	childElem2_3_1.setAttribute("aria-hidden", "true");
	childElem2_3_1.classList.add("svg-icon", "iconArrowDownLg");
	childElem2_3_1.setAttribute("width", "36");
	childElem2_3_1.setAttribute("height", "36");
	childElem2_3_1.setAttribute("viewBox", "0 0 36 36");

	const childElem2_3_1_path = document.createElement("path");
	childElem2_3_1_path.setAttribute("d", "M2 11h32L18 27 2 11Z");
	childElem2_3_1.appendChild(childElem2_3_1_path);

	childElem2_3.appendChild(childElem2_3_1);
	childElem2.appendChild(childElem2_3);

	parentElem.appendChild(childElem2);

return parentElem;
}
function lumos(){
	let tabs=document.getElementById("toc").children[0].children;
		for(let i=0;i<tabs.length;i++){
			tabs[i].classList.remove("hidden");
		}
}
window.addEventListener('load', 
  preprocess(), false);
