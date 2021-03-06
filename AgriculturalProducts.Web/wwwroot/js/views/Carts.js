﻿$(document).ready(function () {
    $(callAjaxCarts.viewCartsDropdown);
    $('.btn-carts').click(callAjaxCarts.viewCartsDropdown);
    $('.details-carts tbody').on('click', '.icon_close', callAjaxCarts.removeCarts);
    //$('.btn-views-carts').click();
})

var callAjaxCarts = {
    viewCartsDropdown: function () {
        $(renderAPI.postAPI(GET_CARTS_SESSION, true, 'post', null, callAjaxCarts.dataViewsCarts, callAjaxCarts.errorViewsCarts))
    },
    dataViewsCarts: function (result) {
        $('.details-carts tbody').html('');
        if (result.data === null) {
            $('.details-carts tbody').append("Giỏ hàng trống");
        }
        else {
            $.each(result.data, function (index, value) {
                var query = '<tr>' +
                    '<td class="productid" hidden>' + value.productCart.id + '</td>' +
                    '<td class="text-center">' +
                    '<img src="' + value.productCart.path + '" class="img-responsive" alt="img" title="img" />' +
                    '</td>' +
                    '<td class="text-left">' +
                    '<a href="#">' + value.productCart.name + '</a>' +
                    '<p>' + value.quantity + 'x' + value.productCart.cost + '</p>' +
                    '</td>' +
                    '<td class="text-center">' +
                    '<button type="button" title="Remove" class="btn btn-danger btn-xs"><i class="icon_close"></i></button>' +
                    '</td>' +
                    '</tr>';
                $('.details-carts tbody').append(query);
            })
        }
    },
    errorViewsCarts: function (xhr, exception) {
        if (xhr.status == 500) {
            window.location.href = DOMAIN + "Home/ServerInternal";
        } else {
            console.log(xhr);
        }
    },
    removeCarts: function () {
        $(renderAPI.isWorkingCarts(this));
        var id = $('.isWorking').find('.productid').text();
        var data = {
            id: id
        }
        $(renderAPI.postAPI(REMOVE_CARTS_SESION, true, 'post', JSON.stringify(data), callAjaxCarts.dataAfterRemove, callAjaxCarts.errorAfterRemove));
    },
    dataAfterRemove: function (result) {
        $('.details-carts tbody').html('');
        $.each(result.data, function (index, value) {
            var query = '<tr>' +
                '<td class="productid" hidden>' + value.productCart.id + '</td>' +
                '<td class="text-center">' +
                '<img src="~/images/header1/deal-img6.png" class="img-responsive" alt="img" title="img" />' +
                '</td>' +
                '<td class="text-left">' +
                '<a href="#">' + value.productCart.name + '</a>' +
                '<p>' + value.quantity + 'x' + value.productCart.cost + '</p>' +
                '</td>' +
                '<td class="text-center">' +
                '<button type="button" title="Remove" class="btn btn-danger btn-xs"><i class="icon_close"></i></button>' +
                '</td>' +
                '</tr>';
            $('.details-carts tbody').append(query);
        })
    },
    errorAfterRemove: function (xhr, exception) {
        if (xhr.status == 500) {
            window.location.href = DOMAIN + "Home/ServerInternal";
        } else {
            console.log(xhr);
        }
    }
}