define(["jquery", "ko", "./products", "./qlist"], function ($, ko, products, qlist) {
    var model = {};

    model.taxRate = ko.observable(0.1);
    model.items = ko.observableArray();

    model.count = ko.computed(function () {
        return model.items().length;
    });

    model.cost = ko.computed(function () {
        var cost = 0;
        model.items().forEach(function (item) {
            cost += parseFloat(item.price.replace(/[^0-9\.]/g, ''));
        });
        return cost;
    });

    model.tax = ko.computed(function () {
        return model.taxRate() * model.cost();
    });

    model.total = ko.computed(function () {
        return "$" + round(model.cost() + model.tax(), 2);
    });

    model.add = function (product) {
        model.items.push(product);
    };

    model.remove = function (product) {
        qlist(model.items).remove(product);
    };

    model.clear = function () {
        items.removeAll();
    };


    function round(n, d) {
        var s = n ? String(Math.round(n * 1000000000000) / 1000000000000).split(".") : ["0", "000000000000"];
        return s[0] + "." + (s[1] + '000000000000').substring(0, d || 2);
    }

    return model;
});