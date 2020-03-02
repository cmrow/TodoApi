function start() {
    const btnSend = document.getElementById('send').addEventListener('click', getRomanNumber);
}

function getRomanNumber() {
    const endPoint = "https://localhost:5001/api/Romano/";
    const num = document.getElementById('inNumber').value;
    fetch(`${endPoint}${num}`)
        .then(res => {
            console.log(res.status);
            if (res.status == 406 || res.status == 404) {
                res.json().
                    then(data => alert(data.message))
            }
            else if (res.status == 200) {
                res.json().
                    then(data => {
                        document.getElementById('numR')
                            .innerHTML = data.rom;
                    })
            }
        })

}

window.addEventListener('load', start);