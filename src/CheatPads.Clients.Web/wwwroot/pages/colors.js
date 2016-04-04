define(["ko", "ajax", "config"], function (ko, ajax, config) {
    var model = {};
    
    model.colors = ko.observableArray();
    model.color = {
        name: "",
        hex: ""
    };

    model.init = function () {
        ajax.get(config.apis.ecomm + "/colors").done(function (data) {
            model.colors(data);
        });
    }
    
    model.addColor = function () {
        ajax.ecomm.post("colors", model.color).done(function (id) {
            model.colors.push({
                id: id,
                name: model.color.name,
                hex: model.color.hex
            });
        })
    }

    return model;
});