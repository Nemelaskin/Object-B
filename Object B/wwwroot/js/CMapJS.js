if (document.cookie == null) {
    STATUS = "develop";
    setCookie('STATUS', STATUS, { 'max-age': 3600, samesite: 'strict' });
}

var STATUS = document.cookie;
STATUS = STATUS.split('=')[1];

let number = 1;
for (var i = 0; i < 52 * 30; i++) { //52 ряд
    CreateBlock(number);
    number++;
}



function CreateBlock(id) {
    var content = document.querySelector("#places")
    var node = document.createElement("p");
    node.id = id;
    node.style.width = "20px";
    node.style.background = "RED";
    node.style.height = "20px";
    node.style.float = "left";
    node.style.marginBottom = "0px";
    node.setAttribute("ordered", 0);
    node.addEventListener('click', SwitchState);
    content.appendChild(node);
}
let num = 0;
//Закрашивание квадратов
function SwitchState() {
    if (this.getAttribute("ordered") == 2) return;
    if (this.getAttribute("ordered") == 1) {
        this.setAttribute("ordered", 0);
        this.style.background = "RED"
        num--;
    } else {
        let ids = Number(this.id);
        let leftItem = document.getElementById(String(ids - 1));
        let rightItem = document.getElementById(String(ids + 1));
        let upItem = document.getElementById(String(ids - 52));
        let downItem = document.getElementById(String(ids + 52));
        if (num == 0 && STATUS == "develop") {
            this.style.background = "Blue"
            this.setAttribute("ordered", 1);
            num++;
        }
        if (leftItem.getAttribute("ordered") == 1  || rightItem.getAttribute("ordered") == 1
            || upItem.getAttribute("ordered") == 1 || downItem.getAttribute("ordered") == 1) {
            this.style.background = "Blue"
            this.setAttribute("ordered", 1);
            num++;

        }
        else {

            return;
        }

    }

}


let newRoom = "";
function newTestButt() {
    var places = $('[ordered = 1]');
    if (places != undefined && places.length > 0) {

        for (var i = 0; i < places.length; i++) {
            newRoom += places[i].getAttribute("id") + " ";

            places[i].style.background = "Green";
            places[i].setAttribute("ordered", 2);
            num = 0;
            location.href = location.href;
        }

        postData(newRoom);
    }
}


let actualRoom = document.getElementById("actualRoom").innerHTML.split(':')[1];
actualRoom = actualRoom.split('<')[0];
actualRoom = Number(actualRoom);

postData(newRoom);

function postData(newRoom) {
    fetch("http://localhost:5000/MapComp/CreateRoom?selectRoomId=" + actualRoom + "&newRoom=" + newRoom)
        .then(response => {

            return response.json();
        }).then(data => {
            countRooms(data);
            SelectRoom(data);
        });
}

function SelectRoom(data) {
    let room = "";
    for (var i = 0; i < data.length; i++) {
        if (data[i]['RoomId'] == actualRoom) {
            room = data[i]['CoordinatesRoom'];
        }
    }
    if (room != "") {
        room = room.split(" ");
        //console.log(room);
        if (STATUS == "develop") {
            var places = $('[ordered = 2]');
            for (var i = 0; i < places.length; i++) {
                for (var j = 0; j < room.length; j++) {
                    if (places[i].getAttribute("id") == room[j]) {
                        places[i].style.background = "Blue";
                        places[i].setAttribute("ordered", 1);
                        num++;
                    }
                }
            }
        }

    }
}


function countRooms(data) {
    var nowCompany = document.getElementById("CompanyNow").innerHTML.split('<')[0];
    let allRooms = "";
    for (var i = 0; i < data.length; i++) {
        if (data[i]['Company']['NameCompany'] == nowCompany) {
            allRooms += data[i]['CoordinatesRoom'] + " ";
        }
    }
    blockRooms(allRooms);
}

function blockRooms(allRooms) {

    allRooms = allRooms.split(' ');
    var places = $('[ordered = 0]');

    if (places != undefined && places.length > 0) {

        for (var i = 0; i < places.length; i++) {
            for (var j = 0; j < allRooms.length; j++) {
                if (places[i].getAttribute("id") == allRooms[j]) {
                    places[i].style.background = "Green";
                    places[i].setAttribute("ordered", 2);

                }
            }
        }
    }
}



function statusFunc() {
    if (STATUS == "develop")
        STATUS = "save";
    else
        STATUS = "develop";
    setCookie('STATUS', STATUS, { 'max-age': 3600, samesite: 'strict' });
    location.href = location.href;
}


function setCookie(name, value, options = {}) {

    options = {
        path: '/',
        // при необходимости добавьте другие значения по умолчанию
        ...options
    };

    if (options.expires instanceof Date) {
        options.expires = options.expires.toUTCString();
    }

    let updatedCookie = name + "=" + value;

    for (let optionKey in options) {
        updatedCookie += "; " + optionKey;
        let optionValue = options[optionKey];
        if (optionValue !== true) {
            updatedCookie += "=" + optionValue;
        }
    }

    document.cookie = updatedCookie;
}
