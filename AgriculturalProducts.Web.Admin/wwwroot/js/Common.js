var PRODUCT_STATISTICS = "/api/homeadmin/product-statistics";
var INSERT_PRODUCT = "/api/productadmin/insert-product";

var renderAPI = {
    postAPI: function (url, async, method, data, callbackSuccess, callbackError) {
        $.ajax({
            method: method,
            url: url,
            dataType: 'json',
            data: data,
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Authorization", "Beare" + localStorage.getItem("access_token"));
            },
            success: function (result) {
                callbackSuccess(result);
            },
            error: function (jqXHR, exception) {
                callbackError
            }
        })
    },
}