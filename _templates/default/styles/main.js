function preprocess(){
	
	let ps=document.querySelectorAll("p");

	for(var i=0; i<ps.length; i++){
		if(ps[i].innerHTML.indexOf("(+/-)")==0){
			let t=document.createElement("span");
			t.innerHTML="<span class=\"tg_cnt\">#"+i+"</span><span>✓</span><span>?</span>";
			t.classList.add("tg_task");
			t.classList.add("tg_taskctrl");
			t.classList.add("tg_neutral");
			t.id="task"+i;
			
			let text=ps[i].innerText;
			text=text.substring(6,text.length-1);
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
	}
	
	let videos=$(".embeddedvideo");

	for(let i=0;i<videos.length;i++){
		videos[i].classList.add("hidden");
		videos[i].children[0].target=videos[i].children[0].scr;
		videos[i].children[0].scr="";
	}
	hideTOC();
	
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
        } else if (ele.classList.contains("tg_fail")) {
            ele.classList.remove("tg_fail");
            ele.classList.add("tg_neutral");
            newStatus = "0";
        }

    ws.send(`S ${el.id.substring(4)} ${newStatus}`);
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
	let tabs=document.getElementById("toc").children[0].children;
	for(let i=7;i<tabs.length;i++){
		tabs[i].classList.add("hidden");
	}
	
}
function lumos(){
	let tabs=document.getElementById("toc").children[0].children;
		for(let i=0;i<tabs.length;i++){
			tabs[i].classList.remove("hidden");
		}
}
window.addEventListener('load', 
  preprocess(), false);
