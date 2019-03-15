$(document).ready(function () {
    $(callAjaxBlogs.getBlogs);
})

var callAjaxBlogs = {
    getBlogs: function () {
        $(renderAPI.postAPI(GET_BLOGS, true, 'post', null, callAjaxBlogs.successGetBlogs, callAjaxBlogs.errorGerBlogs));
    },
    successGetBlogs: function (result) {
        $('.list-blogs').html('');
        $.each(result.data, function (index, value) {
            var html = '<div class="col-md-4 col-sm-4 col-lg-4 col-xs-12">' +
                '<div class="box">' +
                '<img class="img-responsive" src="~/images/header3/blog1.png" alt="image" title="image">' +
                '<div class="caption">' +
                '<div class="common">' +
                '<ul class="list-inline pull-left">' +
                '<li>24<br> FEB</li>' +
                '<li><i class="fa fa-comments-o"></i></li>' +
                '<li><i class="icon_heart_alt"></i></li>' +
                '</ul>' +
                '<h6 class="pull-right"><i class="icon_profile"></i>Post by : <span>john doe</span></h6>' +
                '</div>' +
                '<h4>Fusce vulputate elementum</h4>' +
                '<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur finibus erat semper sapien laoreet, mattis cursus lacus imperdiet.</p>' +
                '<div class="text-right">' +
                '<a href="blog-detail.html">Read More >></a>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '</div>';
            $('.list-blogs').html(value.content);
            debugger
        })
        debugger
    },
    errorGerBlogs: function (xhr, status) {
        console.log(xhr);
    }
}