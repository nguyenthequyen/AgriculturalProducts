$(document).ready(function () {
    $('.btn-add-roles').click(callAjaxRoles.insertRoles);
})

var callAjaxRoles = {
    insertRoles: function () {
        var data = $('.roles-name').val();
        debugger
        var roles = {
            Name: data
        }
        $(renderAPI.postAPI(INSERT_ROLES, true, 'post', JSON.stringify(roles), callAjaxRoles.getRolesPaging, callAjaxRoles.errorInsertRoles));
    },
    getRolesPaging: function (result) {
        console.log("Thêm thành công");
    },
    errorInsertRoles: function (xhr, status) {
        debugger
    }
}