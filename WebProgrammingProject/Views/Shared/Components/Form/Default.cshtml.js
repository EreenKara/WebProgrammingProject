const neredenLabel = document.getElementById("neredenLabel");
const nereyeLabel = document.getElementById("nereyeLabel");
const nereden = document.getElementById("nereden");
const nereye = document.getElementById("nereye");

nereden.onfocus = Focusta(neredenLabel);
nereden.onblur = LoseFocusta(neredenLabel);
nereye.onfocus = Focusta(nereyeLabel);
nereye.onblur = LoseFocusta(nereyeLabel);
/*nereden.innerHTML.length>0*/
// Wrapper fonksiyon
function Focusta(eleman) {
    function wrapper() {
        eleman.style.fontSize = "10px";
        eleman.style.top="18px";
    }

    return wrapper;
}
function LoseFocusta(eleman) {
    function wrapper() {
        
        eleman.style.fontSize = "20px";
        eleman.style.top="40px";
    }
    return wrapper;
}
