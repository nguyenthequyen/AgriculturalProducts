$(document).ready(function () {
    $(callAjaxUserClient.getUserPaging);
});

var callAjaxUserClient = {
    getUserPaging: function () {
        var pageSize = $('.page-size-user').val();
        var pageNumber = $('.page-number-user').val();
        var searchString = $('.search-user').val();
        var pagingParams = {
            pageNumber: pageNumber,
            pageSize: pageSize,
            searchString: searchString
        }
        $(renderAPI.postAPI(GET_USER_CLIENTPAGING, true, 'post', JSON.stringify(pagingParams), callAjaxUserClient.dataUserClient, callAjaxUserClient.errorGetUserClient));
    },
    dataUserClient: function (result) {
        $('.total-pages-user').text(result.data.paging.totalPages);
        $('.user-client tbody').html('');
        $.each(result.data.items, function (index, value) {
            var gender = '';
            if (value.gender === 0) {
                gender = "Nữ"
            } else {
                gender = "Nam"
            }
            var query = '<tr>' +
                '<th class="userId" hidden>' + value.id + '</th>' +
                '<th>' + value.name + '</th>' +
                '<th>' + value.email + '</th>' +
                '<th>' + value.address + '</th>' +
                '<th>' + value.birthDay + '</th>' +
                '<th>' + gender + '</th>' +
                '<th>' +
                '<button type="button" class="btn btn-danger btn-sm btn-view-user mr-1">Xem</button>' +
                '</th>' +
                '</tr>';
            $('.user-client tbody').append(query);
        });
    },
    errorGetUserClient: function (xhr, status) {
        console.log(xhr);
    }
}