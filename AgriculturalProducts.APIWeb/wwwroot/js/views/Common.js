//Product Client
var GET_NEW_PRODUCT = "api/Product/list-new-product";
var LIST_TOP_DISCOUNT_PRODUCT = "api/Product/list-top-discount-product";
var PRODUCT_DETAILS = "http://localhost:51277/api/product/get-product-details"
//Account
var REGISTER = "http://localhost:51277/api/account/create-user";
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
                jqXHR.setRequestHeader('Authorization', 'Bearer ' + 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIiLCJqdGkiOiI1MWM0NWQwZC1lN2RlLTQ1NWYtYTM1ZC1lYjIxMjhhNTI1ZjgiLCJVc2VybmFtZSI6Im5ndXllbnRoZXF1eWVuIiwiRW1haWwiOiJuZ3V5ZW50aGVxdXllbjEzQGdtYWlsLmNvbSIsIkxhc3ROYW1lIjoiTmd1eeG7hW4gdGjhur8gIiwiRmlyc3ROYW1lIjoiUXV54buBbiIsIlJvbGVzSWQiOiJlMDRjYjJmNC1jN2IyLTQxYTYtYWRkYy0xYWJjZTNhZjk5MTkiLCJVc2VySWQiOiJhYWY3OGQyYy0wZjM5LTRjNzMtODE3My1jZTBhMGRhNzc0OWMiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJVc2VycyIsImV4cCI6MTU1MjQxMDEwNiwiaXNzIjoiSnd0Um9sZUJhc2VkQXV0aCIsImF1ZCI6Ikp3dFJvbGVCYXNlZEF1dGgifQ.eYqHjNDeJYgaYIFcQaIApGWfMws8_OAOXvoyhy6zjas')
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