$(document).ready(function () {
    $('.btn-add-status-product').click(callAjaxStatusAdmin.insertStatusProduct);
    $('.btn-add-status-provider').click(callAjaxStatusAdmin.insertStatusProvider);
    $('.btn-add-status-cart').click(callAjaxStatusAdmin.insertStatusCartr);
    $(callAjaxStatusAdmin.getStatusCartPaging);
    $(callAjaxStatusAdmin.getStatusCartPaging);
    $(callAjaxStatusAdmin.getStatusCartPaging);
    $(callAjaxStatusAdmin.getStatusprovidertPaging);
    $(callAjaxStatusAdmin.getStatusProductPaging);
})
var callAjaxStatusAdmin = {
    insertStatusProvider: function () {
        var statusName = $('.status-provider-name').val();
        var statusProvider = {
            name: statusName
        }
        var statusProviders = [];
        statusProviders.push(statusProvider);
        $(renderAPI.postAPI(INSERT_STATUS_PROVIDER, true, 'post', JSON.stringify(statusProviders), callAjaxStatusAdmin.getStatusprovidertPaging, callAjaxStatusAdmin.errorStatusProvider));
    },
    getStatusprovidertPaging: function () {
        $(renderAPI.postAPI(GET_ALL_STATUS_PROVIDER, true, 'post', null, callAjaxStatusAdmin.successGetStatusProvider, callAjaxStatusAdmin.errorGetStatusProvider));
    },
    errorStatusProvider: function (xhr, status) {
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
    successGetStatusProvider: function (result) {
        $('.status-provider tbody').html('');
        $.each(result.data, function (index, value) {
            debugger
            var html = '<tr>' +
                '<th>' + value.name + '</th>' +
                '<th>' +
                '<button type="button" class="btn btn-secondary btn-sm btn-edit-stprovider mr-1" data-toggle="modal" data-target=".bd-stprovider-manager-modal-lg">Sửa</button>' +
                '</th>' +
                '</tr>';
            $('.status-provider tbody').append(html);
        });
    },
    errorGetStatusProvider: function (xhr, status) {
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
    insertStatusProduct: function () {
        var statusName = $('.status-product-name').val();
        var statusProduct = {
            name: statusName
        }
        var statusProducts = [];
        statusProducts.push(statusProduct);
        $(renderAPI.postAPI(INSERT_STATUS_PRODUCT, true, 'post', JSON.stringify(statusProducts), callAjaxStatusAdmin.getStatusProductPaging, callAjaxStatusAdmin.errorStatusProduct));
    },
    getStatusProductPaging: function () {
        $(renderAPI.postAPI(GET_ALL_STATUS_PRODUCT, true, 'post', null, callAjaxStatusAdmin.successGetAllStatusProduct, callAjaxStatusAdmin.errorGetAllStatusProduct));
    },
    errorStatusProduct: function (xhr, status) {
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
    successGetAllStatusProduct: function (result) {
        $('.status-product tbody').html('');
        $.each(result.data, function (index, value) {
            var html = '<tr>' +
                '<th>' + value.name + '</th>' +
                '<th>' +
                '<button type="button" class="btn btn-secondary btn-sm btn-edit-stproduct mr-1" data-toggle="modal" data-target=".bd-stproduct-manager-modal-lg">Sửa</button>' +
                '</th>' +
                '</tr>';
            $('.status-product tbody').append(html);
        });
    },
    errorGetAllStatusProduct: function (xhr, status) {
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
    insertStatusCartr: function () {
        var statusName = $('.status-cart-name').val();
        var statusProduct = {
            name: statusName
        }
        $(renderAPI.postAPI(INSERT_STATUS_CART, true, 'post', JSON.stringify(statusProduct), callAjaxStatusAdmin.getStatusCartPaging, callAjaxStatusAdmin.errorStatusCart));
    },
    getStatusCartPaging: function (result) {
        $(renderAPI.postAPI(GET_STATUS_CART, true, 'post', null, callAjaxStatusAdmin.successGetStatusCart, callAjaxStatusAdmin.errorGetStatusCart));
    },
    errorStatusCart: function (jqXHR, exception) {
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
    successGetStatusCart: function (result) {
        $('.status-order tbody').html('');
        $.each(result.data, function (index, value) {
            var html = '<tr>' +
                '<th>' + value.name + '</th>' +
                '<th>' +
                '<button type="button" class="btn btn-secondary btn-sm btn-edit-stproduct mr-1" data-toggle="modal" data-target=".bd-stproduct-manager-modal-lg">Sửa</button>' +
                '</th>' +
                '</tr>';
            $('.status-order tbody').append(html);
        });
    },
    errorGetStatusCart: function (xhr, status) {
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