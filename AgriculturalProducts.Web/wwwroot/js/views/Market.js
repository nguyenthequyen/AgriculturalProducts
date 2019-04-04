$(document).ready(function () {
    $(callAjaxMarket.getDataMarket);
    $('.btn-get-data-market').on('click', callAjaxMarket.getDataMarket);
});
var callAjaxMarket = {
    getDataMarket: function () {
        var pageSize = $('.page-size-market').val();
        var pageNumber = $('.page-number-market').val();
        var searchString = $('.search-market').val();
        var data = {
            pageNumber: pageNumber,
            pageSize: pageSize,
            searchString: searchString
        }
        $(renderAPI.postAPI(GET_MARKET, true, 'post', JSON.stringify(data), callAjaxMarket.successGetDataMarket, callAjaxMarket.errorGetDataMarket));
    },
    successGetDataMarket: function (result) {
        $('.market tbody').html('');
        $.each(result.data.items, function (index, value) {
            var change = "";
            if (value.cost > value.costOld) {
                change = "▲";
            } else if (value.cost < value.costOld) {
                change = "▼";
            } else if (value.cost === value.costOld) {
                change = "=";
            } else {
                change = "";
            }
            var html = '<tr>' +
                '<td class="text-left">' + (index + 1) + '</td>' +
                '<td class="text-left">' + value.name + '</td>' +
                '<td class="text-center">' + formatNumber(value.cost, ',', '.') + ' VNĐ</td>' +
                '<td class="text-center">' + formatNumber(value.costOld, ',', '.') + ' VNĐ</td>' +
                '<td class="text-center">' + (value.cost / value.costOld) + ' %</td>' +
                '<td class="text-center">' + change + '</td>' +
                '</tr>';
            $('.market tbody').append(html);
        });
    },
    errorGetDataMarket: function (xhr, status) {
        if (xhr.status == 500) {
            window.location.href = DOMAIN + "Home/ServerInternal";
        } else {
            console.log(xhr);
        }
    }
}
var entityMap = {
    '&': '&amp;',
    '<': '&lt;',
    '>': '&gt;',
    '"': '&quot;',
    "'": '&#39;',
    '/': '&#x2F;',
    '`': '&#x60;',
    '=': '&#x3D;'
};
function escapeHtml(string) {
    return String(string).replace(/[&<>"'`=\/]/g, function (s) {
        return entityMap[s];
    });
}