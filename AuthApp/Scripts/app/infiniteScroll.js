"use strict";
var app = app || {};

app.infiniteScroll = (function ($) {

    var $searchResults;
    var searchString;
    var page = 0;
    var busy = false;
    var scrollFinished = false;

    function initialize() {
        $searchResults = $('#searchResults');
        searchString = $searchResults.data('search-string');
        getData();
        $(window).scroll(scrollCallback);
    }

    function scrollCallback(e) {
        // Проверяем пользователя, находится ли он в нижней части страницы
        if ($(window).scrollTop() + $(window).height() > $searchResults.height() + $searchResults.offset().top && !busy && !scrollFinished) {

            // Идет процесс
            busy = true;

            getData();

        }
    }

    function getData() {
        var url = 'https://www.ru-chipdip.by/search?searchtext=' + searchString;
        if (page !== 0) {
            url += 'page=' + page;
        }
        $.ajax({
            url: url,
            type: 'GET',
            crossDomain: true,
            //dataType: 'html',
            success: function (data) {

                page++;
                busy = false;

                //if (!data || data.Hints.length === 0) {
                //    scrollFinished = true;
                //    return;
                //} else {
                //    var items = $.map(data.Hints,
                //        function(hint) {
                //            var $hintElem = $('<div class="row search-item"></div>');
                //            var $titleElem = $('<div class="col-xs-4">' + hint.Title + '</div>');
                //            var $textElem = $('<div class="col-xs-8 article-text">' + hint.Text + '</div>');
                //            $hintElem.append($titleElem);
                //            $hintElem.append($textElem);
                //            return $hintElem;
                //        });
                //    $searchResults.append(items);
                //}
            }

        });
    }

    return {
        initialize: initialize
    }
})(jQuery);