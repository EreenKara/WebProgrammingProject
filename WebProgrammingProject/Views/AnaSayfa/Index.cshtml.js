const OneWayDiv= document.getElementById("OneWayDiv");
const RoundDiv = document.getElementById("RoundDiv");
const OneWay = document.getElementById("OneWay");
const RoundTrip = document.getElementById("RoundTrip");

OneWay.onchange = radioSecim;
RoundTrip.onchange = radioSecim;

function radioSecim() {
    if (OneWay.checked) {
        OneWayDiv.style.display = "block"
        RoundDiv.style.display = "none";
    }
    else if (RoundTrip.checked) {
        RoundDiv.style.display = "block";
        OneWayDiv.style.display = "none";
    }
}

