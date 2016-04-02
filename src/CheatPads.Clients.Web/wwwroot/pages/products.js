define(["services/products", "services/cart", "app/dialog", "ko"], function (products, cart, dialog, ko) {
    var model = {};

    model.products = ko.observableArray();

    model.init = function () {
        products.getAll().as(model.products);
    }

    model.addToCart = function (data) {
        cart.add(data);
        //dialog.toast.success(data.sku + " added to cart");
    }

    return model;
})