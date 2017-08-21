"use strict";
var app = app || {};
app.userControl = (function ($) {
    function initialize() {
        var userControls = $('.user');
        userControls.click(function () {
            var $item = $(this);
            userControls.removeClass('user--active');
            $item.addClass('user--active');
        });
    }

    return {
        initialize: initialize
    }
})(jQuery);