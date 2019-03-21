$(document).ready(function () {
    $('.btn-get-categories').click(callAjaxCategories.getCategories);
    $('.list-category').on('click', 'li', callAjaxCategories.getProductByCategories);
    $(callAjaxCategories.getProductByCategoriesViews);
});

var callAjaxCategories = {
    getCategories: function () {
        $(renderAPI.postAPI(GET_ALL_CATEGORIES, true, 'post', null, callAjaxCategories.dataCategories, callAjaxCategories.errorCategories));
    },
    dataCategories: function (result) {
        $('.list-category').html('');
        $.each(result.data, function (index, value) {
            var html = '<li>' +
                '<p href="#" class="categoriesId" hidden>' + value.id + '</p> ' +
                '<a href="#">' + value.name + '</a>' +
                '</li>';
            $('.list-category').append(html);
        })
    },
    errorCategories: function (xhr, status) {
        console.log(xhr)
    },
    getProductByCategories: function () {
        $(renderAPI.isWorkingDropdownList(this));
        var isWorking = $('.list-category').find('.isWorking');
        if (isWorking) {
            var id = $('.isWorking').find('.categoriesId').text();
            window.location.href = DOMAIN + "Product/Categories?categoriesId=" + id;
        }
    },
}