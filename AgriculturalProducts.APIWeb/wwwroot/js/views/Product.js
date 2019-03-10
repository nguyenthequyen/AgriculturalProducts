$(document).ready(function () {
    $(callAjaxProduct.callAjaxNewProduct);
    $(callAjaxProduct.callAjaxDiscountProducts);
    $('.new-product').on('click', '.icons.cart-icon', callAjaxProduct.addProductToCart)
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
                '<a href="shop.html">' +
                '<img src="' + value.image[0].path + '" alt="image" title="image" class="img-responsive" />' +
                '</a>' +
                '<div class="onhover1">' +
                '<div class="button-group">' +
                '<button class="btn-icon" type="button"><i class="icon_piechart"></i></button>' +
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
            var query = '<div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">' +
                '<div class="product-thumb1">' +
                '<div class="image">' +
                '<a href="shop.html"><img src="' + value.image[0].path + '" alt="image" title="image" class="img-responsive" /></a>' +
                '</div>' +
                '<div class="caption">' +
                '<h4>' + value.name + '</h4>' +
                '<p>Giá : <span>' + (value.sale / 100) * value.cost + '</span></p>' +
                '<div class="button-group">' +
                '<button type="button"><i class="icon_cart_alt"></i></button>' +
                '<button type="button"><i class="icon_heart_alt"></i></button>' +
                '</div>' +
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
            var carts = [];
            var productId = $('.isWorking').find('span').text();
            var productName = $('.isWorking').find('h4 a').text();
            var cost = $('.isWorking').find('.price').text();
            var img = $('.isWorking').find('img').attr("src");
            var data = JSON.parse(localStorage.getItem("carts"));
            if (data !== null) {
                $.each(data, function (index, value) {
                    if (productId == value.id) {
                        value.quantity = value.quantity + 1;
                        var product = {
                            id: productId,
                            cost: cost,
                            name: productName,
                            img: img,
                            quantity: value.quantity
                        }
                        data.push(product);
                        localStorage.setItem("carts", JSON.stringify(data));
                    } else {
                        var product = {
                            id: productId,
                            cost: cost,
                            name: productName,
                            img: img,
                            quantity: 1
                        }
                        data.push(product);
                        localStorage.setItem("carts", JSON.stringify(data));
                    }
                })
            } else {
                var product = {
                    id: productId,
                    cost: cost,
                    name: productName,
                    img: img,
                    quantity: 1
                }
                carts.push(product);
                localStorage.setItem("carts", JSON.stringify(carts));
            }
        }
        else {

        }
    }
}
