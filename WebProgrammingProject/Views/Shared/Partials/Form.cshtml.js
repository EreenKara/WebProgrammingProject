const neredenLabel = document.getElementById("neredenLabel");
const nereden = document.getElementById("nereden");

nereden.onfocus = Focusta(neredenLabel);
nereden.onblur = LoseFocusta(neredenLabel);

// Wrapper fonksiyon
function Focusta(eleman) {
    function wrapper() {
        eleman.style.fontSize = "12px";
        eleman.style.top="20px";
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
