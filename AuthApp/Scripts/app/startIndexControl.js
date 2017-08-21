"use strict";
var app = app || {};

app.startIndexControl = (function ($) {

    function initialize() {
        var $startIndexBtn = $('#IndexButton');
        $startIndexBtn.click(function () {
            $startIndexBtn.html('Indexing...');
            $.get('/StoreManager/StartIndexAsync', function (data) {
                $startIndexBtn.html('Start Index');
                return;
            });
        });
        var $searchBtn = $('#SearchButton');
        $searchBtn.click(function () {
            $.get('/StoreManager/FindAsync', { phraze: "blabla" }, function (data) {
                return;
            });
        });
    }

    return {
        initialize: initialize
    }

})(jQuery);