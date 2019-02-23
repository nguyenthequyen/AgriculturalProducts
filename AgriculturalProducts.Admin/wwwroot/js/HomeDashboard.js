$(document).ready(function () {
    $(callAjaxDashboard.productStatistics);
    $(callAjaxDashboard.providerStatistics);
});

var callAjaxDashboard = Object.create({
    //Thống kê sản phẩm
    productStatistics: function () {
        $(renderAPI.postAPI(PRODUCT_STATISTICS, true, 'post', null, callAjaxDashboard.dataProductStatistics, function () {
        }));
    },
    dataProductStatistics: function (result) {
        $('.product-statistics').text(result.data);
    },
    providerStatistics: function () {
        $(renderAPI.postAPI(PROVIDER_STATISTICS, true, 'post', null, callAjaxDashboard.dataProdiverStatistics, function () {
        }));
    },
    dataProdiverStatistics: function (result) {
        $('.prodiver-statistics').text(result.data);
    }
})