﻿//create connection

var connectionUserCount = new signalR.HubConnectionBuilder().withUrl("/hubs/userCount").build();

//connect to methods that hub invokes aka receive notifications from hub

connectionUserCount.on("updateTotalViews", (value) => {
    var newCountSpan = document.getElementById("totalViewsCounter");
    newCountSpan.innerText = value.toString();
});

//invoke hub methods aka send notifications to hub

function newWindowLoadedOnClient() {
    connectionUserCount.send("NewWindowLoaded");
}

//start connection

function fulfilled() {
    //do something on start
    console.log("Connection to used hub succesfull");
}

function rejected() {
    //rejected logs
}

connectionUserCount.start().then(fulfilled, rejected);