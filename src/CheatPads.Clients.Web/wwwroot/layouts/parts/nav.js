define(["system", "auth", "config", "jquery", "ko", "services/seek"], function (system, auth, config, $, ko, seek) {

    function getMenuItems(name) {
        return seek(config.menus[name])
            .innerJoin(config.routes, { hash: "hash" }, function (a, b) {
                return $.extend({}, b, a);
            }).result;
    }

    return {
        testMenuVisible: ko.observable(false),
        siteMenuItems: getMenuItems("site"),
        testMenuItems: getMenuItems("test"),
        currentHash: ko.computed(function () {
            var route = system.currentRoute();
            return route ? route.hash : config.startPage;
        }),
        userMessage: ko.computed(function(){
            return auth.authenticated()
                ? "Welcome, " + auth.identity().userName
                : "Browsing as Guest";
        }),
        testMenuSelect: function (item) {
            location.href = item.hash;
        }
    };
});