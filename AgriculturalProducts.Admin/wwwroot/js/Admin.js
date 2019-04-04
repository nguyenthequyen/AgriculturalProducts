$(document).ready(function () {
    var newURL = window.location.protocol + "//" + window.location.host + "/" + window.location.pathname + window.location.search;
    $('.btn-roles').click(callAjaxUserAdmin.loadDataRoles);
    $('.list-roles').on('click', 'a', callAjaxUserAdmin.addDataRoles);
    $('.btn-add-user').click(callAjaxUserAdmin.insertUserAdmin);
    $(callAjaxUserAdmin.dataUsersAdminPaging);
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
        $(renderAPI.postAPI(GET_USER_ADMIN, true, 'post', null, callAjaxUserAdmin.successUsersAdminPaging, callAjaxUserAdmin.errorUsersAdminPaging))
    },
    errorInsertUsersAdmin: function (xhr, status) {
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
    successUsersAdminPaging: function (result) {
        $('.user-admin tbody').html('');
        $.each(result.data, function (index, value) {
            var html = '<tr>' +
                '<th>' + value.userName + '</th>' +
                '<th>' + value.roleName + '</th>' +
                '<th>' +
                '<button type="button" class="btn btn-secondary btn-sm btn-edit-stproduct mr-1" data-toggle="modal" data-target=".bd-stproduct-manager-modal-lg">Sửa</button>' +
                '</th>' +
                '</tr>';
            $('.user-admin tbody').append(html);
        });
    },
    errorUsersAdminPaging: function (xhr, status) {
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
    }
}