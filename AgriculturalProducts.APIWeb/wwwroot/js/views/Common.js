var DOMAIN = "https://localhost:44307/";
//Product Client
var GET_NEW_PRODUCT = "api/Product/list-new-product";
var LIST_TOP_DISCOUNT_PRODUCT = "api/Product/list-top-discount-product";
var PRODUCT_DETAILS = DOMAIN + "api/product/get-product-details";
var SEARCH_PRODUCT = DOMAIN + "api/product/find-product-by-name";
//Account
var REGISTER = DOMAIN + "api/account/create-user";
var LOGIN = DOMAIN + "api/account/login";
var GET_USER_INFOR = DOMAIN + "api/account/get-users-infor";
//Carts
var ADD_TO_CARTS = DOMAIN + "api/Carts/add-product-to-carts";
var SET_QUANTITY_CARTS = DOMAIN + "api/Carts/get-carts-session";
var GET_CARTS_SESSION = DOMAIN + "api/Carts/get-carts-session";
var REMOVE_CARTS_SESION = DOMAIN + "api/Carts/remove-carts";
//Order
var ORDER_NOW = DOMAIN + "api/Order/order-now";
var GET_BLOGS = DOMAIN + "api/BlogsClient/get-top-blogs";
//COMMENT
var COMMENT_CREATED = DOMAIN + "api/comment/created-comment";
var GET_ALL_COMMENT = DOMAIN + "api/Comment/get-comment-byproductId";
//RATE
var CREATED_RATE = DOMAIN + "api/Rates/created-rates";
var GET_ALL_RATES = DOMAIN + "api/rates/get-all-rates";

function formatNumber(nStr, decSeperate, groupSeperate) {
    nStr += '';
    x = nStr.split(decSeperate);
    x1 = x[0];
    x2 = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1)) {
        x1 = x1.replace(rgx, '$1' + groupSeperate + '$2');
    }
    return x1 + x2;
}

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
    postAPILogin: function (url, async, method, data, callbackSuccess, callbackError) {
        $.ajax({
            method: method,
            url: url,
            contentType: "application/json; charset=utf-8",
            data: data,
            async: async,
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
function GetURLParameter(sParam) {
    var sPageURL = window.location.search.substring(1);
    var sURLVariables = sPageURL.split('&');
    for (var i = 0; i < sURLVariables.length; i++) {
        var sParameterName = sURLVariables[i].split('=');
        if (sParameterName[0] == sParam) {
            return sParameterName[1];
        }
    }
}