$(document).ready(function () {
    $(callAjaxDetailsProduct.detailsProducts);
})

var callAjaxDetailsProduct = {
    detailsProducts: function () {
        var id = GetURLParameter('productId');
        var data = {
            id: id
        }
        $(renderAPI.postAPI(PRODUCT_DETAILS, true, 'post', JSON.stringify(data), callAjaxDetailsProduct.dataAfterDetailsProduct, callAjaxDetailsProduct.errorAfterAddCarts));
    },
    dataAfterDetailsProduct: function (result) {
        $('.details-products').html('');
        console.log(result);
        $.each(result.data, function (index, value) {
            var query = '<div class="row">' +
                '<div class="col-sm-12 col-md-12 col-lg-12 col-xs-12">' +
                '<div class="row">' +
                '<div class="col-sm-4 col-md-4 col-lg-4 col-xs-12">' +
                '<a class="thumbnail" href="#"><img src="' + value.image[0].path + '" title="img" alt="img"></a>' +
                '<ul class="thumbnails list-inline">' +
                '<li class="image-additional">' +
                '<a class="thumbnail" href="#"><img src="' + value.image[0].path + '" title="img" alt="img"></a>' +
                '</li>' +
                '<li class="image-additional">' +
                '<a class="thumbnail" href="#"><img src="' + value.image[1].path + '" title="img" alt="img"></a>' +
                '</li>' +
                '<li class="image-additional">' +
                '<a class="thumbnail" href="#"><img src="' + value.image[2].path + '" title="img" alt="img"></a>' +
                '</li>' +
                '<li class="image-additional">' +
                '<a class="thumbnail" href="#"><img src="' + value.image[2].path + '" title="img" alt="img"></a>' +
                '</li>' +
                '</ul>' +
                '</div>' +
                '<div class="col-sm-8 col-md-8 col-lg-8 col-xs-12">' +
                '<h5>' + value.name + '</h5>' +
                '<div class="rating">' +
                '<i class="fa fa-star"></i>' +
                '<i class="fa fa-star"></i>' +
                '<i class="fa fa-star"></i>' +
                '<i class="fa fa-star"></i>' +
                '<i class="fa fa-star"></i>' +
                '</div>' +
                '<p class="shortdes">' + value.shortDescription + '</p>' +
                '<hr>' +
                '<div class="price">'+value.cost+'</div>' +
                '<hr>' +
                '</div>' +
                '<div class="buttons">' +
                '<button type="button" class="btn-default"><i class="icon_cart"></i> Thêm vào giỏ hàng</button>' +
                '<button type="button" class="btn-default"><i class="icon_heart"></i></button>' +
                '<button type="button" class="btn-default"><i class="icon_piechart"></i></button>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '</div>';
            $('.details-products').append(query);
        })
    },
    errorAfterAddCarts: function (jqXHR, exception) {
        console.log(jqXHR);
    }
}

function GetURLParameter(sParam) {
    var sPageURL = window.location.search.substring(1);
    var sURLVariables = sPageURL.split('&');
    for (var i = 0; i < sURLVariables.length; i++) {
        var sParameterName = sURLVariables[i].split('=');
        if (sParameterName[0] == sParam) {
            return sParameterName[1];
        }
    }
}