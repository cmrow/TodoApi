function start() {
    const btnSend = document.getElementById('send');
    btnSend.addEventListener('click', getRomanNumber);
}

function getRomanNumber() {
    const endPoint = "https://localhost:5001/api/Romano/";
    const num = document.getElementById('inNumber').value;
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById('result').innerHTML = this.responseText;
        }
    }
    xhttp.open("GET", `${endPoint}${num}`, true);
    xhttp.send();
}

window.addEventListener('load', start);