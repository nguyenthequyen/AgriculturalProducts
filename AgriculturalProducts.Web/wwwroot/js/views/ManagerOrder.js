$(document).ready(function () {
    $(callAjaxManagerOrder.getDataOrder)
});

var callAjaxManagerOrder = {
    getDataOrder: function () {
        $(renderAPI.postAPI(GET_ORDER_BY_USER_ID, true, 'post', null, callAjaxManagerOrder.successGetDataOrder, callAjaxManagerOrder.errorGetDataOrder));
    },
    successGetDataOrder: function (result) {
        $('.list-order tbody').html('');
        if (result.data === null) {
            $('.list-order tbody').append("Giỏ hàng trống");
        }
        else {
            $.each(result.data, function (index, value) {
                debugger
                var query = '<tr class="a-product">' +
                    '<td class="text-left">' +
                    '<a href="#"><img src="' + value.images[0] + '" class="img-responsive height-image" alt="img" title="img"></a>' +
                    '<div class="name">' + value.productName + '</div>' +
                    '</td>' +
                    '<td class="text-center cost">' + value.quantity + '</td>' +
                    '<td class="text-center cost">' + formatNumber(value.totalCost, ',', '.') + ' VNĐ</td>' +
                    '<td class="text-center">' + value.statusOrder + '</td>'
                '</td>' +
                    '</tr>';
                $('.list-order tbody').append(query);
            })
        }
    },
    errorGetDataOrder: function (xhr, status) {

    }
}