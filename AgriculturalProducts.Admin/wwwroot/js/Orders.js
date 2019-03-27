$(document).ready(function () {
    $(callAjaxOrders.getOrderPaging);
    $('.list-order tbody').on('click', '.btn-view-order', callAjaxOrders.getDetailsOrders);
});
var callAjaxOrders = {
    getOrderPaging: function () {
        var pageSize = $('.page-size-orders').val();
        var pageNumber = $('.page-number-orders').val();
        var searchString = $('.search-orders').val();
        var pagingParams = {
            pageNumber: pageNumber,
            pageSize: pageSize,
            searchString: searchString
        }
        $(renderAPI.postAPI(GET_ORDERS_PAGING, true, 'post', JSON.stringify(pagingParams), callAjaxOrders.dataOrder, callAjaxOrders.errorOrders))
    },
    dataOrder: function (result) {
        $('.total-pages-orders').text(result.data.paging.totalPages);
        $('.list-order tbody').html('');
        $.each(result.data.items, function (index, value) {
            var query = '<tr>' +
                '<th class="ordersId" hidden>' + value.id + '</th>' +
                '<th>' + value.custommer + '</th>' +
                '<th>' + value.email + '</th>' +
                '<th>' + value.address + '</th>' +
                '<th>' + value.totalQuantity + '</th>' +
                '<th>' + value.totalCost + '</th>' +
                '<th>' + value.processor + '</th>' +
                '<th>' + value.created + '</th>' +
                '<td>' +
                '<button type="button" class="btn btn-danger btn-sm btn-view-order mr-1">Chi tiết đơn hàng</button>' +
                '</td>' +
                '</tr>';
            $('.list-order tbody').append(query);
        });
    },
    errorOrders: function (xhr, status) {

    },
    getDetailsOrders: function () {
        $('.list-order tbody tr').removeClass('isWorking');
        $(renderAPI.isWorking(this));
        var checkIsWorking = $(".list-order tbody").find("isWorking");
        if (checkIsWorking) {
            debugger
            var productId = $('.isWorking .ordersId').text();
            var data = {
                id: productId
            }
            $(renderAPI.postAPI(DETAILS_ORDER, true, 'post', JSON.stringify(data), callAjaxOrders.successDetailsOrders, callAjaxOrders.errorDetailsOrders))
        } else {
            console.log("Lỗi product");
        }
    }
}