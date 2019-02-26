$(document).ready(function () {
    $(callAjaxProductType.getProductTypePaging);
    $('.btn-get-data-produt-type').click(callAjaxProductType.getProductTypePaging);
    $('.btn-add-productType').click(callAjaxProductType.insertProductType);
    $('.btn-search-infor-product-type').click(callAjaxProductType.getProductTypePaging);
})

var callAjaxProductType = {
    insertProductType: function () {
        var productTypeName = $('.product-type-name').val();
        var productTypeCode = $('.product-type-code').val();
        var productType = {
            code: productTypeCode,
            name: productTypeName
        }
        var productTypies = [];
        productTypies.push(productType);
        $(renderAPI.postAPI(INSERT_PRODUCT_TYPE, true, 'post', JSON.stringify(productTypies), callAjaxProductType.getProductTypePaging, callAjaxProductType.errorInsertProductType))
    },
    getProductTypePaging: function (result) {
        var pageSize = $('.page-size-produt-type').val();
        var pageNumber = $('.page-number-produt-type').val();
        var searchString = $('.search-produt-type').val();
        var pagingParams = {
            pageNumber: pageNumber,
            pageSize: pageSize,
            searchString: searchString
        }
        $(renderAPI.postAPI(GET_PRODUCT_TYPE_PAGING, true, 'post', JSON.stringify(pagingParams), callAjaxProductType.dataProductTypePaging, callAjaxProductType.errorGetProductTypePaging))
    },
    errorInsertProductType: function (jqXHR, exception) {
        debugger
        console.log("error: " + jqXHR + "exception: " + exception);
    },
    dataProductTypePaging: function (result) {
        $('.product-type tbody').html('');
        $('.total-pages-productType').text(result.data.paging.totalPages);
        $.each(result.data.items, function (index, value) {
            var query = '<tr>' +
                '<td>' + value.code + '</td>' +
                '<td>' + value.name + '</td>' +
                '<td>' +
                '<button type="button" class="btn btn-secondary btn-sm">Sửa</button>' +
                '<button type="button" class="btn btn-success btn-sm">Xóa</button>' +
                '<button type="button" class="btn btn-danger btn-sm">Xem</button>' +
                '</td>' +
                '</tr>';
            $('.product-type tbody').append(query);
        })
    },
    errorGetProductTypePaging: function (jqXHR, exception) {
        console.log("error: " + jqXHR + "exception: " + exception);
    }
}