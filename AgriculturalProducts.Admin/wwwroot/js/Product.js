$(document).ready(function () {
    $('.btn-insert-product'.click(callAjaxProductAdmin.insertProduct));
});

var callAjaxProductAdmin = Object.create({
    //Thống kê sản phẩm
    insertProduct: function () {
        debugger
        var productName = $(".insertProduct").find(".product-name").text();
        var productCode = $(".insertProduct").find(".product-code").text();
        var productQuanlity = $(".insertProduct").find(".product-quanlity").text();
        var productCost = $(".insertProduct").find(".product-cost").text();
        var productStatus = $(".insertProduct").find(".product-status").text();
        var productMass = $(".insertProduct").find(".product-mass").text();
        var productCategoryId = $(".insertProduct").find(".product-category-id").text();
        var productTypeId = $(".insertProduct").find(".product-type-id").text();
        var providerId = $(".insertProduct").find(".provider-id").text();
        var productSale = $(".insertProduct").find(".product-sale").text();
        var product = {
            name=productName,
            code=productCode,
            quantity=productQuanlity,
            cost=productCost,
            status=productStatus,
            mass=productMass,
            categoryId=productCategoryId,
            providerId=providerId,
            typeTypeId=productTypeId,
            saleId=productSale
        }
        $(renderAPI.postAPI(INSERT_PRODUCT, true, 'post', JSON.stringify(product), callAjaxAPI.dataProductStatistics, function () {
        }));
    },
    dataProductStatistics: function (result) {
        $('.product-statistics').text(result.data);
    }
})