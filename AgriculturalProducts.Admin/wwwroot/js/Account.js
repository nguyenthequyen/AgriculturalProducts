$(document).ready(function () {
    $('.btn-login').click(callAjaxAccount.accountLogin);
});
var DOMAIN = "https://localhost:44387/"
var LOGIN_USER = DOMAIN + "api/UserAdmin/login";
var GET_USER_INFOR = DOMAIN + "api/UserAdmin/get-users-infor";
var callAjaxAccount = {
    accountLogin: function () {
        var data = {
            Username: $('.txt-username').val(),
            Password: $('.txt-passord').val()
        }
        $(callAjaxAccount.postAPILogin(LOGIN_USER, true, 'post', JSON.stringify(data), callAjaxAccount.successLogin, callAjaxAccount.errorLogin))
    },
    successLogin: function (result) {
        if (result.data === null) {
            alert("Đăng nhập thất bại");
        } else {
            localStorage.setItem("access_token", result.data);
            window.location.href = DOMAIN;
            $(renderAPI.postAPI(GET_USER_INFOR, true, 'post', null, callAjaxAccount.dataUserInfor, callAjaxAccount.errorGetUserInfor));
        }
    },
    errorLogin: function (xhr, status) {
        console.log(xhr);
    },
    dataUserInfor: function (result) {
        debugger
    },
    errorGetUserInfor: function (xhr, status) {
        console.log(xhr);
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
}