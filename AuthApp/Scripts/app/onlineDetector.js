"use strict";
var app = app || {};
app.onlineDetector = (function ($) {
    function initialize() {
        $.get("/User/UpdateUserStatus");
        setInterval(function () {
            $.get("/User/UpdateUserStatus");
        }, 60000);
    }

    return {
        initialize: initialize
    }
})(jQuery);