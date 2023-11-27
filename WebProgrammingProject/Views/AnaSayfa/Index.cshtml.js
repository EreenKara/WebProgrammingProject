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
