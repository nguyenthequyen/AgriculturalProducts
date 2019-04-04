$(document).ready(function () {
    $('.btn-login').click(callAjaxAccount.accountLogin);
});
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
    },
    dataUserInfor: function (result) {
    },
    errorGetUserInfor: function (xhr, status) {
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