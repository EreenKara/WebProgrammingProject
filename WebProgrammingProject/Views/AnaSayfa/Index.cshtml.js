const secim1Div = document.getElementById("secim1Div");
const secim2Div = document.getElementById("secim2Div");
const secim1 = document.getElementById("secim1");
const secim2 = document.getElementById("secim2");

secim1.onclick = secim1iac;
secim2.onclick = secim2iac;

function secim1iac() {
    secim1Div.style.display = "block"
    secim2Div.style.display = "none";
}
function secim2iac() {
    secim2Div.style.display = "block";
    secim1Div.style.display = "none";
}


const neredenLabel = document.getElementById("neredenLabel");
const nereden = document.getElementById("nereden");






nereden.onfocus = Focusta(neredenLabel);
nereden.onblur = LoseFocusta(neredenLabel);

// Wrapper fonksiyon
function Focusta(eleman) {
    function wrapper() {
        eleman.style.fontSize = "12px";
        eleman.style.bottom = "-20px";
    }

    return wrapper;
}
function LoseFocusta(eleman) {
    function wrapper() {
        eleman.style.fontSize= "20px";
        eleman.style.bottom = "-40px";
    }
    return wrapper;
}