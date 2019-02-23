$(document).ready(function () {
    $(callAjaxDashboard.productStatistics);
});

var callAjaxDashboard = Object.create({
    //Thống kê sản phẩm
    productStatistics: function () {
        $(renderAPI.postAPI(PRODUCT_STATISTICS, true, 'post', null, callAjaxAPI.dataProductStatistics, function () {
        }));
    },
    dataProductStatistics: function (result) {
        $('.product-statistics').text(result.data);
    }
})