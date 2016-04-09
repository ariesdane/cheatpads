define(["ko", "ajax", "services/cart"], function(ko, ajax, cart){
    return {
        cartVisible: ko.observable(false),
        cartCount: cart.count,
        cartCost: cart.cost,
        cartTax: cart.tax,
        cartTotal: cart.total,
        cartItems: cart.items,
        cartIsEmpty: ko.pureComputed(function(){
            return cart.count() == 0;
        }),
        toggleCartDetails: function () {
            this.cartVisible(!this.cartVisible());
        },
        removeItem: cart.remove
    }
});