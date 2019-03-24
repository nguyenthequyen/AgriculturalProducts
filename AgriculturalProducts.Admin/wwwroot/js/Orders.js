$(document).ready(function () {
    $(callAjaxOrders.getOrderPaging);
    $('.list-order tbody').on('click', '.btn-edit-order', callAjaxOrders.updateOrders);
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
                '<th class="ordersId" hidden></th>' +
                '<th class="orderDetailsId" hidden></th>' +
                '<th>' + value.userName + '</th>' +
                '<th>' + value.productName[0] + '</th>' +
                '<th>' + value.quantity + '</th>' +
                '<th>' + value.totalCost + '</th>' +
                '<th>' + value.createdDate + '</th>' +
                '<th class="text-danger">' + value.statusCart[0] + '</th>' +
                '<td>' +
                '<button type="button" class="btn btn-secondary btn-sm btn-edit-order mr-1" data-toggle="modal" data-target=".bd-order-modal-lg">Cập nhật đơn hàng</button>' +
                '<button type="button" class="btn btn-danger btn-sm btn-view-order mr-1">Xem</button>' +
                '</td>' +
                '</tr>';
            $('.list-order tbody').append(query);
        });
    },
    errorOrders: function (xhr, status) {

    },
    updateOrders: function () {
        debugger
    }
}