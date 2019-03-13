//Statistics
var PRODUCT_STATISTICS = "api/homeadmin/product-statistics";
var PROVIDER_STATISTICS = "api/homeadmin/provider-statistics";
var PRODUCT_TYPE_STATISTICS = "api/homeadmin/product-type-statistics"
var CATEGORY_STATISTICS = "api/homeadmin/category-statistics";
var CARTS_STATISTICS = "api/homeadmin/carts-statistics";
var USERS_STATISTICS = "api/homeadmin/users-statistics";
var ORDER_STATISTICS = "api/homeadmin/order-cart-statistics";
//Manager product
var INSERT_PRODUCT = "api/productadmin/insert-product";
var GET_PRODUCT_PAGING = "api/productadmin/getproduct-paging";
//Manager Provider
var INSERT_PROVIDER = "api/ProviderAdmin/insert-provider";
var GET_PROVIDER_PAGINGATE = "api/ProviderAdmin/getprovider-paging";
var DELETE_PROVIDER = "api/ProviderAdmin/delete-provider";
var GET_ALL_PROVIVER = "api/ProviderAdmin/get-all-provider";
//Manager Category
var INSERT_CATEGORY = "api/CategoryAdmin/insert-category";
var GET_CATEGORY_PAGING = "api/CategoryAdmin/get-categories-paging";
var DELETE_CATEGORY = "api/CategoryAdmin/delete-category";
var GET_ALL_CATEGORY = "api/CategoryAdmin/get-all-category";
//Manager Product type
var INSERT_PRODUCT_TYPE = "api/ProductTypeAdmin/inssert-product-type";
var GET_PRODUCT_TYPE_PAGING = "api/ProductTypeAdmin/get-product-type-paging";
var DELETE_PRODUT_TYPE = "api/ProductTypeAdmin/delete-product-type";
var GET_PRODUCT_TYPE = "api/producttypeadmin/get-all-product-type";
//Manager Units
var GET_ALL_UNITS = "api/unitadmin/get-all-unit";
var INSERT_UNIT = "api/unitadmin/insert-unit";
var GET_UNIT_PAGING = "api/unitadmin/get-unit-paging";
//Manager status
var INSERT_STATUS_PROVIDER = "api/StatusProvider/insert-status-provider";
var GET_ALL_STATUS_PROVIDER = "api/StatusProvider/get-all-status-provider";
var INSERT_STATUS_PRODUCT = "api/StatusProduct/insert-status-products";
var GET_ALL_STATUS_PRODUCT = "api/StatusProduct/get-all-status-products";
var INSERT_STATUS_CART = "http://localhost:57736/api/StatusCarts/insert-status-cart";
//Roles Manager
var INSERT_ROLES = "http://localhost:57736/api/RolesAdmin/insert-roles";
var GET_ALL_ROLES = "http://localhost:57736/api/RolesAdmin/get-all-roles"
//User Admin Manager
var INSERT_USER_ADMIN ="http://localhost:57736/api/UserAdmin/create-user"


var renderAPI = {
    postAPI: function (url, async, method, data, callbackSuccess, callbackError) {
        $.ajax({
            method: method,
            url: url,
            contentType: "application/json; charset=utf-8",
            data: data,
            async: async,
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Authorization", "Beare" + localStorage.getItem("access_token"));
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
                xhr.setRequestHeader("Authorization", "Beare" + localStorage.getItem("access_token"));
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