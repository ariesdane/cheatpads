define(["ko", "services/cart"], function(ko, cart){
    return {
        cartVisible: ko.observable(false),
        cartCount: cart.count,
        cartCost: cart.cost,
        cartTax: cart.tax,
        cartTotal: cart.total,
        cartItems: cart.items,
        toggleCartDetails: function () {
            this.cartVisible(!this.cartVisible());
        }
    }
});