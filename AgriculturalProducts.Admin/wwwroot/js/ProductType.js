$(document).ready(function () {
    $(callAjaxProductType.getProductTypePaging);
    $('.btn-get-data-produt-type').click(callAjaxProductType.getProductTypePaging);
    $('.btn-add-productType').click(callAjaxProductType.insertProductType);
    $('.btn-search-infor-product-type').click(callAjaxProductType.getProductTypePaging);
    $('.product-type tbody').on('click', '.btn-edit-productType', callAjaxProductType.editProductType);
    $('.product-type tbody').on('click', '.btn-delete-productType', callAjaxProductType.deleteProductType);
    $('.product-type tbody').on('click', '.btn-view-productType', callAjaxProductType.viewProductType);
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
        console.log("error: " + jqXHR + "exception: " + exception);
    },
    dataProductTypePaging: function (result) {
        $('.product-type tbody').html('');
        $('.total-pages-productType').text(result.data.paging.totalPages);
        $.each(result.data.items, function (index, value) {
            var query = '<tr>' +
                '<td id="product-type-id" hidden>' + value.id + '</td>' +
                '<td>' + value.code + '</td>' +
                '<td>' + value.name + '</td>' +
                '<td>' +
                '<button type="button" class="btn btn-secondary btn-sm btn-edit-productType mr-1">Sửa</button>' +
                '<button type="button" class="btn btn-success btn-sm btn-delete-productType mr-1">Xóa</button>' +
                '<button type="button" class="btn btn-danger btn-sm btn-view-productType">Xem</button>' +
                '</td>' +
                '</tr>';
            $('.product-type tbody').append(query);
        })
    },
    errorGetProductTypePaging: function (jqXHR, exception) {
        console.log("error: " + jqXHR + "exception: " + exception);
    },
    editProductType: function () {
        $('.product-type tbody tr').removeClass('isWorking');
        $(renderAPI.isWorking(this))
    },
    deleteProductType: function () {
        $('.product-type tbody tr').removeClass('isWorking');
        $(renderAPI.isWorking(this));
        var checkIsWorking = $(".product-type tbody").find("isWorking");
        if (checkIsWorking) {
            var productTypeId = $('.isWorking #product-type-id').text();
            var data = {
                id: productTypeId
            }
            var array = [];
            array.push(data);
            $(renderAPI.postAPI(DELETE_PRODUT_TYPE, true, 'post', JSON.stringify(array), callAjaxProductType.getProductTypePaging, callAjaxProductType.errorDeleteProductType))
        } else {
            console.log("Lỗi provider");
        }
    },
    viewProductType: function () {
        $('.product-type tbody tr').removeClass('isWorking');
        $(renderAPI.isWorking(this));
        var checkIsWorking = $(".product-type tbody").find("isWorking");
        if (checkIsWorking) {
            var productTypeId = $('.isWorking #product-type-id').text();
            var data = {
                id: productTypeId
            }
            var array = [];
            array.push(data);
            $(renderAPI.postAPI(DELETE_PRODUT_TYPE, true, 'post', JSON.stringify(array), callAjaxProductType.getProductTypePaging, callAjaxProductType.errorDeleteProductType))
        } else {
            console.log("Lỗi provider");
        }
    },
    errorDeleteProductType: function (jqXHR, exception) {
        console.log("error: " + jqXHR + "exception: " + exception);
    }
}