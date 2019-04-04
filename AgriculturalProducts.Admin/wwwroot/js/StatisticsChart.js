$(document).ready(function () {
    $(callAjaxStatisticsChart.renderChartStatisticsAccess);
    $(callAjaxStatisticsChart.renderChartStatisticsUser);
    $(callAjaxStatisticsChart.renderChartStatisticsOrder);
});

var callAjaxStatisticsChart = {
    renderChartStatisticsAccess: function () {
        $(renderAPI.postAPI(STATISTICS_ACCESS, true, 'post', null, callAjaxStatisticsChart.dataChartStatisticsAccess, callAjaxStatisticsChart.errorChartStatisticsAccess))
    },
    dataChartStatisticsAccess: function (result) {
        $(callAjaxStatisticsChart.chartColumn("flot-line-chart", result.data, 'Thống kê truy cập theo ngày'));
    },
    errorChartStatisticsAccess: function (xhr, status) {
        if (xhr.status === 401) {
            window.location.href = DOMAIN + "AccountAdmin/Login";
        }
        else if (xhr.status == 500) {
            window.location.href = DOMAIN + "Home/ServerInternal";
        } else if (xhr.status == 403) {
            window.location.href = DOMAIN + "Home/AccessDenine";
        } else {
            console.log(xhr);
        }
    },
    renderChartStatisticsUser: function () {
        $(renderAPI.postAPI(STATISTICS_USER, true, 'post', null, callAjaxStatisticsChart.dataChartStatisticsUser, callAjaxStatisticsChart.errorChartStatisticsUser))
    },
    dataChartStatisticsUser: function (result) {
        $(callAjaxStatisticsChart.chartColumn("flot-line-chart-user", result.data, 'Thống kê tình hình đăng ký tài khoản theo ngày'));
    },
    errorChartStatisticsUser: function (xhr, status) {
        if (xhr.status === 401) {
            window.location.href = DOMAIN + "AccountAdmin/Login";
        }
        else if (xhr.status == 500) {
            window.location.href = DOMAIN + "Home/ServerInternal";
        } else if (xhr.status == 403) {
            window.location.href = DOMAIN + "Home/AccessDenine";
        } else {
            console.log(xhr);
        }
    },
    renderChartStatisticsOrder: function () {
        $(renderAPI.postAPI(STATISTICS_ORDER, true, 'post', null, callAjaxStatisticsChart.dataChartStatisticsOrder, callAjaxStatisticsChart.errorChartStatisticsOrder))
    },
    dataChartStatisticsOrder: function (result) {
        $(callAjaxStatisticsChart.chartLine("flot-line-chart-order", result.data, "Thống kê đơn hàng theo ngày"));
    },
    errorChartStatisticsOrder: function (xhr, status) {
        if (xhr.status === 401) {
            window.location.href = DOMAIN + "AccountAdmin/Login";
        }
        else if (xhr.status == 500) {
            window.location.href = DOMAIN + "Home/ServerInternal";
        } else if (xhr.status == 403) {
            window.location.href = DOMAIN + "Home/AccessDenine";
        } else {
            console.log(xhr);
        }
    },
    chartColumn: function (element, data, text) {
        var chart = new CanvasJS.Chart(element, {
            title: {
                text: text
            },
            data: [
                {
                    type: "column",
                    dataPoints: data
                }
            ]
        });
        chart.render();
    },
    chartLine: function (element, data, text) {
        var chart = new CanvasJS.Chart(element, {
            animationEnabled: true,
            theme: "light2",
            title: {
                text: text
            },
            axisY: {
                includeZero: false
            },
            data: [{
                type: "line",
                dataPoints: data
            }]
        });
        chart.render();
    }
}