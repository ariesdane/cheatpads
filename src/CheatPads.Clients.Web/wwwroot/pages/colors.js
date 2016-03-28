define(["ko", "ajax"], function (ko, ajax) {
    var model = {};
    
    model.colors = ko.observableArray();
    
    model.init = function () {
        ajax.get("colors").done(function (data) {
            model.colors(data);
        });
    }
    
    model.addColor = function () {

    }

    return model;
});