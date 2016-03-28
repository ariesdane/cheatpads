define(["ko", "ajax", "config"], function (ko, ajax, config) {
    var model = {};
    
    model.colors = ko.observableArray();
    
    model.init = function () {
        ajax.get("https://localhost:44390/api/colors").done(function (data) {
            model.colors(data);
        });
    }
    
    return model;
});