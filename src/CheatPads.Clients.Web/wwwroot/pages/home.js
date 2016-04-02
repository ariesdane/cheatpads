define(["app/dialog", "services/cart", "services/products", "ko"], function (dialog, cart, products, ko) {
    var model = {};

    model.anime = ko.observableArray();
    model.popular = ko.observableArray();

    model.init = function () {
        products.getByCategory("Popular").as(model.popular);
        products.getByCategory("Anime").as(model.anime);
    }

    model.addToCart = function(data) {
        //dialog.toast.success(data.sku + " added to cart");
        cart.add(data);
    }

    model.shop = function () {
        dialog.modal.alert("This site is a prototype. These products are ficticious and are not really for sale, not here anyway. However, if you search around the web then you never know, it's possible they could be sold somewhere else. <br><br>If you have any feedback, comments, or suggestions then please contact: <br><br>admin@cheatpads.com")
    }

    return model;
})