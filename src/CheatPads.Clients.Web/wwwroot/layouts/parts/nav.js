define(["system", "auth", "config", "ko"], function (system, auth, config, ko) {
    return {
        routes: config.routes,
        currentHash: ko.computed(function () {
            var route = system.currentRoute();
            return route ? route.hash : config.startPage;
        }),
        userMessage: ko.computed(function(){
            return auth.authenticated()
                ? "Welcome, " + auth.identity().userName
                : "Browsing as Guest";
        })
    };
});