define(["config", "ajax", "storage"], function (config, ajax, storage) {
    var model = {},
        cacheKey = "cached_credentials";

    model.creds = {
        username: "",
        password: "",
        remember: false
    },

    model.init = function (params) {
        var cachedCreds = storage.get(cacheKey);
        if (cachedCreds) {
            model.creds = cachedCreds;
        }
    }

    model.login = function (data) {
        if (data.creds.remember) {
            storage.set(cacheKey, data.creds);
        }
        else {
            storage.remove(cacheKey);
        }

        ajax.post("https://localhost:44345/connect/authorize?scope=CheatPads.Api")
        .fail(function (msg) {
            var x = msg;
        })
        .done(function(msg){
            var x = msg;
        });
    }

    return model;
});