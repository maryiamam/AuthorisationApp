"use strict";
var app = app || {};

app.startIndexControl = (function ($) {

    function initialize() {
        var $startIndexBtn = $('#IndexButton');
        $startIndexBtn.click(function () {
            $startIndexBtn.html('Indexing...');
            $.get('/Search/StartIndexAsync', function (data) {
                $startIndexBtn.html('Start Index');
                return;
            });
        });
        var $searchBtn = $('#SearchButton');
        $searchBtn.click(function () {
            $.get('/Search/FindAsync', { phraze: "blabla" }, function (data) {
                return;
            });
        });
    }

    return {
        initialize: initialize
    }

})(jQuery);