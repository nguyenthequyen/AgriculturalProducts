$(document).ready(function () {
    $('.btn-add-status-product').click(callAjaxStatusAdmin.insertStatusProduct);
    $('.btn-add-status-provider').click(callAjaxStatusAdmin.insertStatusProvider);
    $('.btn-add-status-cart').click(callAjaxStatusAdmin.insertStatusCartr);
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

    },
    insertStatusCartr: function () {
        var statusName = $('.status-cart-name').val();
        var statusProduct = {
            name: statusName
        }
        $(renderAPI.postAPI(INSERT_STATUS_CART, true, 'post', JSON.stringify(statusProduct), callAjaxStatusAdmin.getStatusCartPaging, callAjaxStatusAdmin.errorStatusCart));
    },
    getStatusCartPaging: function (result) {
        alert("Thêm thành công");
    },
    errorStatusCart: function (jqXHR, exception) {
        alert("Thêm thất bại");
        console.log(jqXHR);
    }
}