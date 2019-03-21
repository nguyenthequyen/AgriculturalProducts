$(document).ready(function () {
    //$('.btn-get-categories').click(callAjaxCategories.getCategories);
    //$('.list-category').on('click', 'li', callAjaxCategories.getProductByCategories);
    $(callAjaxProductByCategiry.getProductByCategoriesViews);
});
var callAjaxProductByCategiry = {
    getProductByCategoriesViews: function () {
        var name = GetURLParameter('categoriesId');
        debugger
        var data = {
            id: name
        }
        $(renderAPI.postAPI(GET_PRODUCT_BYCATEGORIES, true, 'post', JSON.stringify(data), callAjaxProductByCategiry.dataProductByCategoriesViews, callAjaxProductByCategiry.errorProductByCategoriesViews));
    },
    dataProductByCategoriesViews: function (result) {
        $('.list-product').html('');
        debugger
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
    errorProductByCategoriesViews: function (xhr, status) {

    }
}