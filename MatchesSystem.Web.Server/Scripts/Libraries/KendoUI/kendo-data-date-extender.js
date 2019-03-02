kendo.data.binders.date = kendo.data.Binder.extend({
    init: function (element, bindings, options) {
        kendo.data.Binder.fn.init.call(this, element, bindings, options);

        this.dateformat = $(element).data("dateformat");
    },
    refresh: function () {
        var data = this.bindings["date"].get();
        if (data) {
            var dateObj = new Date(data);
            $(this.element).text(kendo.toString(dateObj, this.dateformat));
        }
    }
});