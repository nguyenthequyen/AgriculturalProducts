$(document).ready(function () {
    $('.btn-add-unit').click(callAjaxUnit.insertUnit);
    $('.btn-get-data-unit').click(callAjaxUnit.getUnitPaging);
    $(callAjaxUnit.getUnitPaging);
})

var callAjaxUnit = {
    insertUnit: function () {
        var unitName = $('.unit-name').val();
        var unitCode = $('.unit-code').val();
        var unit = {
            code: unitCode,
            name: unitName
        }
        var units = [];
        units.push(unit);
        $(renderAPI.postAPI(INSERT_UNIT, true, 'post', JSON.stringify(units), callAjaxUnit.getUnitPaging, callAjaxUnit.errorInsertUnit))
    },
    getUnitPaging: function () {
        var pageSize = $('.page-size-unit').val();
        var pageNumber = $('.page-number-unit').val();
        var searchString = $('.search-unit').val();
        var pagingParams = {
            pageNumber: pageNumber,
            pageSize: pageSize,
            searchString: searchString
        }
        $(renderAPI.postAPI(GET_UNIT_PAGING, true, 'post', JSON.stringify(pagingParams), callAjaxUnit.dataUnit, callAjaxUnit.errorGetUnitPagingNate))
    },
    dataUnit: function (result) {
        $('.total-pages-unit').text(result.data.paging.totalPages);
        $('.unit tbody').html('');
        $.each(result.data.items, function (index, value) {
            var query = '<tr>' +
                '<td id="unit-id" hidden>' + value.id + '</td>' +
                '<td>' + value.code + '</td>' +
                '<td>' + value.name + '</td>' +
                '<td>' +
                '<button type="button" class="btn btn-secondary btn-sm btn-edit-unit mr-1">Sửa</button>' +
                '<button type="button" class="btn btn-success btn-sm btn-delete-unit mr-1">Xóa</button>' +
                '<button type="button" class="btn btn-danger btn-sm btn-view-unit">Xem</button>' +
                '</td>' +
                '</tr>';
            $('.unit tbody').append(query);
        });
    },
    errorInsertUnit: function () {

    }
}