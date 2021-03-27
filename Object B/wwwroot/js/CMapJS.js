

/*let allRooms = "";
allRooms = document.cookie.allRooms;
//alert(allRooms);
console.log(allRooms);
if (allRooms != "") {
    
}*/

let number = 1;
for (var i = 0; i < 1034; i++) { //47 ряд
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
    node.style.marginTop = "1px";
    node.style.marginBottom = "0px";
    node.style.border = "1px solid white";
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
        let upItem = document.getElementById(String(ids - 47));
        let downItem = document.getElementById(String(ids + 47));
        if (num == 0) {
            this.style.background = "Blue"
            this.setAttribute("ordered", 1);
            num++;
        }
        if ((rightItem.getAttribute("ordered") == 0 && leftItem.getAttribute("ordered") == 1
            || rightItem.getAttribute("ordered") == 1 && leftItem.getAttribute("ordered") == 0)
            || upItem.getAttribute("ordered") == 1 || downItem.getAttribute("ordered") == 1) {
            this.style.background = "Blue"
            this.setAttribute("ordered", 1);
            num++;
        }
        else {

            return;
        }

    }
    console.log(num);
}



function newTestButt() {
    var places = $('[ordered = 1]');
    if (places != undefined && places.length > 0) {
        let newRoom = "";
        for (var i = 0; i < places.length; i++) {
            newRoom += " " + places[i].getAttribute("id");

            places[i].style.background = "Green";
            places[i].setAttribute("ordered", 2);
            num = 0;

        }
        //allRooms += newRoom;
        //alert(allRooms);
        //setCookie('allRooms', allRooms, { 'max-age': 3600, samesite:'strict'});
        postData(newRoom);
    }
}


function postData(newRoom) {

    if (newRoom != "") {
        fetch("http://localhost:5000/MapComp/CreateRoom?newRoom="+newRoom)
            .then(response => {
                return response.text();
            }).then(data => {
                console.log(data);
            });
    }

}

/*
fetch("http://localhost:5000/MapComp/Test")
    .then(response => {
        return response.json();
    }).then(data => {
        //ViewDrone(data, 0);
        DropMenu(data);
    }
function DropMenu(data) {
    var doc = document;
    var id;
    var dropSomethink = doc.getElementById("myDropdown");
    for (var i = 0; i < data.length; i++) {
        id = i;
        var elem = doc.createElement("a");
        elem.addEventListener("click", () => {
            //ViewDrone(data, id);
        });
        elem.innerHTML = data[i]["NameRoom"] + "   " + data[i]["RoomId"];
        dropSomethink.appendChild(elem);
    }
}*/


/*
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
*/