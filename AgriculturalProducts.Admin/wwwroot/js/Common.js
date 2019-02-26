//Statistics
var PRODUCT_STATISTICS = "/api/homeadmin/product-statistics";
var PROVIDER_STATISTICS = "api/homeadmin/provider-statistics";
var PRODUCT_TYPE_STATISTICS = "api/homeadmin/product-type-statistics"
var CATEGORY_STATISTICS = "api/homeadmin/category-statistics";
var CARTS_STATISTICS = "api/homeadmin/carts-statistics";
var USERS_STATISTICS = "api/homeadmin/users-statistics";
//Manager product
var INSERT_PRODUCT = "/api/productadmin/insert-product";
//Manager Provider
var INSERT_PROVIDER = "api/prodiveradmin/insert-provider";
var GET_PROVIDER_PAGINGATE = "api/prodiveradmin/getprovider-paging";
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
                callbackError(jqXHR)
            }
        })
    },
}