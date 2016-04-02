define(["ajax"], function (ajax) {
    return {     
        getAll: function(){
            return ajax.get("products");
        },
        getDetails: function(sku){
            return ajax.get("products", sku);
        },
        getByCategory: function(name){
            return ajax.get("products/cat", name);
        },
        getCategories: function(){
            return ajax.get("categories");
        }
    }
});