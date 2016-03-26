requirejs.config({
    paths: {
        'ko': 'lib/knockout/dist/knockout',
        'jquery': 'lib/jquery/dist/jquery',
        'text': 'lib/requirejs-text/text',
        'system': 'app/system',
        'config': 'app/config',
        'ajax': 'app/ajax'
    },
    shim: {
        'jquery': { exports: 'jQuery' }
    },
    urlArgs: +new Date
});

define(["ko", "system", "ajax", "config"], function (ko, system, ajax, config) {
    // configure application
    system
        .initRouting({
            routes: config.routes,
            pageHost: config.pageHost,
            homePage: config.startPage
        })
        .initWidgets(config.widgets)
        .log("Bootstrap Ok");
 
    // ajax interceptors for logging & security
    ajax.interceptors.push({
        request: function (options) {
            system.info("Ajax Request", options);
        },
        success: function (data) {
            system.assert("Ajax Success", data);
        },
        error: function (xhr, status, message) {
            system.error("Ajax Error", { status: status, message: message });
        }
    })

    // must call apply bindings for ko to bind widgets 
    ko.applyBindings({});
    system.log("Bindings Ok");

    
    // load default view
    system.navigate(location.hash)
        .fail(function () { system.error("Application Failure") })
        .done(function () { system.assert("Application Ok") });
});