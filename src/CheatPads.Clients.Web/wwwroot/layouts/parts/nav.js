define(["system", "auth", "config", "jquery", "ko", "services/qlist"], function (system, auth, config, $, ko, qlist) {

    var navItems =
        qlist(config.menus.siteNav)
            .innerJoin(config.routes, { hash: "hash" }, function (a, b) {
                return $.extend({}, b, a);
            }).result;

    return {
        menuItems: navItems,
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