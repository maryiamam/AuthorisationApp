"use strict";

var app = app || {};

$(function () {
    app.onlineDetector.initialize();
    app.userControl.initialize();
    app.startIndexControl.initialize();
    if (app.infiniteScroll) {
        app.infiniteScroll.initialize();
    }
})