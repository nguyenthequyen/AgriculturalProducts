$(document).ready(function () {
    $('.btn-add-roles').click(callAjaxRoles.insertRoles);
    $(callAjaxRoles.getAllRoles);
})

var callAjaxRoles = {
    insertRoles: function () {
        var data = $('.roles-name').val();
        debugger
        var roles = {
            Name: data
        }
        $(renderAPI.postAPI(INSERT_ROLES, true, 'post', JSON.stringify(roles), callAjaxRoles.getAllRoles, callAjaxRoles.errorInsertRoles));
    },
    errorInsertRoles: function (xhr, status) {
        debugger
    },
    getAllRoles: function () {
        $(renderAPI.postAPI(GET_ALL_ROLES, true, 'post', null, callAjaxRoles.getRolesPaging, callAjaxRoles.errorGetRoles));
    },
    errorGetRoles: function (xhr, status) {
        if (xhr.status === 401) {
            window.location.href = DOMAIN + "AccountAdmin/Login";
        }
        else if (xhr.status == 500) {
            window.location.href = DOMAIN + "Home/ServerInternal";
        } else if (xhr.status == 403) {
            window.location.href = DOMAIN + "Home/AccessDenine";
        }
    }
}