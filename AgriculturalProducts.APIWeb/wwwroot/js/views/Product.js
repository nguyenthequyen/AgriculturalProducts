$(document).ready(function () {
    $(callAjaxProduct.callAjaxNewProduct)
});

var callAjaxProduct = {
    callAjaxNewProduct: function () {
        $(renderAPI.postAPI(GET_NEW_PRODUCT, true, 'post', null, callAjaxProduct.dataNewProduct, callAjaxProduct.errorNewProduct));
    },
    dataNewProduct: function (result) {
        var data = result.data;
        console.log(data);
        $('.new-product').html('');
        $.each(data, function (index, value) {
            console.log(value.image);

            var query = '<div class="col-md-3 col-lg-3 col-sm-4 col-xs-12">' +
                '<div class="product-thumb">' +
                '<div class="image">' +
                '<a href="shop.html">' +
                '<img src=' + callAjaxProduct.displayImage(value.image[1].path) + ' alt="image" title="image" class="img-responsive" />' +
                '</a>' +
                '<div class="onhover1">' +
                '<div class="button-group">' +
                '<button class="btn-icon" type="button"><i class="icon_piechart"></i></button>' +
                '<button class="icons" type="button"><i class="icon_cart_alt"></i></button>' +
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
                '<p class="price"><span>$15.00</span> $10.00</p>' +
                '</div>' +
                '</div>' +
                '</div>';
            $('.new-product').append(query);
        });
    },
    errorNewProduct: function () {

    },
    dataImage: function (result) {
        console.log(result.data)
    },
    errorImage: function () {

    },
    displayImage: function (f) {
        function imgchange(f) {
            var filePath = f;
            var reader = new FileReader();
            reader.onload = function (e) {
                $('.img-responsive').attr('src', e.target.result);
            };
            reader.readAsDataURL(f.files[0]);
        }
    }
}
