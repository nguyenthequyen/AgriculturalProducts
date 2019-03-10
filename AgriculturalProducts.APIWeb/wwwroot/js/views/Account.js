$(document).ready(function () {
    $('.btn-register').click(callAjaxAccount.registerAccount)
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
        $(renderAPI.postAPI(REGISTER, true, 'post', JSON.stringify(data), callAjaxAccount.createdUserSuccess, callAjaxAccount.errorCreatedUser))
    },
    createdUserSuccess: function () {
        window.location.href = "http://localhost:51277/Account/Login";
    },
    errorCreatedUser: function (jqXHR, exception) {

    }
}