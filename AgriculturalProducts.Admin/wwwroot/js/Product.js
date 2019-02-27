$(document).ready(function () {
    $(callAjaxProductAdmin.getProductPaging);
    $('.btn-insert-product').click(callAjaxProductAdmin.insertProduct);
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
            categoryId: '1BD43901-F349-4DFD-070B-08D69BCA2A1E'/*productCategoryId*/,
            providerId: '17ebcbaa-fbf5-4124-b277-59d02fe70de8'/*providerId*/,
            productTypeId: '57DCDEE9-4088-45A5-ABD6-2C7E7F9A13CE'/*productTypeId*/,
            sale: productSale,
            unitId: '8fc1e9d6-14c2-4f8d-9d73-d6424e213e66',
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
            pageNumber: 1,
            pageSize: 1,
            searchString: ""
        }
        debugger
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
                '<button type="button" class="btn btn-secondary btn-sm">Sửa</button>' +
                '<button type="button" class="btn btn-success btn-sm">Xóa</button>' +
                '<button type="button" class="btn btn-danger btn-sm">Xem</button>' +
                '</td>' +
                '</tr>';
            $('.product tbody').append(query);
        });
    },
    errorGetProductPagingNate: function () {
    }
}