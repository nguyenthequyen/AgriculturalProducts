$(document).ready(function () {
    $(".btn-add-provider").click(callAjaxProvider.insertProvider);
    $(callAjaxProvider.getProviderPaggingnate);
    $('.btn-get-data').click(callAjaxProvider.getProviderPaggingnate);
    $('.btn-search-infor').click(callAjaxProvider.getProviderPaggingnate);
    $('.provider tbody').on('click', '.btn-edit-provider', callAjaxProvider.editProvider);
    $('.provider tbody').on('click', '.btn-delete-provider', callAjaxProvider.deleteProvider);
    $('.provider tbody').on('click', '.btn-view-provider', callAjaxProvider.viewProvider);
    $('.btn-status-provider').click(callAjaxProvider.loadDataStatusProduct);
    $('.list-status-provider').on('click', 'a', callAjaxProvider.addDataStatusProvider);
});
var callAjaxProvider = {
    insertProvider: function () {
        var providerName = $('.provider-name').val();
        var providerCode = $('.provider-code').val();
        var providerPhone = $('.provider-phone').val();
        var providerAddress = $('.provider-address').val();
        var statusProviderId = $('#insertProvider').find(".btn-status-provider").attr('details-id-status-provider');
        var providerDateTimeRegister = $('.provider-datetime-register').val();
        var provider = {
            name: providerName,
            code: providerCode,
            phone: providerPhone,
            address: providerAddress,
            statusProviderId: statusProviderId,
            DateTimeRegister: providerDateTimeRegister
        }
        var providers = [];
        providers.push(provider)
        $(renderAPI.postAPI(INSERT_PROVIDER, true, 'post', JSON.stringify(providers), callAjaxProvider.getProviderPaggingnate, callAjaxProvider.errorInsertProvider))
    },
    errorInsertProvider: function (jqXHR, exception) {
        console.log("error: " + jqXHR + "exception: " + exception);
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
        $(renderAPI.postAPI(GET_PROVIDER_PAGINGATE, true, 'post', JSON.stringify(pagingParams), callAjaxProvider.dataProvider, callAjaxProvider.errorGetPagingNate))
    },
    dataProvider: function (result) {
        $('.total-pages').text(result.data.paging.totalPages);
        $('.provider tbody').html('');
        $.each(result.data.items, function (index, value) {
            var query = '<tr class="row-table">' +
                '<td hidden id="provider-id">' + value.id + '</td>' +
                '<td>' + value.code + '</td>' +
                '<td>' + value.name + '</td>' +
                '<td>' + value.phone + '</td>' +
                '<td>' + value.address + '</td>' +
                '<td>' + value.status + '</td>' +
                '<td>' + value.dateTimeRegister + '</td>' +
                '<td>' + value.DateTimeStop + '</td>' +
                '<td>' +
                '<button type="button" class="btn btn-secondary btn-sm mr-1 btn-edit-provider">Sửa</button>' +
                '<button type="button" class="btn btn-success btn-sm mr-1 btn-delete-provider">Xóa</button>' +
                '<button type="button" class="btn btn-danger btn-sm mr-0 btn-view-provider">Xem</button>' +
                '</td>' +
                '</tr>';
            $('.provider tbody').append(query);
        });
    },
    errorGetPagingNate: function (jqXHR, exception) {
        console.log("error: " + jqXHR + "exception: " + exception);
    },
    editProvider: function () {
        $('.provider tbody tr').removeClass('isWorking');
        $(renderAPI.isWorking(this));
        var checkIsWorking = $(".provider tbody").find("isWorking");
        if (checkIsWorking) {
            console.log($('.isWorking #provider-id').text());
        } else {
            console.log("Lỗi provider");
        }
    },
    deleteProvider: function () {
        $('.provider tbody tr').removeClass('isWorking');
        $(renderAPI.isWorking(this));
        var checkIsWorking = $(".provider tbody").find("isWorking");
        if (checkIsWorking) {
            var providerId = $('.isWorking #provider-id').text();
            var data = {
                id: providerId
            }
            var array = [];
            array.push(data);
            $(renderAPI.postAPI(DELETE_PROVIDER, true, 'post', JSON.stringify(array), callAjaxProvider.getProviderPaggingnate, callAjaxProvider.errorDeleteProvider))
        } else {
            console.log("Lỗi provider");
        }
    },
    errorDeleteProvider: function (jqXHR, exception) {
        console.log("error: " + jqXHR + "exception: " + exception);
    },
    viewProvider: function () {
        $('.provider tbody tr').removeClass('isWorking');
        $(renderAPI.isWorking(this));
        var checkIsWorking = $(".provider tbody").find("isWorking");
        if (checkIsWorking) {
            console.log($('.isWorking #provider-id').text());
        } else {
            console.log("Lỗi provider");
        }
    },
    loadDataStatusProduct: function () {
        $(renderAPI.postAPI(GET_ALL_STATUS_PROVIDER, true, 'post', null, callAjaxProvider.dataLoadStatusProvider, callAjaxProvider.errorLoadAllStatusProvider))
    },
    dataLoadStatusProvider: function (result) {
        $('.list-status-provider').html('');
        $.each(result.data, function (index, value) {
            var query = '<a class="dropdown-item" statusProviderId="' + value.id + '">' + value.name + '</a>';
            $('.list-status-provider').append(query);
        });
    },
    errorLoadAllStatusProvider: function () {

    },
    addDataStatusProvider: function () {
        (renderAPI.isWorkingDropdownList(this));
        var statusProductId = $('.list-status-provider').find('.isWorking').attr('statusProviderId');
        var productTypeName = $('.list-status-provider').find('.isWorking').text();
        $('.btn-status-provider').attr('details-id-status-provider', statusProductId);
        $('.btn-status-provider').text(productTypeName);
    }
}