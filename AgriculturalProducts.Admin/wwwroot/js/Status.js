$(document).ready(function () {
    $('.btn-add-status-product').click(callAjaxStatusAdmin.insertStatusProduct);
    $('.btn-add-status-provider').click(callAjaxStatusAdmin.insertStatusProvider);
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

    },
    errorStatusProvider: function () {

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

    },
    errorStatusProduct: function () {

    }
}