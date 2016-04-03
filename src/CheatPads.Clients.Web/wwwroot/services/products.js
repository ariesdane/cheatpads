define(["ajax"], function (ajax) {
    return {     
        getAll: function(){
            return ajax.ecomm.get("products");
        },
        getDetails: function(sku){
            return ajax.ecomm.get("products", sku);
        },
        getByCategory: function(name){
            return ajax.ecomm.get("products/cat", name);
        },
        getCategories: function(){
            return ajax.ecomm.get("categories");
        }
    }
});