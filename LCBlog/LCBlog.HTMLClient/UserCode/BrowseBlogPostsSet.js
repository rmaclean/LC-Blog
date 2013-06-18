/// <reference path="../GeneratedArtifacts/viewModel.js" />

myapp.BrowseBlogPostsSet.DeleteBlogPost_execute = function (screen) {
    // Write code here. okay now what?
    if (confirm("Are you sure you want to delete this post?")) {
        screen.getBlogPostsSet().then(function (post) {
            post.selectedItem.deleteEntity();
            myapp.applyChanges();
        });
    };
};