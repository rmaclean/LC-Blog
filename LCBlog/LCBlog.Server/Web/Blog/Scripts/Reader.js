/// <reference path="jquery-2.0.2.js" />

(function (blogReader, $, undefined) {
    "use strict";

    blogReader.config = {
        url: "/api/blog",
        allBlogPostsCallback : null
    };

    blogReader.loadAllBlogPosts = function () {
        $.getJSON(blogReader.config.url, function (blogPosts) {
            blogReader.config.allBlogPostsCallback(blogPosts);
        });
    };

})(window.blogReader = window.blogReader || {}, jQuery);