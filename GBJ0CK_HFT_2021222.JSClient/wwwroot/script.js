let LolPlayers = [];
let connection = null;


let LolPlayerIdToUpdate = -1;

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:48540/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("LolPlayerCreated", (user, message) => {
        getdata();
    });

    connection.on("LolPlayerDeleted", (user, message) => {
        getdata();
    });

    connection.on("LolPlayerUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};


fetch('http://localhost:48540/LolPlayer')
    .then(x => x.json())
    .then(y =>
    {
        LolPlayers = y;
        console.log(LolPlayers);
        display();
    });

async function getdata() {
    await fetch('http://localhost:48540/LolPlayer')
        .then(x => x.json())
        .then(y => {
            LolPlayers = y;
            //console.log(LolPlayers);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    LolPlayers.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>" +t.last_name + "</td><td>"
            + t.Name + "</td><td>"
            + t.plane_id + "</td><td>" +           
        `<button type="button" onclick="remove(${t.id})">Delete</button>`+
            `<button type="button" onclick="showupdate(${t.id})">Update</button>`
            + "</td></tr>";
    });
}



function create() {
    let Age = document.getElementById('Age').value;
    let Name = document.getElementById('Name').value;
    let lolteamid = document.getElementById('lolteamid').value;
    fetch('http://localhost:48540/LolPlayer', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Age: Age, Name: Name, LolTeam_id: lolteamid })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}


function remove(id) {
    fetch('http://localhost:48540/LolPlayer/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });        
}


function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let Age = document.getElementById('Agetoupdate').value;
    let Name = document.getElementById('Nametoupdate').value;
    let lolteamid = document.getElementById('lolteamidtoupdate').value;
    fetch('http://localhost:48540/LolPlayer', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Age: Age, Name: Name, LolTeam_id: lolteamid, id: LolPlayerIdToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}


function showupdate(id) {
    document.getElementById('Agetoupdate').value = LolPlayers.find(t => t['id'] == id)['Age'];
    document.getElementById('Nametoupdate').value = LolPlayers.find(t => t['id'] == id)['Name'];
    document.getElementById('lolteamidtoupdate').value = LolPlayers.find(t => t['id'] == id)['lolteamid'];
    document.getElementById('updateformdiv').style.display = 'flex';
    LolPlayerIdToUpdate = id;
}