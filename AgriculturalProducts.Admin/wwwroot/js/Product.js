$(document).ready(function () {
    $(callAjaxProductAdmin.getProductPaging);
    $('.btn-insert-product').click(callAjaxProductAdmin.insertProduct);
    $('.btn-search-product').click(callAjaxProductAdmin.getProductPaging);
    $('.product tbody').on('click', '.btn-edit-product', callAjaxProductAdmin.editProduct);
    $('.product tbody').on('click', '.btn-delete-product', callAjaxProductAdmin.deleteProduct);
    $('.product tbody').on('click', '.btn-view-product', callAjaxProductAdmin.viewProduct);
    $('.product tbody').on('click', '.btn-upload-image', callAjaxProductAdmin.uploadImage);
    $('.btn-category').on('click', callAjaxProductAdmin.loadAllCategory);
    $('.btn-product-type').on('click', callAjaxProductAdmin.loadAllProductType);
    $('.btn-provider').on('click', callAjaxProductAdmin.loadAllProvider);
    $('.btn-unit').on('click', callAjaxProductAdmin.loadAllUnit);
    $('.btn-status-product').on('click', callAjaxProductAdmin.loadDataStatusProduct);
    $('.list-product-type').on('click', 'a', callAjaxProductAdmin.addDatatDropdowListProductType);
    $('.list-provider').on('click', 'a', callAjaxProductAdmin.addDatatDropdowListProvider);
    $('.list-category').on('click', 'a', callAjaxProductAdmin.addDatatDropdowListCategory);
    $('.list-unit').on('click', 'a', callAjaxProductAdmin.addDataUnit);
    $('.list-status-product').on('click', 'a', callAjaxProductAdmin.addDataStatus);
    $('.bd-upload-image-modal-lg').on('click', '#to-recover', function () {
        $('.bd-upload-image-modal-lg').hide();
        $('.bd-upload-image-modal-lg').removeClass("show");
    });
    $('.btn-upload-img-product').click(function () {
        var files = $('#fileInput')[0].files;
        var formData = new FormData();
        for (var i = 0; i < files.length; i++) {
            var file = files[i];
            formData.append("files", file);
        }
        $.ajax({
            url: "api/Images/upload-images",
            type: "POST",
            contentType: false,
            data: formData,
            dataType: "json",
            cache: false,
            beforeSend: function (xhr) {
                xhr.setRequestHeader("ProductId", $('.product-id').text());
            },
            processData: false,
            async: false,
            xhr: function () {
                var xhr = new window.XMLHttpRequest();
                xhr.upload.addEventListener("progress",
                    function (evt) {
                        if (evt.lengthComputable) {
                            var progress = Math.round((evt.loaded / evt.total) * 100);
                        }
                    },
                    false);
                return xhr;
            }
        })
            .success(function (data, textStatus, jqXhr) {
                alert("Uploading is done");
                $("#files").val();
            })
            .error(function (jqXhr, textStatus, errorThrown) {
                if (errorThrown === "abort") {
                    alert("Uploading was aborted");
                } else {
                    alert("Uploading failed");
                }
            })
            .always(function (data, textStatus, jqXhr) { });
    });
});

var callAjaxProductAdmin = {
    //Thống kê sản phẩm
    insertProduct: function () {
        var productName = $("#insertProduct").find(".product-name").val();
        var productCode = $("#insertProduct").find(".product-code").val();
        var productQuanlity = $("#insertProduct").find(".product-quanlity").val();
        var productCost = $("#insertProduct").find(".product-cost").val();
        var productStatus = $("#insertProduct").find('.btn-status-product').attr("details-id-status-product");
        var productMass = $("#insertProduct").find(".product-mass").val();
        var productCategoryId = $("#insertProduct").find('.btn-category').attr("details-id-category");
        var productTypeId = $("#insertProduct").find('.btn-product-type').attr("details-id-productType");
        var providerId = $("#insertProduct").find('.btn-provider').attr("details-id-provider");
        var productSale = $("#insertProduct").find(".product-sale").val();
        var unitId = $("#insertProduct").find('.btn-unit').attr("details-id-unit");
        var shortDescription = $("#insertProduct").find(".product-shortDescription").val();
        var fullDescription = $("#insertProduct").find(".product-fullDescription").val();
        var product = {
            name: productName,
            code: productCode,
            quantity: productQuanlity,
            cost: productCost,
            mass: productMass,
            categoryId: productCategoryId,
            providerId: providerId,
            productTypeId: productTypeId,
            sale: productSale,
            unitId: unitId,
            shortDescription: shortDescription,
            fullDescription: fullDescription,
            statusProductId: productStatus
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
                '<button type="button" class="btn btn-secondary btn-sm btn-edit-product mr-1">Sửa</button>' +
                '<button type="button" class="btn btn-success btn-sm btn-delete-product mr-1">Xóa</button>' +
                '<button type="button" class="btn btn-danger btn-sm btn-view-product mr-1">Xem</button>' +
                '<button type="button" class="btn btn-danger btn-sm btn-upload-image" data-target=".bd-upload-image-modal-lg">Thêm ảnh</button>' +
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
    uploadImage: function () {
        $('.product tbody tr').removeClass('isWorking');
        $(renderAPI.isWorking(this));
        var checkIsWorking = $(".product tbody").find("isWorking");
        if (checkIsWorking) {
            $('.bd-upload-image-modal-lg').show();
            $('.bd-upload-image-modal-lg').addClass("show");
            $('.product-id').text($('.isWorking #product-id').text());
        } else {
            console.log("Lỗi product");
        }
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
    loadDataStatusProduct: function () {
        $(renderAPI.postAPI(GET_ALL_STATUS_PRODUCT, true, 'post', null, callAjaxProductAdmin.dataLoadStatusProduct, callAjaxProductAdmin.errorLoadAllStatusProduct))
    },
    dataLoadStatusProduct: function (result) {
        $('.list-status-product').html('');
        $.each(result.data, function (index, value) {
            var query = '<a class="dropdown-item" statusProductId="' + value.id + '">' + value.name + '</a>';
            $('.list-status-product').append(query);
        });
    },
    errorLoadAllStatusProduct: function () {

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
        var statusProductId = $('.list-status-product').find('.isWorking').attr('statusProductId');
        var productTypeName = $('.list-status-product').find('.isWorking').text();
        $('.btn-status-product').attr('details-id-status-product', statusProductId);
        $('.btn-status-product').text(productTypeName);
    }
}