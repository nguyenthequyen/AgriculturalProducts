$(document).ready(function () {
    $(callAjaxOrders.getOrderPaging);
    $(callAjaxOrders.getDetailsOrderPaging);
    $('.list-order tbody').on('click', '.btn-view-order', callAjaxOrders.getDetailsOrders);
    $('.list-order-details tbody').on('click', '.btn-update-order', callAjaxOrders.updateOrderDetails);
    $('.btn-update-order').click(callAjaxOrders.updateOrderDetailsModal);
    $('.btn-status-cart').click(callAjaxOrders.getStatusCart);
    $('.list-status-cart').on('click', 'a', callAjaxOrders.addDataStatusCart);
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
            var productId = $('.isWorking .ordersId').text();
            var data = {
                id: productId
            }
            $(renderAPI.postAPI(DETAILS_ORDER, true, 'post', JSON.stringify(data), callAjaxOrders.successDetailsOrders, callAjaxOrders.errorDetailsOrders))
        } else {
            console.log("Lỗi product");
        }
    },
    successDetailsOrders: function (result) {
        window.location.href = DOMAIN + "Carts/OrdersDetails?orderId=" + result.orderId
    },
    errorDetailsOrders: function (xhr, status) {
        alert("Lỗi xem chi tiết đơn hàng");
    },
    getDetailsOrderPaging: function () {
        var orderId = GetURLParameter('orderId');
        var data = {
            id: orderId
        }
        $(renderAPI.postAPI(DETAILS_ORDER, true, 'post', JSON.stringify(data), callAjaxOrders.dataDetailsOrderById, callAjaxOrders.errorDetailsOrdersById))
    },
    dataDetailsOrderById: function (result) {
        $('.list-order-details tbody').html('');
        $.each(result.data.items, function (index, value) {
            var html = '<tr>' +
                '<th class="productId" hidden>' + value.productId + '</th>' +
                '<th class="orderDetailsId" hidden>' + value.id + '</th>' +
                '<th class="orderId" hidden>' + value.orderId + '</th>' +
                '<th class="statuscartid" hidden>' + value.statusCartId + '</th>' +
                '<th class="product-name">' + value.productName + '</th>' +
                '<th class="quantity">' + value.quantity + '</th>' +
                '<th class="total-cost">' + value.totalCost + '</th>' +
                '<th class="status-cart">' + value.statusCart + '</th>' +
                '<th>' +
                '<button type="button" class="btn btn-danger btn-sm btn-update-order mr-1" data-toggle="modal" data-target=".bd-order-modal-lg">Cập nhật</button>' +
                '</th>' +
                '</tr>';
            $('.list-order-details tbody').append(html);
        });
    },
    errorDetailsOrdersById: function (xhr, status) {
        alert("Lỗi xem chi tiết đơn hàng");
    },
    updateOrderDetails: function () {
        $('.list-order-details tbody tr').removeClass('isWorking');
        $(renderAPI.isWorking(this));
        var checkIsWorking = $(".list-order-details tbody").find("isWorking");
        if (checkIsWorking) {
            $('.product-id').val($('.isWorking .productId').text());
            $('.order-detailsid').val($('.isWorking .orderDetailsId').text());
            $('.orderId').val($('.isWorking .orderId').text());
            $('.product-name').val($('.isWorking .product-name').text());
            $('.product-quantity').val($('.isWorking .quantity').text());
            $('.product-cost').val($('.isWorking .total-cost').text());
            $('.btn-status-cart').text($('.isWorking .status-cart').text());
            $('.btn-status-cart').attr('statuscartid', $('.isWorking .statuscartid').text());
        } else {
            console.log("Lỗi product");
        }
    },
    getStatusCart: function () {
        $(renderAPI.postAPI(GET_STATUS_CART, true, 'post', null, callAjaxOrders.successStatusCart, callAjaxOrders.errorStatusCart))
    },
    successStatusCart: function (result) {
        $('.list-status-cart').html('');
        $.each(result.data, function (index, value) {
            var query = '<a class="dropdown-item" statusid="' + value.id + '">' + value.name + '</a>';
            $('.list-status-cart').append(query);
        });
    },
    errorStatusCart: function (xhr, status) {
        debugger
        console.log(xhr);
    },
    addDataStatusCart: function () {
        $(renderAPI.isWorkingDropdownList(this));
        var productTypeId = $('.list-status-cart').find('.isWorking').attr('statusid');
        var productTypeName = $('.list-status-cart').find('.isWorking').text();
        $('.btn-status-cart').attr('statuscartid', productTypeId);
        $('.btn-status-cart').text(productTypeName);
    },
    updateOrderDetailsModal: function () {
        var productId = $('.product-id').val();
        var orderDetailsId = $('.order-detailsid').val();
        var orderId = $('.orderId').val();
        var quantity = $('.product-quantity').val();
        var statuscartid = $('.btn-status-cart').attr('statuscartid');
        var statusCart = $(".btn-status-cart").text();
        var data = {
            productId: productId,
            orderDetailsId: orderDetailsId,
            orderId: orderId,
            quantity: quantity,
            statuscartId: statuscartid,
            statusCart: statusCart
        }
        $(renderAPI.postAPI(UPDATE_ORDER, true, 'post', JSON.stringify(data), callAjaxOrders.successUpdateOrder, callAjaxOrders.errorUpdateOrder))
    },
    successUpdateOrder: function (result) {
        alert(result.data);
    },
    errorUpdateOrder: function (xhr, status) {

    }
}