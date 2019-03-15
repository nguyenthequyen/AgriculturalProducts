$(document).ready(function () {
    $('.btn-save').click(callAjaxBlogs.createdBlogs);
})

var callAjaxBlogs = {
    createdBlogs: function () {
        var data = {
            title: $('#title').val(),
            tags: $('#tags').val(),
            shortDescription: $('#shortDescription').val(),
            content: $('#edit').froalaEditor('html.get'),
        }
        $(renderAPI.postAPI(CREATED_BLOGS, true, 'post', JSON.stringify(data), callAjaxBlogs.successCreated, callAjaxBlogs.errorCreated))
    },
    successCreated: function (result) {
        alert("Thêm bài viết thành công");
    },
    errorCreated: function (xhr, status) {
        console.log(xhr);
    }
}