define(["services/cart"], function(cart){
    return {
        cartCount: cart.count,
        cartCost: cart.cost,
        cartTax: cart.tax,
        cartTotal: cart.total,
        cartItems: cart.items
    }
});