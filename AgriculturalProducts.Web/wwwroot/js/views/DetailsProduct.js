var start = 0;
$(document).ready(function () {
    $(callAjaxDetailsProduct.detailsProducts);
    $('.btn-comment').click(callAjaxDetailsProduct.commentProducts);

    /**
     * Đánh giá 5 sao
     */

    /* 1. Visualizing things on Hover - See next part for action on click */
    $('#stars li').on('mouseover', function () {
        var onStar = parseInt($(this).data('value'), 10); // The star currently mouse on

        // Now highlight all the stars that's not after the current hovered star
        $(this).parent().children('li.star').each(function (e) {
            if (e < onStar) {
                $(this).addClass('hover');
            }
            else {
                $(this).removeClass('hover');
            }
        });

    }).on('mouseout', function () {
        $(this).parent().children('li.star').each(function (e) {
            $(this).removeClass('hover');
        });
    });


    /* 2. Action to perform on click */
    $('#stars li').on('click', function () {
        var onStar = parseInt($(this).data('value'), 10); // The star currently selected
        var stars = $(this).parent().children('li.star');

        for (i = 0; i < stars.length; i++) {
            $(stars[i]).removeClass('selected');
        }

        for (i = 0; i < onStar; i++) {
            $(stars[i]).addClass('selected');
        }

        // JUST RESPONSE (Not needed)
        var ratingValue = parseInt($('#stars li.selected').last().data('value'), 10);
        var msg = "";
        start = ratingValue;
        if (ratingValue > 1) {
            msg = "Thanks! You rated this " + ratingValue + " stars.";
        }
        else {
            msg = "We will improve ourselves. You rated this " + ratingValue + " stars.";
        }
        responseMessage(msg);

    });
    /**
     * Đánh giá 5 sao
     */
    $('.btn-rate').click(callAjaxDetailsProduct.rateProduct);
    $(callAjaxDetailsProduct.getAllComments);
    $(callAjaxDetailsProduct.getAllRates);
})
function responseMessage(msg) {
    $('.success-box').fadeIn(200);
    $('.success-box div.text-message').html("<span>" + msg + "</span>");
}
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
        console.log(result.data);
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
                '<p class="shortdes">' + value.shortDescription + '</p>' +
                '<hr>' +
                '<div class="price">' + formatNumber(value.cost, ',', '.') + ' VNĐ' + '</div>' +
                '<hr>' +
                '</div>' +
                '<div class="buttons">' +
                '<button type="button" class="btn-default"><i class="icon_cart"></i> Thêm vào giỏ hàng</button>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '</div>';
            $('.details-products').append(query);
            $('.full-description p').append(value.fullDescription);
        })
    },
    errorAfterAddCarts: function (jqXHR, exception) {
        console.log(jqXHR);
    },
    commentProducts: function () {
        var id = GetURLParameter('productId');
        var content = $('#comment').val();
        var data = {
            productId: id,
            content: content
        }
        $(renderAPI.postAPI(COMMENT_CREATED, true, 'post', JSON.stringify(data), callAjaxDetailsProduct.getAllComments, callAjaxDetailsProduct.errorAfterComment));
    },
    errorAfterComment: function (xhr, status) {
        if (xhr.status === 401) {
            window.location.href = DOMAIN + "AccountViews/Login";
        }
        else {
            console.log(xhr)
            alert("Bình luận thất bại");
        }
    },
    rateProduct: function () {
        var id = GetURLParameter('productId');
        var data = {
            quantity: start,
            productId: id
        }
        $(renderAPI.postAPI(CREATED_RATE, true, 'post', JSON.stringify(data), callAjaxDetailsProduct.getAllRates, callAjaxDetailsProduct.errorAfterRate));
    },
    errorAfterRate: function (xhr, status) {
        alert("Đánh giá sản phẩm thất bại");
    },
    getAllComments: function () {
        var id = GetURLParameter('productId');
        var data = {
            id: id
        }
        $(renderAPI.postAPI(GET_ALL_COMMENT, true, 'post', JSON.stringify(data), callAjaxDetailsProduct.dataAfterComments, callAjaxDetailsProduct.errorAfterComments));
    },
    dataAfterComments: function (result) {
        $('.pading-content-comment').html('');
        $.each(result.data, function (index, value) {
            var html = '<div class="detail">' +
                '<span class="user-name">' + value.createdBy + '</span><br />' +
                '<span class="content">' + value.content + '</span>' +
                '</div>';
            $('.pading-content-comment').append(html);
        });
    },
    errorAfterComments: function (xhr, status) {
        alert("Lấy bình luận thất bại");
        console.log(xhr);
    },
    getAllRates: function () {
        var id = GetURLParameter('productId');
        var data = {
            id: id
        }
        $(renderAPI.postAPI(GET_ALL_RATES, true, 'post', JSON.stringify(data), callAjaxDetailsProduct.dataAfterRates, callAjaxDetailsProduct.errorAfterRates));
    },
    dataAfterRates: function (result) {
        debugger
        $(callAjaxDetailsProduct.chartColumn('chart-rate', result.data, 'Thống kê đánh giá'))
    },
    errorAfterRates: function () {
        alert("Lấy đánh giá thất bại");
        console.log(xhr);
    },
    chartColumn: function (element, data, text) {
        var chart = new CanvasJS.Chart(element, {
            animationEnabled: true,
            height: 150,
            title: {
                text: text
            },
            axisX: {
                interval: 1
            },
            axisY2: {
                interlacedColor: "rgba(1,77,101,.2)",
                gridColor: "rgba(1,77,101,.1)",
            },
            data: [{
                type: "bar",
                name: "companies",
                dataPoints: data
            }]
        });
        chart.render();
    }
}