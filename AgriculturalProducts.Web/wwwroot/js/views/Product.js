$(document).ready(function () {
    $(callAjaxProduct.callAjaxNewProduct);
    $(callAjaxProduct.callAjaxDiscountProducts);
    $('.list-product').on('click', '.icons.cart-icon', callAjaxProduct.addProductToCart);
    $('.list-product').on('click', '.caption.text-center', callAjaxProduct.getDetailsProducts);
    $('.btn-search').on('click', callAjaxProduct.searchProducctByName);

});

var callAjaxProduct = {
    callAjaxNewProduct: function () {
        $(renderAPI.postAPI(GET_NEW_PRODUCT, true, 'post', null, callAjaxProduct.dataNewProduct, callAjaxProduct.errorNewProduct));
    },
    dataNewProduct: function (result) {
        var data = result.data;
        $('.list-product').html('');
        $.each(data, function (index, value) {
            var query = '<div class="col-md-3 col-lg-3 col-sm-4 col-xs-12 product">' +
                '<div class="product-thumb">' +
                '<div class="image">' +
                '<a>' +
                '<img src="' + value.image[0].path + '" alt="image" title="image" class="img-responsive" />' +
                '</a>' +
                '<div class="onhover1">' +
                '<div class="button-group">' +
                '<button class="icons cart-icon" type="button"><i class="icon_cart_alt"> <span hidden>' + value.id + '</span></i></button>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '<div class="caption text-center">' +
                '<h4><a style="cursor:pointer;">' + value.name + '</a></h4>' +
                '<p class="price">' + formatNumber(value.cost, ',', '.') + ' VNĐ' + '</p>' +
                '</div>' +
                '</div>' +
                '</div>';
            $('.list-product').append(query);
        });
    },
    errorNewProduct: function (xhr) {
        if (xhr.status == 500) {
            window.location.href = DOMAIN + "Home/ServerInternal";
        } else {
            console.log(xhr);
        }
    },
    callAjaxDiscountProducts: function () {
        $(renderAPI.postAPI(LIST_TOP_DISCOUNT_PRODUCT, true, 'post', null, callAjaxProduct.dataDiscountProduct, callAjaxProduct.errorDiscountProduct));
    },
    dataDiscountProduct: function (result) {
        $('.product-discount').html('');
        var data = result.data;
        $.each(data, function (index, value) {
            var query = '<div class="col-md-3 col-lg-3 col-sm-4 col-xs-12 product">' +
                '<div class="product-thumb">' +
                '<div class="image">' +
                '<a>' +
                '<img src="' + value.image[0].path + '" alt="image" title="image" class="img-responsive" />' +
                '</a>' +
                '<div class="onhover1">' +
                '<div class="button-group">' +
                '<button class="icons cart-icon" type="button"><i class="icon_cart_alt"> <span hidden>' + value.id + '</span></i></button>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '<div class="caption text-center">' +
                '<h4><a href="#">' + value.name + '</a></h4>' +
                '<p class="price">' + formatNumber(value.cost, ',', '.') + ' VNĐ' + '</p>' +
                '</div>' +
                '</div>' +
                '</div>';
            $('.product-discount').append(query);
        });
    },
    errorDiscountProduct: function (xhr) {
        if (xhr.status == 500) {
            window.location.href = DOMAIN + "Home/ServerInternal";
        } else {
            console.log(xhr);
        }
    },
    addProductToCart: function () {
        $('.list-product').find('.product-thumb').removeClass('isWorking');
        $(renderAPI.isWorking(this))
        var isWorking = $('.list-product').find('isWorking');
        if (isWorking) {
            var id = $('.isWorking').find('.icon_cart_alt').find('span').text();
            var data = {
                id: id
            }
            $(renderAPI.postAPI(ADD_TO_CARTS, true, 'post', JSON.stringify(data), callAjaxProduct.dataAfterAddCarts, callAjaxProduct.errorAfterAddCarts));
        }
        else {

        }
    },
    dataAfterAddCarts: function (result) {
        console.log(result);
    },
    errorAfterAddCarts: function (xhr, exception) {
        if (xhr.status == 500) {
            window.location.href = DOMAIN + "Home/ServerInternal";
        } else {
            console.log(xhr);
        }
    },
    getDetailsProducts: function () {
        $('.list-product').find('.product-thumb').removeClass('isWorking');
        $(renderAPI.isWorkingDetailsCart(this))
        var isWorking = $('.list-product').find('isWorking');
        if (isWorking) {
            var id = $('.isWorking').prev().find('span').text();
            var data = {
                id: id
            }
            $(renderAPI.postAPI(PRODUCT_DETAILS, true, 'post', JSON.stringify(data), callAjaxProduct.dataAfterDetailsProduct, callAjaxProduct.errorAfterAddCarts));
        }
        else {

        }
    },
    dataAfterDetailsProduct: function (results) {
        $.each(results.data, function (index, value) {
            window.location.href = DOMAIN + "Product/Details?productId=" + value.id;
        })
    },
    searchProducctByName: function () {
        var data = {
            name: $('.txt-text-search').val()
        }
        $(renderAPI.postAPI(SEARCH_PRODUCT, true, 'post', JSON.stringify(data), callAjaxProduct.dataAfterSearch, callAjaxProduct.errorSearchProduct));
    },
    dataAfterSearch: function (result) {
        var name = $('.txt-text-search').val();
        localStorage.setItem('name_product', name);
        window.location.href = DOMAIN + "Product/SearchProduct?name=" + name;
    },
    errorSearchProduct: function (xhr, status) {
        if (xhr.status == 500) {
            window.location.href = DOMAIN + "Home/ServerInternal";
        } else {
            console.log(xhr);
        }
    }
}