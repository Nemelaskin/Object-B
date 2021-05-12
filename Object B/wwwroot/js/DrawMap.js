let canvas = document.getElementById('cl');
let ctx = canvas.getContext('2d');

var w = 52 * 20;
var h = 20 * 30;
canvas.style.width = w + "px";
canvas.style.height = h + "px";

ctx.beginPath();
ctx.fillStyle = "#C0C0C0";
ctx.rect(0, 0, w, h);
ctx.stroke();
ctx.fill();

ctx.beginPath();

function drawRect(data) {
    let idMass = "";
    var nowCompany = document.getElementById("CompanyNow").innerHTML.split('<')[0];

    for (var i = 0; i < data.length; i++) {
        if (data[i]['Company']['NameCompany'] == nowCompany) {
            idMass += data[i]['CoordinatesRoom'] + " ";
        }
    }

    idMass = idMass.split(' ');

    ctx.stroke.style = "black";
    ctx.lineWidth = "5";
    ctx.fillStyle = "orange";

    let id;
    let x;
    let y;
    for (var i = 0; i < idMass.length; i++) {
        id = idMass[i];
        x = id % 52;
        y = Math.trunc(id / 52);
        ctx.rect((x-1) * 20, y * 20, 20, 20);
        ctx.stroke();
        ctx.fill();
    }
    getPoints();
}

postData();
function postData() {
    var newRoom = "";
    fetch("http://localhost:5000/MapComp/CreateRoom?selectRoomId=" + actualRoom + "&newRoom=" + newRoom)
        .then(response => {
            return response.json();
        }).then(data => {
            drawRect(data);
        });
}


function getPoints() {
    var newRoom = "";
    fetch("http://localhost:5000/MoveWorker/GetSensors")
        .then(response => {
            return response.json();
        }).then(data1 => {
            drawPoint(data1);
        });
}

function drawPoint(data1) {
    
    var pi = Math.PI;
    
    for (var i = 0; i < data1.length; i++) {
        var coords = "";
        
        coords += data1[i]['Coordinates'];
        coords = coords.split('.');
        for (var j = 0; j < 2; j++) {
            ctx.beginPath();
            ctx.lineWidth = "4px";
            ctx.strokeStyle = "red";
            ctx.fillStyle = "red";
            ctx.arc(coords[0], coords[1], 5, 0, 2 * pi, false);
            ctx.stroke();
            ctx.fill();
        }
    }
}
