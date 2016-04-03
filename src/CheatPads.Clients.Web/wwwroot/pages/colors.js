define(["ko", "ajax", "config"], function (ko, ajax, config) {
    var model = {};
    
    model.colors = ko.observableArray();
    
    model.init = function () {
        ajax.get(config.apis.ecomm + "/colors").done(function (data) {
            model.colors(data);
        });
    }
    
    model.addColor = function () {

    }

    return model;
});