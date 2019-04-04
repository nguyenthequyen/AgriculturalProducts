$(document).ready(function () {
    $('#btn-register').on('click', callAjaxAccount.registerAccount);
})
var callAjaxAccount = {
    registerAccount: function () {
        var userName = $('#input-username').val();
        var lastname = $('#input-lastname').val();
        var firstname = $('#input-firstname').val();
        var email = $('#input-mail').val();
        var password = $('#input-password').val();
        var confirmpassword = $('#input-confirmpassword').val();
        var birthday = $('#input-BirthDay').val();
        var gender = $('#input-gender').val();
        var address = $('#input-address').val();
        var data = {
            firstName: firstname,
            lastName: lastname,
            userName: userName,
            email: email,
            password: password,
            confirmpassword: confirmpassword,
            birthday: birthday,
            gender: gender,
            address: address
        }
        $(renderAPI.postAPILogin(REGISTER, true, 'post', JSON.stringify(data), callAjaxAccount.createdUserSuccess, callAjaxAccount.errorCreatedUser));
    },
    createdUserSuccess: function () {
        window.location.href = DOMAIN + "AccountViews/Login";
    },
    errorCreatedUser: function (jqXHR, exception) {
        if (xhr.status == 500) {
            window.location.href = DOMAIN + "Home/ServerInternal";
        } else {
            console.log(xhr);
        }
    },
}