requirejs.config({
    paths: {
        'ko': 'lib/knockout/dist/knockout',
        'jquery': 'lib/jquery/dist/jquery',
        'text': 'lib/requirejs-text/text',
        'base64': 'app/base64',
        'system': 'app/system',
        'config': 'app/config',
        'storage': 'app/storage',
        'ajax': 'app/ajax',
        'auth': 'app/auth'
    },
    shim: {
        'jquery': { exports: 'jQuery' }
    },
    urlArgs: +new Date
});

define(["ko", "system", "storage", "ajax", "auth", "config"], function (ko, system, storage, ajax, auth, config) {
    // configure application
    system
        .initRouting({
            routes: config.routes,
            pageHost: config.pageHost,
            homePage: config.startPage
        })
        .initWidgets(config.widgets)
        .log("Bootstrap Ok");
 
    // inititialize authentication
    auth.init();

    // ajax interceptors for logging & security
    ajax.interceptors.push({
        request: function (options) {
            auth.header();
            system.info("Ajax Request", options);
        },
        success: function (data) {
            system.assert("Ajax Success", data);
        },
        error: function (xhr, status, message) {
            system.error("Ajax Error", { status: status, message: message });
        },
        401: function () {
            auth.login();
        }
    })

    // api root
    ajax.setBaseUrl(config.api.baseUrl);
   
    // must call apply bindings for ko to bind widgets 
    ko.applyBindings({});
    system.log("Bindings Ok");

    
    // load default view
    system.navigate(location.hash)
        .fail(function () { system.error("Application Failure") })
        .done(function () { system.assert("Application Ok") });
});