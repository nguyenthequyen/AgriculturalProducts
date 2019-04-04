$(document).ready(function () {
    $('.btn-add-roles').click(callAjaxRoles.insertRoles);
    $(callAjaxRoles.getAllRoles);
})

var callAjaxRoles = {
    insertRoles: function () {
        var data = $('.roles-name').val();
        var roles = {
            Name: data
        }
        $(renderAPI.postAPI(INSERT_ROLES, true, 'post', JSON.stringify(roles), callAjaxRoles.getAllRoles, callAjaxRoles.errorInsertRoles));
    },
    errorInsertRoles: function (xhr, status) {
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
        } else {
            console.log(xhr);
        }
    },
    getRolesPaging: function (result) {
        $('.list-roles-vies tbody').html('');
        $.each(result.data, function (index, value) {
            var html = '<tr>' +
                '<th>' + value.name + '</th>' +
                '<th>' +
                '<button type="button" class="btn btn-secondary btn-sm btn-edit-stproduct mr-1" data-toggle="modal" data-target=".bd-stproduct-manager-modal-lg">Sửa</button>' +
                '</th>' +
                '</tr>';
            $('.list-roles-vies tbody').append(html);
        });
    },
    errorGetRoles: function (xhr, status) {
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