﻿$(document).ready(function () {
    $(callAjaxProduct.callAjaxNewProduct);
    $(callAjaxProduct.callAjaxDiscountProducts);
    $('.new-product').on('click', '.icons.cart-icon', callAjaxProduct.addProductToCart);
    $('.new-product').on('click', '.product-thumb', callAjaxProduct.getDetailsProducts);
});

var callAjaxProduct = {
    callAjaxNewProduct: function () {
        $(renderAPI.postAPI(GET_NEW_PRODUCT, true, 'post', null, callAjaxProduct.dataNewProduct, callAjaxProduct.errorNewProduct));
    },
    dataNewProduct: function (result) {
        var data = result.data;
        $('.new-product').html('');
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
                '<button class="btn-icon" type="button"><i class="icon_heart_alt"></i></button>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '<div class="caption text-center">' +
                '<h4><a href="shop.html">' + value.name + '</a></h4>' +
                '<div class="rating">' +
                '<i class="fa fa-star"></i>' +
                '<i class="fa fa-star"></i>' +
                '<i class="fa fa-star"></i>' +
                '<i class="fa fa-star-half-o"></i>' +
                '<i class="fa fa-star-o"></i>' +
                '</div>' +
                '<p class="price"><span>' + (value.sale / 100) * value.cost + '</span> ' + value.cost + '</p>' +
                '</div>' +
                '</div>' +
                '</div>';
            $('.new-product').append(query);
        });
    },
    errorNewProduct: function () {

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
                '<button class="btn-icon" type="button"><i class="icon_heart_alt"></i></button>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '<div class="caption text-center">' +
                '<h4><a href="shop.html">' + value.name + '</a></h4>' +
                '<div class="rating">' +
                '<i class="fa fa-star"></i>' +
                '<i class="fa fa-star"></i>' +
                '<i class="fa fa-star"></i>' +
                '<i class="fa fa-star-half-o"></i>' +
                '<i class="fa fa-star-o"></i>' +
                '</div>' +
                '<p class="price"><span>' + (value.sale / 100) * value.cost + '</span> ' + value.cost + '</p>' +
                '</div>' +
                '</div>' +
                '</div>';
            $('.product-discount').append(query);
        });
    },
    errorDiscountProduct: function () {

    },
    addProductToCart: function () {
        $('.new-product').find('.product-thumb').removeClass('isWorking');
        $(renderAPI.isWorking(this))
        var isWorking = $('.new-product').find('isWorking');
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
    errorAfterAddCarts: function (jqXHR, exception) {
        console.log(jqXHR);
    },
    getDetailsProducts: function () {
        $('.new-product').find('.product-thumb').removeClass('isWorking');
        $(renderAPI.isWorkingDetailsCart(this))
        var isWorking = $('.new-product').find('isWorking');
        debugger
        if (isWorking) {
            var id = $('.isWorking').find('.icon_cart_alt').find('span').text();
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
            window.location.href = "http://localhost:51277/Product/Details?productId=" + value.id;
        })
    }
}
