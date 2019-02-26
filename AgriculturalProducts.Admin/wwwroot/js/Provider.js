$(document).ready(function () {
    $(".btn-add-provider").click(callAjaxProvider.insertProvider);
    $(callAjaxProvider.getProviderPaggingnate);
    $('.btn-get-data').click(callAjaxProvider.getProviderPaggingnate);
    $('.btn-search-infor').click(callAjaxProvider.getProviderPaggingnate);
});
var callAjaxProvider = {
    insertProvider: function () {
        debugger
        var providerName = $('.provider-name').val();
        var providerCode = $('.provider-code').val();
        var providerPhone = $('.provider-phone').val();
        var providerAddress = $('.provider-address').val();
        var providerStatus = $('.provider-status').val();
        var providerDateTimeRegister = $('.provider-datetime-register').val();
        var provider = {
            name: providerName,
            code: providerCode,
            phone: providerPhone,
            address: providerAddress,
            status: providerStatus,
            DateTimeRegister: providerDateTimeRegister
        }
        var providers = [];
        providers.push(provider)
        $(renderAPI.postAPI(INSERT_PROVIDER, true, 'post', JSON.stringify(providers), callAjaxProvider.getProviderPaggingnate, function () {

        }))
    },
    getProviderPaggingnate: function (result) {
        var pageSize = $('.page-size-provider').val();
        var pageNumber = $('.page-number-provider').val();
        var searchString = $('.search-provider').val();
        var pagingParams = {
            pageNumber: pageNumber,
            pageSize: pageSize,
            searchString: searchString
        }
        $(renderAPI.postAPI(GET_PROVIDER_PAGINGATE, true, 'post', JSON.stringify(pagingParams), callAjaxProvider.dataProvider, function () {
        }))
    },
    dataProvider: function (result) {
        $('.total-pages').text(result.data.paging.totalPages);
        $('.provider tbody').html('');
        $.each(result.data.items, function (index, value) {
            var query = '<tr>' +
                '<td hidden>' + value.id + '</td>' +
                '<td>' + value.code + '</td>' +
                '<td>' + value.name + '</td>' +
                '<td>' + value.phone + '</td>' +
                '<td>' + value.address + '</td>' +
                '<td>' + value.status + '</td>' +
                '<td>' + value.dateTimeRegister + '</td>' +
                '<td>' + value.DateTimeStop + '</td>' +
                '<td>' +
                '<button type="button" class="btn btn-secondary btn-sm mr-1">Sửa</button>' +
                '<button type="button" class="btn btn-success btn-sm mr-1">Xóa</button>' +
                '<button type="button" class="btn btn-danger btn-sm mr-0">Xem</button>' +
                '</td>' +
                '</tr>';
            $('.provider tbody').append(query);
        });
    }
}