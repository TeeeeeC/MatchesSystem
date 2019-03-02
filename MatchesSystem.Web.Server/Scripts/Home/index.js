(function (matches) {
    var PAGE_SIZE = 15;

    for (var i = 0; i < matches.length; i += 1) {
        matches[i].StartDate = toJavaScriptDate(matches[i].StartDate);
    }

    var matchHubProxy = $.connection.matchHub,
        dataSource = new kendo.data.DataSource({ data: matches, pageSize: PAGE_SIZE }),
        viewModel = kendo.observable({ matches: dataSource });

    $("#matches-pager").kendoPager({
        dataSource: dataSource
    });

    kendo.bind($("#matches-listview"), viewModel);

    $.connection.hub.start().done(function () { });

    matchHubProxy.client.updateMatches = function (matchesData) {
        viewModel.set('matches', matchesData);
    };

    function toJavaScriptDate(value) {
        var pattern = /Date\(([^)]+)\)/,
            results = pattern.exec(value),
            d = new Date(parseFloat(results[1])),
            formattedDate = d.getDate() + "-" + (d.getMonth() + 1) + "-" + d.getFullYear(),
            hours = (d.getHours() < 10) ? "0" + d.getHours() : d.getHours(),
            minutes = (d.getMinutes() < 10) ? "0" + d.getMinutes() : d.getMinutes(),
            formattedTime = hours + ":" + minutes;

        return formattedDate + " " + formattedTime;
    }
})(matches);