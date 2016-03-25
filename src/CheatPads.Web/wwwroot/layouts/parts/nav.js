define(["system", "config", "ko"], function (system, config, ko) {
    return {
        routes: config.routes,
        currentHash: ko.computed(function () {
            var route = system.currentRoute();
            return route ? route.hash : config.startPage;
        })
    };
});