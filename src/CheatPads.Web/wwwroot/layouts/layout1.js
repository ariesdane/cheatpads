define(["system", "config"], function(system, config){
    var model = {};

    model.routes = config.routes;

    model.currentHash = ko.computed(function () {
        var route = system.currentRoute();
        return route ? route.hash : config.startPage;
    })

    return model;
});