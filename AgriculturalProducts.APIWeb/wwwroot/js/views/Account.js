﻿$(document).ready(function () {
    $(callAjaxAccount.getUserInfor);
    $('.btn-register').click(callAjaxAccount.registerAccount);
    $('.btn-login').click(callAjaxAccount.loginAccount);
    $('.li-logout').on('click', callAjaxAccount.logoutAccount);
})
var callAjaxAccount = {
    registerAccount: function () {
        var userName = $('#input-username').val();
        var lastname = $('#input-lastname').val();
        var firstname = $('#input-firstname').val();
        var email = $('#input-mail').val();
        var password = $('#input-password').val();
        var confirmpassword = $('#input-confirmpassword').val();
        var data = {
            firstName: firstname,
            lastName: lastname,
            userName: userName,
            email: email,
            password: password,
            confirmpassword: confirmpassword
        }
        debugger
        $(renderAPI.postAPILogin(REGISTER, true, 'post', JSON.stringify(data), callAjaxAccount.createdUserSuccess, callAjaxAccount.errorCreatedUser));
    },
    createdUserSuccess: function () {
        window.location.href = DOMAIN + "AccountViews/Login";
    },
    errorCreatedUser: function (jqXHR, exception) {
        console.log(jqXHR);
    },
    loginAccount: function () {
        var userName = $('#input-email').val();
        var password = $('#input-password').val();
        var data = {
            userName: userName,
            password: password
        }
        $(renderAPI.postAPILogin(LOGIN, true, 'post', JSON.stringify(data), callAjaxAccount.loginUserSuccess, callAjaxAccount.errorLoginUser))
    },
    loginUserSuccess: function (result) {
        localStorage.setItem("access_token", result.data);
        window.location.href = DOMAIN;
        $(renderAPI.postAPI(GET_USER_INFOR, true, 'post', null, callAjaxAccount.dataUserInfor, callAjaxAccount.errorGetUserInfor));
    },
    errorLoginUser: function (jqXHR, exception) {
        console.log(jqXHR);
    },
    dataUserInfor: function (result) {
        if (result == null) {
            return false;
        }
        $('.username').text(result.data.userName);
        $('.des.text-center').hide();
        $('#register').hide();
        $('.login').hide();
        $('.logout').show();
    },
    errorGetUserInfor: function (jqXHR, exception) {
        console.log(jqXHR);
    },
    getUserInfor: function () {
        var local = localStorage.getItem("access_token");
        if (local === null) {
            return false;
        } else {
            $(renderAPI.postAPI(GET_USER_INFOR, true, 'post', null, callAjaxAccount.dataUserInforAutoLoad, callAjaxAccount.errorGetUserInforInforAutoLoad));
        }
    },
    dataUserInforAutoLoad: function (result) {
        if (result == null) {
            return false;
        }
        $('.username').text(result.data.userName);
        $('.des.text-center').hide();
        $('#register').hide();
        $('.li-login').hide();
        $('.li-logout').show();
    },
    errorGetUserInforInforAutoLoad: function (jqXHR, exception) {
        console.log(jqXHR);
    },
    logoutAccount: function () {
        localStorage.removeItem('access_token');
        $('.username').text('');
        $('.des.text-center').show();
        $('#register').show();
        $('.li-login').show();
        $('.li-logout').hide();
        window.location.reload();
    }
}