define(["services/products", "services/cart", "app/dialog"], function (products, cart, dialog) {
    var model = {};

    model.products = [].concat(products.anime, products.popular).sort(
        function (a, b) {
            return a.title < b.title ? -1 : 1;
        }
    )

    model.addToCart = function (data) {
        cart.add(data);
        //dialog.toast.success(data.sku + " added to cart");
    }

    return model;
})