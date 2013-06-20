/// <reference path="jquery-2.0.2.js" />

(function ($, undefined) {
    "use strict";

    $.fn.loadAllBlogPosts = function () { 
        var element = this;
        $.getJSON("/ApplicationData.svc/BlogPostsSet", function (blogPosts) {
            $.each(blogPosts.value, function (index, blogPost) {
                var div = document.createElement("div");
                div.classList.add("title");
                div.innerText = blogPost.Title;

                element.append(div);
            });
        });

        return this;
    };

})(jQuery);