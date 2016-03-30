define(["ko", "ajax"], function (ko, ajax) {
    var model = {};

    model.products = ko.observableArray();
    model.product = ko.observable();
    model.productJSON = ko.pureComputed(function () {
        return JSON.stringify(model.product(), null, '  ')
    });

    model.init = function () {
        ajax.get("products").done(function (data) {
            model.products(data);
        });
    }

    model.select = function (data) {
        ajax.get("products", data.sku).done(function (item) {
            model.product(item);
        });
    }

    return model;
});