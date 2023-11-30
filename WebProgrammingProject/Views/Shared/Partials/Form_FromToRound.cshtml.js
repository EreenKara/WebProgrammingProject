const neredenLabelRound = document.getElementById("neredenLabelRound");
const neredenRound = document.getElementById("neredenRound");

neredenRound.onfocus = Focusta(neredenLabelRound);
neredenRound.onblur = LoseFocusta(neredenLabelRound);

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
