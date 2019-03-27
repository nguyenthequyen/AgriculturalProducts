var DOMAIN = "https://localhost:44387/";
//Statistics
var PRODUCT_STATISTICS = DOMAIN + "api/homeadmin/product-statistics";
var PROVIDER_STATISTICS = DOMAIN + "api/homeadmin/provider-statistics";
var PRODUCT_TYPE_STATISTICS = DOMAIN + "api/homeadmin/product-type-statistics"
var CATEGORY_STATISTICS = DOMAIN + "api/homeadmin/category-statistics";
var CARTS_STATISTICS = DOMAIN + "api/homeadmin/carts-statistics";
var USERS_STATISTICS = DOMAIN + "api/homeadmin/users-statistics";
var ORDER_STATISTICS = DOMAIN + "api/homeadmin/order-cart-statistics";
var TOTAL_ACCESS = DOMAIN + "api/homeadmin/total-access";

var STATISTICS_ACCESS = DOMAIN + "api/Statistic/statistics-access";
var STATISTICS_USER = DOMAIN + "api/Statistic/statistics-user";
var STATISTICS_ORDER = DOMAIN + "api/Statistic/statistics-order";
var TOTAL_ORDER = DOMAIN + "api/Statistic/statistics-order-total";
//Manager product
var INSERT_PRODUCT = DOMAIN + "api/productadmin/insert-product";
var GET_PRODUCT_PAGING = DOMAIN + "api/productadmin/getproduct-paging";
var UPDATE_PRODUCT = DOMAIN + "api/productadmin/update-product";
var GET_PRODUCT_BYID = DOMAIN + "api/productadmin/get-product-byid";
var DELETE_PRODUCT = DOMAIN + "api/productadmin/delete-productbyid";
//Manager Provider
var INSERT_PROVIDER = DOMAIN + "api/ProviderAdmin/insert-provider";
var GET_PROVIDER_PAGINGATE = DOMAIN + "api/ProviderAdmin/getprovider-paging";
var DELETE_PROVIDER = DOMAIN + "api/ProviderAdmin/delete-provider";
var GET_ALL_PROVIVER = DOMAIN + "api/ProviderAdmin/get-all-provider";
//Manager Category
var INSERT_CATEGORY = DOMAIN + "api/CategoryAdmin/insert-category";
var GET_CATEGORY_PAGING = DOMAIN + "api/CategoryAdmin/get-categories-paging";
var DELETE_CATEGORY = DOMAIN + "api/CategoryAdmin/delete-category";
var GET_ALL_CATEGORY = DOMAIN + "api/CategoryAdmin/get-all-category";
//Manager Product type
var INSERT_PRODUCT_TYPE = DOMAIN + "api/ProductTypeAdmin/inssert-product-type";
var GET_PRODUCT_TYPE_PAGING = DOMAIN + "api/ProductTypeAdmin/get-product-type-paging";
var DELETE_PRODUT_TYPE = DOMAIN + "api/ProductTypeAdmin/delete-product-type";
var GET_PRODUCT_TYPE = DOMAIN + "api/producttypeadmin/get-all-product-type";
//Manager Units
var GET_ALL_UNITS = DOMAIN + "api/unitadmin/get-all-unit";
var INSERT_UNIT = DOMAIN + "api/unitadmin/insert-unit";
var GET_UNIT_PAGING = DOMAIN + "api/unitadmin/get-unit-paging";
//Manager status
var INSERT_STATUS_PROVIDER = DOMAIN + "api/StatusProvider/insert-status-provider";
var GET_ALL_STATUS_PROVIDER = DOMAIN + "api/StatusProvider/get-all-status-provider";
var INSERT_STATUS_PRODUCT = DOMAIN + "api/StatusProduct/insert-status-products";
var GET_ALL_STATUS_PRODUCT = DOMAIN + "api/StatusProduct/get-all-status-products";
var INSERT_STATUS_CART = DOMAIN + "api/StatusCarts/insert-status-cart";
//Roles Manager
var INSERT_ROLES = DOMAIN + "api/RolesAdmin/insert-roles";
var GET_ALL_ROLES = DOMAIN + "api/RolesAdmin/get-all-roles"
//User Admin Manager
var INSERT_USER_ADMIN = DOMAIN + "api/UserAdmin/create-user";
//Blogs
var CREATED_BLOGS = DOMAIN + "api/Blogs/created-blogs";
//Orders
var GET_ORDERS_PAGING = DOMAIN + "api/OrderAdmin/get-order-paging";
var DETAILS_ORDER = DOMAIN + "api/OrderAdmin/order-details"
//Manager user client
var GET_USER_CLIENTPAGING = DOMAIN + "api/ManagerUserClient/get-userclient-infor"

var renderAPI = {
    postAPI: function (url, async, method, data, callbackSuccess, callbackError) {
        $.ajax({
            method: method,
            url: url,
            contentType: "application/json; charset=utf-8",
            data: data,
            async: async,
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Authorization", "Bearer " + localStorage.getItem("access_token"));
            },
            success: function (result) {
                callbackSuccess(result);
            },
            error: function (jqXHR, exception) {
                callbackError(jqXHR, exception);
            }
        })
    },
    uploadImage: function (url, async, method, data, callbackSuccess, callbackError) {
        $.ajax({
            method: method,
            url: url,
            contentType: "application/json; charset=utf-8",
            data: data,
            async: async,
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Authorization", "Bearer" + localStorage.getItem("access_token"));
            },
            success: function (result) {
                callbackSuccess(result);
            },
            error: function (jqXHR, exception) {
                callbackError(jqXHR, exception);
            }
        })
    },
    isWorking: function (result) {
        $(result).parent().parent().addClass("isWorking");
    },
    isWorkingDropdownList: function (result) {
        $(result).addClass('isWorking');
    }
}

$(document).ready(function () {
    $('.btn-logout').click(function () {
        debugger
        localStorage.removeItem("access_token");
        window.location.href = DOMAIN + "AccountAdmin/Login";
    })
})