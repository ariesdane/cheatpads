define(["jquery", "ko", "ajax", "storage", "./products"], function ($, ko, ajax, storage, products) {
    var model = {};
    var order = ko.observable({});

    model.init = function () {
        var id = storage.get("cartId");
        if (id) {
            ajax.ecomm.get("cart", id).as(order);
        }
        return model;
    }


    model.items = ko.pureComputed(function () {
        return order().items || [];
    });

    model.count = ko.pureComputed(function () {
        return order().itemCount || 0;
    });

    model.cost = ko.pureComputed(function () {
        return round(order().extendedCost, 2);
    })

    model.tax = ko.pureComputed(function () {
        return round(order().tax, 2);
    });

    model.taxRate = ko.pureComputed(function () {
        return round(order().taxRate * 100, 1);
    });

    model.total = ko.pureComputed(function () {
        return round(order().totalCost, 2);
    });

    model.add = function (product) {
        var data = {
            item: {
                orderId: storage.get("cartId"),
                productSku: product.sku,
                colorId: 2,
                quantity: 1
            }
        }

        ajax.ecomm.post("cart/items", data).done(function (result) {
            storage.set("cartId", result.id);
            order(result);
        });
    };

    model.remove = function (item) {
        var id = storage.get("cartId");

        ajax.ecomm.delete("cart/items", item.id).done(function (result) {
            order(result);
        });
    };

    model.clear = function () {
        var id = storage.get("cartId");

        ajax.ecomm.delete("cart", id).done(function (result) {
            order({});
        })
    };


    function round(n, d) {
        var s = n ? String(Math.round(n * 1000000000000) / 1000000000000).split(".") : ["0", "000000000000"];
        return s[0] + "." + (s[1] + '000000000000').substring(0, d || 2);
    }

    return model.init();
});