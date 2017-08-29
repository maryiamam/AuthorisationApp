"use strict";
var app = app || {};

app.infiniteScroll = (function ($) {

    var $searchResults;
    var searchString;
    var page = 1;
    var busy = false;
    var scrollFinished = false;

    function initialize() {
        $searchResults = $('#searchResults');
        searchString = $searchResults.data('search-string');
        $(window).scroll(scrollCallback);
    }

    function scrollCallback() {
        // Проверяем пользователя, находится ли он в нижней части страницы
        if ($(window).scrollTop() + $(window).height() > $searchResults.height() + $searchResults.offset().top - 600 && !busy && !scrollFinished) {

            // Идет процесс
            busy = true;

            getData();

        }
    }

    function getData() {
        $('#loading').show();
        $.post('/Search/GetSearchResults', {

            phrase: searchString,
            page: page

        }, function (data) {
                $('#loading').hide();
                page++;
                busy = false;

                if (!data || data.Hints.length === 0) {
                    scrollFinished = true;
                    return;
                } else {
                    var items = $.map(data.Hints,
                        function(hint) {
                            var $hintElem = $('<div class="row search-item"></div>');
                            var $imageElem = $('<div class="col-xs-4"><img src="' + hint.ImageSrc + '"/></div>');
                            var $titleContainer = $('<div class="col-xs-8"></div>');
                            var $anchorElem = $('<div class="col-xs-6"><a href="' + hint.Link + ' target="_blank">' + hint.Text + '</a></div>');
                            var $textElem = $('<div class="col-xs-4 article-text">' + hint.Price + '</div>');
                            $anchorElem.appendTo($titleContainer);
                            $textElem.appendTo($titleContainer);
                            $hintElem.append($imageElem);
                            $hintElem.append($titleContainer);
                            return $hintElem;
                        });
                    $searchResults.append(items);
                }
        });
    }

    return {
        initialize: initialize
    }
})(jQuery);