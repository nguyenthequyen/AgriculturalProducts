$(document).ready(function () {
    $(callAjaxCategory.getCategoryPaging);
    $('.btn-add-category').click(callAjaxCategory.insertCategory);
    $('.btn-get-data-category').click(callAjaxCategory.getCategoryPaging);
    $('.btn-search-infor-category').click(callAjaxCategory.getCategoryPaging);
})

var callAjaxCategory = {
    insertCategory: function () {
        var categoryName = $('.category-name').val();
        var categoryCode = $('.category-code').val();
        var category = {
            code: categoryCode,
            name: categoryName
        }
        var categories = [];
        categories.push(category);
        $(renderAPI.postAPI(INSERT_CATEGORY, true, 'post', JSON.stringify(categories), callAjaxCategory.getCategoryPaging, callAjaxCategory.errorInsertCategory))
    },
    getCategoryPaging: function (result) {
        var pageSize = $('.page-size-category').val();
        var pageNumber = $('.page-number-category').val();
        var searchString = $('.search-category').val();
        var pagingParams = {
            pageNumber: pageNumber,
            pageSize: pageSize,
            searchString: searchString
        }
        $(renderAPI.postAPI(GET_CATEGORY_PAGING, true, 'post', JSON.stringify(pagingParams), callAjaxCategory.dataCategories, callAjaxCategory.errorGetCategoryPaging))
    },
    dataCategories: function (result) {
        $('.category tbody').html('');
        $('.total-pages').text(result.data.paging.totalPages);
        $.each(result.data.items, function (index, value) {
            var query = '<tr>' +
                '<td>' + value.code + '</td>' +
                '<td>' + value.name + '</td>' +
                '<td>' +
                '<button type="button" class="btn btn-secondary btn-sm btn-edit-category">Sửa</button>' +
                '<button type="button" class="btn btn-success btn-sm btn-delete-category">Xóa</button>' +
                '<button type="button" class="btn btn-danger btn-sm btn-view-category">Xem</button>' +
                '</td>' +
                '</tr>';
            $('.category tbody').append(query);
        });
    },
    errorInsertCategory: function (jqXHR, exception) {
        console.log("error: " + jqXHR + "exception: " + exception);
    },
    errorGetCategoryPaging: function (jqXHR, exception) {
        console.log("error: " + jqXHR + "exception: " + exception);
    }
}