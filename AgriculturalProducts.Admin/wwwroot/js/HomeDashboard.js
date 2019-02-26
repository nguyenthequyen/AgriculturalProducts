$(document).ready(function () {
    $(callAjaxDashboard.productStatistics);
    $(callAjaxDashboard.providerStatistics);
    $(callAjaxDashboard.productTypeStatistics)
    $(callAjaxDashboard.categoryStatistics)
    $(callAjaxDashboard.cartsStatistics)
});

var callAjaxDashboard = {
    //Thống kê sản phẩm
    productStatistics: function () {
        $(renderAPI.postAPI(PRODUCT_STATISTICS, true, 'post', null, callAjaxDashboard.dataProductStatistics, function () {
        }));
    },
    dataProductStatistics: function (result) {
        $('.product-statistics').text(result.data);
    },
    //Thống kê nhà cung cấp
    providerStatistics: function () {
        $(renderAPI.postAPI(PROVIDER_STATISTICS, true, 'post', null, callAjaxDashboard.dataProdiverStatistics, function () {
        }));
    },
    dataProdiverStatistics: function (result) {
        $('.prodiver-statistics').text(result.data);
    },
    //Thống kê loại sản phẩm
    productTypeStatistics: function (result) {
        $(renderAPI.postAPI(PRODUCT_TYPE_STATISTICS, true, 'post', null, callAjaxDashboard.dataProductTypeStatistics, function () {
        }));
    },
    dataProductTypeStatistics: function (result) {
        $('.product-type-statistics').text(result.data);
    },
    //Thống kê danh mục sản phẩm
    categoryStatistics: function (result) {
        $(renderAPI.postAPI(CATEGORY_STATISTICS, true, 'post', null, callAjaxDashboard.dataCategoryStatistics, function () {
        }));
    },
    dataCategoryStatistics: function (result) {
        $('.category-statistics').text(result.data);
    },
    //Thống kê đơn hàng
    cartsStatistics: function (result) {
        $(renderAPI.postAPI(CARTS_STATISTICS, true, 'post', null, callAjaxDashboard.dataCartsStatistics, function () {
        }));
    },
    dataCartsStatistics: function (result) {
        $('.cart-statistics').text(result.data);
    },
    //Thống kê người dùng
    usersStatistics: function (result) {
        $(renderAPI.postAPI(USERS_STATISTICS, true, 'post', null, callAjaxDashboard.dataUsersStatistics, function () {
        }));
    },
    dataUsersStatistics: function (result) {
        $('.users-statistics').text(result.data);
    },
}