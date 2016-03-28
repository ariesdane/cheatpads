define(["ko", "ajax"], function (ko, ajax) {
    var model = {};

    model.products = ko.observableArray();

    model.init = function () {
        ajax.get("products").done(function (data) {
            model.products(data);
        });
    }

    return model;
});