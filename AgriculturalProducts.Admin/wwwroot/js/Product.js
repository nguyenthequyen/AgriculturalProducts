$(document).ready(function () {
    $(callAjaxProductAdmin.getProductPaging);
    $('.btn-insert-product').click(callAjaxProductAdmin.insertProduct);
    $('.btn-search-product').click(callAjaxProductAdmin.getProductPaging);
    $('.product tbody').on('click', '.btn-edit-product', callAjaxProductAdmin.editProduct);
    $('.product tbody').on('click', '.btn-delete-product', callAjaxProductAdmin.deleteProduct);
    $('.product tbody').on('click', '.btn-view-product', callAjaxProductAdmin.viewProduct);
});

var callAjaxProductAdmin = {
    //Thống kê sản phẩm
    insertProduct: function () {
        debugger
        var productName = $("#insertProduct").find(".product-name").val();
        var productCode = $("#insertProduct").find(".product-code").val();
        var productQuanlity = $("#insertProduct").find(".product-quanlity").val();
        var productCost = $("#insertProduct").find(".product-cost").val();
        var productStatus = $("#insertProduct").find(".product-status").val();
        var productMass = $("#insertProduct").find(".product-mass").val();
        var productCategoryId = $("#insertProduct").find(".product-category-id").val();
        var productTypeId = $("#insertProduct").find(".product-type-id").val();
        var providerId = $("#insertProduct").find(".provider-id").val();
        var productSale = $("#insertProduct").find(".product-sale").val();
        var product = {
            name: productName,
            code: productCode,
            quantity: productQuanlity,
            cost: productCost,
            status: productStatus,
            mass: productMass,
            categoryId: 'B32956D0-162F-4D88-6CEB-08D69D8A8100'/*productCategoryId*/,
            providerId: 'DE4CF77F-8CDE-4DE7-A020-16BE0C697504'/*providerId*/,
            productTypeId: 'BCFC249E-3583-4ED0-BD37-3EDC61030DA2'/*productTypeId*/,
            sale: productSale,
            unitId: '8FC1E9D6-14C2-4F8D-9D73-D6424E213E66',
            shortDescription: "abc",
            fullDescription: "âfssf"
        }
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
        debugger
        $(renderAPI.postAPI(GET_PRODUCT_PAGING, true, 'post', JSON.stringify(pagingParams), callAjaxProductAdmin.dataProduct, callAjaxProductAdmin.errorGetProductPagingNate))
    },
    dataProduct: function (result) {
        debugger
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

    }
}