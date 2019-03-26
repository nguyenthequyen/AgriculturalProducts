﻿$(document).ready(function () {
    $(callAjaxCartsDetails.viewCartsDetails);
    $('.pull-right').click(callAjaxCartsDetails.orderCarts);
})
var callAjaxCartsDetails = {
    viewCartsDetails: function () {
        $(renderAPI.postAPI(GET_CARTS_SESSION, true, 'post', null, callAjaxCartsDetails.dataViewsCartsDetails, callAjaxCartsDetails.errorViewsCartsDetails))
    },
    dataViewsCartsDetails: function (result) {
        $('.listproducts tbody').html('');
        if (result.data === null) {
            $('.listproducts tbody').append("Giỏ hàng trống");
        }
        else {
            $.each(result.data, function (index, value) {
                var query = '<tr>' +
                    '<td class="productId" hidden>' + value.productCart.id + '</td>' +
                    '<td class="text-left">' +
                    '<a href="#"><img src="' + value.productCart.path + '" class="img-responsive" alt="img" title="img"></a>' +
                    '<div class="name">' + value.productCart.name + '</div>' +
                    '</td>' +
                    '<td class="text-center">' + value.productCart.cost + '</td>' +
                    '<td class="text-center">' +
                    '<p class="qtypara">' +
                    '<span id="minus" class="minus"><i class="fa fa-minus"></i></span>' +
                    '<input type="text" name="quantity" value="' + value.quantity + '" size="2" id="input-quantity" class="form-control qty quantity">' +
                    '<span id="add" class="add"><i class="fa fa-plus"></i></span>' +
                    '<input type="hidden" name="product_id" value="1">' +
                    '</p>' +
                    '</td>' +
                    '<td class="text-center totalCost">' + (value.productCart.cost * value.quantity) + '</td>' +
                    '<td class="text-center">' +
                    '<button type="button"><i class="icon_close_alt2"></i></button>' +
                    '</td>' +
                    '</tr>';
                $('.listproducts tbody').append(query);
            })
        }
    },
    errorViewsCartsDetails: function (jqXHR, exception) {
        console.log(jqXHR);
    },
    orderCarts: function () {
        var arr = [];
        $('.listproducts tbody tr').each(function (index, value) {
            var productId = $(this).find('.productId').text();
            var quantity = $(this).find('.quantity').val();
            var totalCost = $(this).find('.totalCost').text();
            var data = {
                quantity: quantity,
                totalCost: totalCost,
                productId: productId
            }
            arr.push(data);
        });
        debugger
        $(renderAPI.postAPI(ORDER_NOW, true, 'post', JSON.stringify(arr), callAjaxCartsDetails.dataOrderCarts, callAjaxCartsDetails.errorOrderCarts))
    },
    dataOrderCarts: function (result) {
        alert(result.data);
        window.location.href = DOMAIN;
    },
    errorOrderCarts: function (jqXHR, exception) {
        if (jqXHR.status == 401) {
            alert("Bạn cần đăng nhập để đặt hàng");
            window.location.href = DOMAIN + "AccountViews/Login";
        }
    }
}