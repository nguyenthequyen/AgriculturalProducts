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
    $(callAjaxDashboard.getTotalRevene);
});

var callAjaxDashboard = {
    //Thống kê sản phẩm
    productStatistics: function () {
        $(renderAPI.postAPI(PRODUCT_STATISTICS, true, 'post', null, callAjaxDashboard.dataProductStatistics, function (xhr, status) {
            if (xhr.status === 401) {
                window.location.href = DOMAIN + "AccountAdmin/Login";
            }
            else if (xhr.status == 500) {
                window.location.href = DOMAIN + "Home/ServerInternal";
            } else if (xhr.status == 403) {
                window.location.href = DOMAIN + "Home/AccessDenine";
            } else {
                console.log(xhr);
            }
        }));
    },
    dataProductStatistics: function (result) {
        $('.product-statistics').text(result.data);
    },
    //Thống kê nhà cung cấp
    providerStatistics: function () {
        $(renderAPI.postAPI(PROVIDER_STATISTICS, true, 'post', null, callAjaxDashboard.dataProdiverStatistics, function () {
            if (xhr.status === 401) {
                window.location.href = DOMAIN + "AccountAdmin/Login";
            }
            else if (xhr.status == 500) {
                window.location.href = DOMAIN + "Home/ServerInternal";
            } else if (xhr.status == 403) {
                window.location.href = DOMAIN + "Home/AccessDenine";
            } else {
                console.log(xhr);
            }
        }));
    },
    dataProdiverStatistics: function (result) {
        $('.prodiver-statistics').text(result.data);
    },
    //Thống kê loại sản phẩm
    productTypeStatistics: function (result) {
        $(renderAPI.postAPI(PRODUCT_TYPE_STATISTICS, true, 'post', null, callAjaxDashboard.dataProductTypeStatistics, function () {
            if (xhr.status === 401) {
                window.location.href = DOMAIN + "AccountAdmin/Login";
            }
            else if (xhr.status == 500) {
                window.location.href = DOMAIN + "Home/ServerInternal";
            } else if (xhr.status == 403) {
                window.location.href = DOMAIN + "Home/AccessDenine";
            } else {
                console.log(xhr);
            }
        }));
    },
    dataProductTypeStatistics: function (result) {
        $('.product-type-statistics').text(result.data);
    },
    //Thống kê danh mục sản phẩm
    categoryStatistics: function (result) {
        $(renderAPI.postAPI(CATEGORY_STATISTICS, true, 'post', null, callAjaxDashboard.dataCategoryStatistics, function () {
            if (xhr.status === 401) {
                window.location.href = DOMAIN + "AccountAdmin/Login";
            }
            else if (xhr.status == 500) {
                window.location.href = DOMAIN + "Home/ServerInternal";
            } else if (xhr.status == 403) {
                window.location.href = DOMAIN + "Home/AccessDenine";
            } else {
                console.log(xhr);
            }
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
            if (xhr.status === 401) {
                window.location.href = DOMAIN + "AccountAdmin/Login";
            }
            else if (xhr.status == 500) {
                window.location.href = DOMAIN + "Home/ServerInternal";
            } else if (xhr.status == 403) {
                window.location.href = DOMAIN + "Home/AccessDenine";
            } else {
                console.log(xhr);
            }
        }));
    },
    dataUsersStatistics: function (result) {
        $('.users-statistics').text(result.data);
    },
    orderStatistics: function () {
        $(renderAPI.postAPI(ORDER_STATISTICS, true, 'post', null, callAjaxDashboard.dataOrderStatistics, function (xhr, status) {
            if (xhr.status === 401) {
                window.location.href = DOMAIN + "AccountAdmin/Login";
            }
            else if (xhr.status == 500) {
                window.location.href = DOMAIN + "Home/ServerInternal";
            } else if (xhr.status == 403) {
                window.location.href = DOMAIN + "Home/AccessDenine";
            } else {
                console.log(xhr);
            }
        }));
    },
    dataOrderStatistics: function (result) {

    },
    orderStaticsTotal: function () {
        $(renderAPI.postAPI(TOTAL_ORDER, true, 'post', null, callAjaxDashboard.dataTotalOrder, function (xhr, status) {
            if (xhr.status === 401) {
                window.location.href = DOMAIN + "AccountAdmin/Login";
            }
            else if (xhr.status == 500) {
                window.location.href = DOMAIN + "Home/ServerInternal";
            } else if (xhr.status == 403) {
                window.location.href = DOMAIN + "Home/AccessDenine";
            } else {
                console.log(xhr);
            }
        }));
    },
    dataTotalOrder: function (result) {
        $('.cart-statistics').text(result.data);
    },
    totalAccess: function () {
        $(renderAPI.postAPI(TOTAL_ACCESS, true, 'post', null, callAjaxDashboard.dataTotalAccess, function (xhr, status) {
            if (xhr.status === 401) {
                window.location.href = DOMAIN + "AccountAdmin/Login";
            }
            else if (xhr.status == 500) {
                window.location.href = DOMAIN + "Home/ServerInternal";
            } else if (xhr.status == 403) {
                window.location.href = DOMAIN + "Home/AccessDenine";
            } else {
                console.log(xhr);
            }
        }));
    },
    dataTotalAccess: function (result) {
        $('.total-access').text(result.data);
    },
    //Thống kê tổng doanh thu
    getTotalRevene: function () {
        $(renderAPI.postAPI(TOTAL_REVENUE, true, 'post', null, callAjaxDashboard.dataTotalRevene, function (xhr, status) {
            if (xhr.status === 401) {
                window.location.href = DOMAIN + "AccountAdmin/Login";
            }
            else if (xhr.status == 500) {
                window.location.href = DOMAIN + "Home/ServerInternal";
            } else if (xhr.status == 403) {
                window.location.href = DOMAIN + "Home/AccessDenine";
            } else {
                console.log(xhr);
            }
        }));
    },
    dataTotalRevene: function (result) {
        $('.total-revenue').text(formatNumber(result.data, ',', '.') + ' VNĐ');
    },
}