
function start() {
    const btnSend = document.getElementById('send').addEventListener('click', getRomanNumber);
}

function getRomanNumber() {
    const endPoint = "https://localhost:5001/api/Romano/";
    const num = document.getElementById('inNumber').value;
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4) {
            console.log(this.readyState);
        }
        else if (this.status == 200) {
            console.log(this.status);

            document.getElementById('numR')
                .innerHTML = this.responseText;
            getBox1(xhttp.responseText);
        }
    }
    xhttp.open("GET", `${endPoint}${num}`, true);
    xhttp.send();
}

function appendTex(res) {
    document.getElementById('box1').innerHTML = res;
}

function getBox1(html) {
    const xhr = new XMLHttpRequest(),
        file = "views/box1.html",
        result = document.getElementById('result');
    xhr.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            result.innerHTML = `${this.responseText}`;
            appendTex(html)
        }
    }
    xhr.open("GET", file, true);
    xhr.send();
}

window.addEventListener('load', start);