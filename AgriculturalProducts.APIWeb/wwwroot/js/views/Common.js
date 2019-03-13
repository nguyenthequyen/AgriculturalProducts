//Product Client
var GET_NEW_PRODUCT = "api/Product/list-new-product";
var LIST_TOP_DISCOUNT_PRODUCT = "api/Product/list-top-discount-product";
var PRODUCT_DETAILS = "http://localhost:51277/api/product/get-product-details"
//Account
var REGISTER = "http://localhost:51277/api/account/create-user";
var LOGIN = "http://localhost:51277/api/account/login";
var GET_USER_INFOR = "http://localhost:51277/api/account/get-users-infor";
//Carts
var ADD_TO_CARTS = "http://localhost:51277/api/Carts/add-product-to-carts";
var SET_QUANTITY_CARTS = "http://localhost:51277/api/Carts/get-carts-session";
var GET_CARTS_SESSION = "http://localhost:51277/api/Carts/get-carts-session";
var REMOVE_CARTS_SESION = "http://localhost:51277/api/Carts/remove-carts";
//Order
var ORDER_NOW = "http://localhost:51277/api/Order/order-now"
var renderAPI = {
    postAPI: function (url, async, method, data, callbackSuccess, callbackError) {
        $.ajax({
            method: method,
            url: url,
            contentType: "application/json; charset=utf-8",
            data: data,
            async: async,
            beforeSend: function (jqXHR) {
                jqXHR.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem("access_token"))
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
        $(result).parent().parent().parent().parent().addClass("isWorking");
    },
    isWorkingDropdownList: function (result) {
        $(result).addClass('isWorking');
    },
    isWorkingCarts: function (result) {
        $(result).parent().parent().parent().addClass("isWorking");
    },
    isWorkingDetailsCart: function (result) {
        $(result).addClass('isWorking');
    }
}