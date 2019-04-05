$(document).ready(function () {
    $(callAjaxCartsDetails.viewCartsDetails);
    $('.pull-right').click(callAjaxCartsDetails.orderCarts);
    $('.listproducts tbody').on('click', '.add', callAjaxCartsDetails.changeQuantity);
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
                var query = '<tr class="a-product">' +
                    '<td class="productId" hidden>' + value.productCart.id + '</td>' +
                    '<td class="text-left">' +
                    '<a href="#"><img src="' + value.productCart.path + '" class="img-responsive" alt="img" title="img"></a>' +
                    '<div class="name">' + value.productCart.name + '</div>' +
                    '</td>' +
                    '<td class="text-center cost">' + formatNumber(value.productCart.cost, ',', '.') + ' VNĐ</td>' +
                    '<td class="text-center cost-hidden">' + value.productCart.cost + '</td>' +
                    '<td class="text-center">' +
                    '<p class="qtypara">' +
                    '<span id="minus" class="minus"><i class="fa fa-minus"></i></span>' +
                    '<input type="text" name="quantity" value="' + value.quantity + '" size="2" id="input-quantity" class="form-control qty quantity">' +
                    '<span id="add" class="add"><i class="fa fa-plus"></i></span>' +
                    '<input type="hidden" name="product_id" value="1">' +
                    '</p>' +
                    '</td>' +
                    '<td class="text-center totalCost" hidden>' + (value.productCart.cost * value.quantity) + '</td>' +
                    '<td class="text-center totalCost-display">' + formatNumber((value.productCart.cost * value.quantity), ',', '.') + ' VNĐ</td>' +
                    '<td class="text-center">' +
                    '<button type="button"><i class="icon_close_alt2"></i></button>' +
                    '</td>' +
                    '</tr>';
                $('.listproducts tbody').append(query);
            })
        }
    },
    errorViewsCartsDetails: function (xhr, exception) {
        if (xhr.status == 500) {
            window.location.href = DOMAIN + "Home/ServerInternal";
        } else {
            console.log(xhr);
        }
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
    },
    changeQuantity: function () {
        $('.listproducts').find('.a-product').removeClass('isWorking');
        $(renderAPI.isWorkingCarts(this));
        var isWorking = $('.listproducts').find('isWorking');
        if (isWorking) {
            var quantity = $('.isWorking input').val();
            $('.isWorking input').val(parseInt(quantity) + 1);
            var quantityafter = $('.isWorking input').val();
            var cost = $('.isWorking .cost-hidden').text();
            $('.isWorking .totalCost-display').text(formatNumber((parseInt(quantityafter) * parseInt(cost)), ',', '.') + ' VNĐ');
            debugger
        }
    }
}