$(document).ready(function () {
    $(callAjaxProductAdmin.getProductPaging);
    $('.btn-insert-product').click(callAjaxProductAdmin.insertProduct);
    $('.btn-search-product').click(callAjaxProductAdmin.getProductPaging);
    $('.product tbody').on('click', '.btn-edit-product', callAjaxProductAdmin.editProduct);
    $('.product tbody').on('click', '.btn-delete-product', callAjaxProductAdmin.deleteProduct);
    $('.product tbody').on('click', '.btn-view-product', callAjaxProductAdmin.viewProduct);
    $('.btn-category').on('click', callAjaxProductAdmin.loadAllCategory);
    $('.btn-product-type').on('click', callAjaxProductAdmin.loadAllProductType);
    $('.btn-provider').on('click', callAjaxProductAdmin.loadAllProvider);
    $('.btn-unit').on('click', callAjaxProductAdmin.loadAllUnit);
    $('.list-product-type').on('click', 'a', callAjaxProductAdmin.addDatatDropdowListProductType);
    $('.list-provider').on('click', 'a', callAjaxProductAdmin.addDatatDropdowListProvider);
    $('.list-category').on('click', 'a', callAjaxProductAdmin.addDatatDropdowListCategory);
    $('.list-unit').on('click', 'a', callAjaxProductAdmin.addDataUnit);
    $('.list-status').on('click', 'a', callAjaxProductAdmin.addDataStatus);
});

var callAjaxProductAdmin = {
    //Thống kê sản phẩm
    insertProduct: function () {
        var productName = $("#insertProduct").find(".product-name").val();
        var productCode = $("#insertProduct").find(".product-code").val();
        var productQuanlity = $("#insertProduct").find(".product-quanlity").val();
        var productCost = $("#insertProduct").find(".product-cost").val();
        var productStatus = $("#insertProduct").find(".product-status").val();
        var productMass = $("#insertProduct").find(".product-mass").val();
        var productCategoryId = $("#insertProduct").attr("details-id-category");
        var productTypeId = $("#insertProduct").attr("details-id-productType");
        var providerId = $("#insertProduct").attr("details-id-provider");
        var productSale = $("#insertProduct").find(".product-sale").val();
        var unitId = $("#insertProduct").attr("details-id-category");
        var shortDescription = $("#insertProduct").find(".product-shortDescription").val();
        var fullDescription = $("#insertProduct").find(".product-fullDescription").val();
        var product = {
            name: productName,
            code: productCode,
            quantity: productQuanlity,
            cost: productCost,
            status: productStatus,
            mass: productMass,
            categoryId: productCategoryId,
            providerId: providerId,
            productTypeId: productTypeId,
            sale: productSale,
            unitId: unitId,
            shortDescription: shortDescription,
            fullDescription: fullDescription
        }
        debugger
        var products = [];
        products.push(product);
        $(renderAPI.postAPI(INSERT_PRODUCT, true, 'post', JSON.stringify(products), callAjaxProductAdmin.getProductPaging, callAjaxProductAdmin.errorInsertProduct));
    },
    dataProductStatistics: function (result) {
        $('.product-statistics').text(result.data);
    },
    errorInsertProduct: function () {

    },
    getProductPaging: function () {
        var pageSize = $('.page-size-product').val();
        var pageNumber = $('.page-number-product').val();
        var searchString = $('.search-product').val();
        var pagingParams = {
            pageNumber: pageNumber,
            pageSize: pageSize,
            searchString: searchString
        }
        $(renderAPI.postAPI(GET_PRODUCT_PAGING, true, 'post', JSON.stringify(pagingParams), callAjaxProductAdmin.dataProduct, callAjaxProductAdmin.errorGetProductPagingNate))
    },
    dataProduct: function (result) {
        $('.total-pages-product').text(result.data.paging.totalPages);
        $('.product tbody').html('');
        $.each(result.data.items, function (index, value) {
            var query = '<tr>' +
                '<td id="product-id" hidden>' + value.id + '</td>' +
                '<td>' + value.code + '</td>' +
                '<td>' + value.name + '</td>' +
                '<td>' + value.status + '</td>' +
                '<td>' + value.cost + '</td>' +
                '<td>' + value.quantity + '</td>' +
                '<td>' + value.unitId + '</td>' +
                '<td>' +
                '<button type="button" class="btn btn-secondary btn-sm btn-edit-product">Sửa</button>' +
                '<button type="button" class="btn btn-success btn-sm btn-delete-product">Xóa</button>' +
                '<button type="button" class="btn btn-danger btn-sm btn-view-product">Xem</button>' +
                '</td>' +
                '</tr>';
            $('.product tbody').append(query);
        });
    },
    errorGetProductPagingNate: function () {
    },
    viewProduct: function () {

    },
    deleteProduct: function () {

    },
    editProduct: function () {

    },
    loadAllProvider: function () {
        $(renderAPI.postAPI(GET_ALL_PROVIVER, true, 'post', null, callAjaxProductAdmin.dataLoadAllProvider, callAjaxProductAdmin.errorLoadAllProvider))
    },
    dataLoadAllProvider: function (result) {
        $('.list-provider').html('');
        $.each(result.data, function (index, value) {
            var query = '<a class="dropdown-item" providerId="' + value.id + '">' + value.name + '</a>';
            $('.list-provider').append(query);
        });
    },
    errorLoadAllProvider: function (jqXHR, exception) {

    },
    loadAllCategory: function () {
        $(renderAPI.postAPI(GET_ALL_CATEGORY, true, 'post', null, callAjaxProductAdmin.dataLoadAllCategory, callAjaxProductAdmin.errorLoadAllCategory))
    },
    dataLoadAllCategory: function (result) {
        $('.list-category').html('');
        $.each(result.data, function (index, value) {
            var query = '<a class="dropdown-item" categoryId="' + value.id + '">' + value.name + '</a>';
            $('.list-category').append(query);
        });
    },
    errorLoadAllCategory: function (jqXHR, exception) {

    },
    loadAllProductType: function () {
        $(renderAPI.postAPI(GET_PRODUCT_TYPE, true, 'post', null, callAjaxProductAdmin.dataLoadAllProductType, callAjaxProductAdmin.errorLoadAllProductType))
    },
    dataLoadAllProductType: function (result) {
        $('.list-product-type').html('');
        $.each(result.data, function (index, value) {
            var query = '<a class="dropdown-item" productTypeId="' + value.id + '">' + value.name + '</a>';
            $('.list-product-type').append(query);
        });
    },
    errorLoadAllProductType: function (jqXHR, exception) {

    },
    loadAllUnit: function () {
        $(renderAPI.postAPI(GET_ALL_UNITS, true, 'post', null, callAjaxProductAdmin.dataLoadAllUnit, callAjaxProductAdmin.errorLoadAllUnit))
    },
    dataLoadAllUnit: function (result) {
        $('.list-unit').html('');
        $.each(result.data, function (index, value) {
            var query = '<a class="dropdown-item" unitId="' + value.id + '">' + value.name + '</a>';
            $('.list-unit').append(query);
        });
    },
    errorLoadAllUnit: function () {

    },
    addDatatDropdowListProductType: function () {
        $(renderAPI.isWorkingDropdownList(this));
        var productTypeId = $('.list-product-type').find('.isWorking').attr('productTypeId');
        var productTypeName = $('.list-product-type').find('.isWorking').text();
        $('.btn-product-type').attr('details-id-productType', productTypeId);
        $('.btn-product-type').text(productTypeName);
    },
    addDatatDropdowListProvider: function () {
        $(renderAPI.isWorkingDropdownList(this));
        var productTypeId = $('.list-provider').find('.isWorking').attr('providerId');
        var productTypeName = $('.list-provider').find('.isWorking').text();
        $('.btn-provider').attr('details-id-provider', productTypeId);
        $('.btn-provider').text(productTypeName);
    },
    addDatatDropdowListCategory: function () {
        $(renderAPI.isWorkingDropdownList(this));
        var productTypeId = $('.list-category').find('.isWorking').attr('categoryId');
        var productTypeName = $('.list-category').find('.isWorking').text();
        $('.btn-category').attr('details-id-category', productTypeId);
        $('.btn-category').text(productTypeName);
    },
    addDataUnit: function () {
        $(renderAPI.isWorkingDropdownList(this));
        var productTypeId = $('.list-unit').find('.isWorking').attr('unitId');
        var productTypeName = $('.list-unit').find('.isWorking').text();
        $('.btn-unit').attr('details-id-unit', productTypeId);
        $('.btn-unit').text(productTypeName);
    },
    addDataStatus: function () {
        $(renderAPI.isWorkingDropdownList(this));
        var productTypeId = $('.list-status').find('.isWorking').attr('statusValue');
        var productTypeName = $('.list-status').find('.isWorking').text();
        $('.btn-status').attr('details-id-unit', productTypeId);
        $('.btn-status').text(productTypeName);
    }
}