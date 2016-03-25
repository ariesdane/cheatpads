define(["app/dialog", "services/cart", "services/products"], function (dialog, cart, products) {
    var model = {};

    model.anime = products.anime;
    model.popular = products.popular;

    model.addToCart = function(data) {
        //dialog.toast.success(data.sku + " added to cart");
        cart.add(data);
    }

    model.shop = function () {
        dialog.modal.alert("This site is a prototype. These products are ficticious and are not really for sale, not here anyway. However, if you search around the web then you never know, it's possible they could be sold somewhere else. <br><br>If you have any feedback, comments, or suggestions then please contact: <br><br>admin@cheatpads.com")
    }

    return model;
})