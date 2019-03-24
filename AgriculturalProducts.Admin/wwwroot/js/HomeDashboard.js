$(document).ready(function () {
    $(callAjaxDashboard.productStatistics);
    $(callAjaxDashboard.providerStatistics);
    $(callAjaxDashboard.productTypeStatistics);
    $(callAjaxDashboard.categoryStatistics);
    $(callAjaxDashboard.cartsStatistics);
    $(callAjaxDashboard.usersStatistics);
    $(callAjaxDashboard.usersStatistics);
    $(callAjaxDashboard.orderStatistics);
    $(callAjaxDashboard.orderStaticsTotal);
    $(callAjaxDashboard.totalAccess);
});

var callAjaxDashboard = {
    //Thống kê sản phẩm
    productStatistics: function () {
        $(renderAPI.postAPI(PRODUCT_STATISTICS, true, 'post', null, callAjaxDashboard.dataProductStatistics, function () {
            //window.location.href = DOMAIN+"AccountAdmin/Login";
        }));
    },
    dataProductStatistics: function (result) {
        $('.product-statistics').text(result.data);
    },
    //Thống kê nhà cung cấp
    providerStatistics: function () {
        $(renderAPI.postAPI(PROVIDER_STATISTICS, true, 'post', null, callAjaxDashboard.dataProdiverStatistics, function () {
            //window.location.href = DOMAIN+"AccountAdmin/Login";
        }));
    },
    dataProdiverStatistics: function (result) {
        $('.prodiver-statistics').text(result.data);
    },
    //Thống kê loại sản phẩm
    productTypeStatistics: function (result) {
        $(renderAPI.postAPI(PRODUCT_TYPE_STATISTICS, true, 'post', null, callAjaxDashboard.dataProductTypeStatistics, function () {
            //window.location.href = DOMAIN+"AccountAdmin/Login";
        }));
    },
    dataProductTypeStatistics: function (result) {
        $('.product-type-statistics').text(result.data);
    },
    //Thống kê danh mục sản phẩm
    categoryStatistics: function (result) {
        $(renderAPI.postAPI(CATEGORY_STATISTICS, true, 'post', null, callAjaxDashboard.dataCategoryStatistics, function () {
            //window.location.href = DOMAIN+"AccountAdmin/Login";
        }));
    },
    dataCategoryStatistics: function (result) {
        $('.category-statistics').text(result.data);
    },
    //Thống kê đơn hàng
    //cartsStatistics: function (result) {
    //    $(renderAPI.postAPI(CARTS_STATISTICS, true, 'post', null, callAjaxDashboard.dataCartsStatistics, function () {
    //    }));
    //},
    dataCartsStatistics: function (result) {
        $('.cart-statistics').text(result.data);
    },
    //Thống kê người dùng
    usersStatistics: function (result) {
        $(renderAPI.postAPI(USERS_STATISTICS, true, 'post', null, callAjaxDashboard.dataUsersStatistics, function () {
            //window.location.href = DOMAIN+"AccountAdmin/Login";
        }));
    },
    dataUsersStatistics: function (result) {
        $('.users-statistics').text(result.data);
    },
    orderStatistics: function () {
        $(renderAPI.postAPI(ORDER_STATISTICS, true, 'post', null, callAjaxDashboard.dataOrderStatistics, function (xhr, status) {
            //window.location.href = DOMAIN + "AccountAdmin/Login";
        }));
    },
    dataOrderStatistics: function (result) {
        
    },
    orderStaticsTotal: function () {
        $(renderAPI.postAPI(TOTAL_ORDER, true, 'post', null, callAjaxDashboard.dataTotalOrder, function (xhr, status) {
            //window.location.href = DOMAIN + "AccountAdmin/Login";
        }));
    },
    dataTotalOrder: function (result) {
        $('.cart-statistics').text(result.data);
    },
    totalAccess: function () {
        $(renderAPI.postAPI(TOTAL_ACCESS, true, 'post', null, callAjaxDashboard.dataTotalAccess, function (xhr, status) {
            //window.location.href = DOMAIN + "AccountAdmin/Login";
        }));
    },
    dataTotalAccess: function (result) {
        $('.total-access').text(result.data);
    }
}