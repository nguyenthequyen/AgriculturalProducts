$(document).ready(function () {
    var newURL = window.location.protocol + "//" + window.location.host + "/" + window.location.pathname + window.location.search;
    $('.btn-roles').click(callAjaxUserAdmin.loadDataRoles);
    $('.list-roles').on('click', 'a', callAjaxUserAdmin.addDataRoles);
    $('.btn-add-user').click(callAjaxUserAdmin.insertUserAdmin);
});
var callAjaxUserAdmin = {
    loadDataRoles: function () {
        $(renderAPI.postAPI(GET_ALL_ROLES, true, 'post', null, callAjaxUserAdmin.dataLoadRoles, callAjaxUserAdmin.errorLoadRoles));
    },
    dataLoadRoles: function (result) {
        $('.list-roles').html('');
        $.each(result.data, function (index, value) {
            var query = '<a class="dropdown-item" rolesId="' + value.id + '">' + value.name + '</a>';
            $('.list-roles').append(query);
        });
    },
    errorLoadRoles: function (xhr, status) {
        debugger
    },
    addDataRoles: function () {
        $(renderAPI.isWorkingDropdownList(this));
        var statusProductId = $('.list-roles').find('.isWorking').attr('rolesId');
        var productTypeName = $('.list-roles').find('.isWorking').text();
        $('.btn-roles').attr('details-roles-id', statusProductId);
        $('.btn-roles').text(productTypeName);
    },
    insertUserAdmin: function () {
        var userName = $('.user-name').val();
        var password = $('.password-user').val();
        var rolesId = $("#inserUserAdmin").find('.btn-roles').attr("details-roles-id");
        var data = {
            userName: userName,
            password: password,
            rolesId: rolesId
        }
        $(renderAPI.postAPI(INSERT_USER_ADMIN, true, 'post', JSON.stringify(data), callAjaxUserAdmin.dataUsersAdminPaging, callAjaxUserAdmin.errorInsertUsersAdmin))
    },
    dataUsersAdminPaging: function () {
        console.log("Thêm thành công");
    },
    errorInsertUsersAdmin: function (xhr, status) {

    }
}