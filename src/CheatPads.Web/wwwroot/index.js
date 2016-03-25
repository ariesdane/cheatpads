requirejs.config({
    paths: {
        'ko': 'lib/knockout/dist/knockout',
        'jquery': 'lib/jquery/dist/jquery',
        'text': 'lib/requirejs-text/text',
        'system': 'app/system',
        'config': 'app/config'
    },
    shim: {
        'jquery': { exports: 'jQuery' }
    },
    urlArgs: +new Date
});

define(["ko", "system", "config"], function (ko, system, config) {
    // configure application
    system
        .initRouting({
            routes: config.routes,
            pageHost: config.pageHost,
            homePage: config.startPage
        })
        .initWidgets(config.widgets)
        .log("Bootstrap Ok");
 
    // must call apply bindings for ko to bind widgets 
    ko.applyBindings({});
    system.log("Bindings Ok");

    // load default view
    system.navigate(location.hash)
        .fail(function () { system.error("Application Failure") })
        .done(function () { system.assert("Application Ok") });
});