$(document).ready(function () {
    $(callAjaxSearchProduct.searchByName);
})
var callAjaxSearchProduct = {
    searchByName: function () {
        var name = localStorage.getItem("name_product");
        var data = {
            name: name
        }
        $(renderAPI.postAPI(SEARCH_PRODUCT, true, 'post', JSON.stringify(data), callAjaxSearchProduct.dataAfterFintProduct, callAjaxSearchProduct.errorAfterFindProduct));
    },
    dataAfterFintProduct: function (result) {
        $('.list-product').html('');
        $.each(result.data, function (index, value) {
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
                '<h4><a href="shop.html">' + value.name + '</a></h4>' +
                '<p class="price">' + formatNumber(value.cost, ',', '.') + ' VNĐ' + '</p>' +
                '</div>' +
                '</div>' +
                '</div>';
            $('.list-product').append(query);
        });
    },
    errorAfterFindProduct: function (jqXHR, exception) {
        if (xhr.status == 500) {
            window.location.href = DOMAIN + "Home/ServerInternal";
        } else {
            console.log(xhr);
        }
    }
}