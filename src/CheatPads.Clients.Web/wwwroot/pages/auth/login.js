define(["system", "config", "storage"], function (system, config, storage) {
    var model = {};
    var scope = "userEvents";

    model.init = function (params) {
        var accessToken = storage.get("accessToken") || _getQueryParam("access_token"),
            returnUrl = (params || {}).returnUrl || storage.get("returnUrl");

        if (accessToken) {
            system.log("Access Token Obtained", accessToken);

            storage.set("accessToken", accessToken);
            system.navigate(params.returnUrl);
        }
        else {
            system.log("Authentication Required", returnUrl);

            storage.set("returnUrl", returnUrl);
            location.href = config.auth.loginUrl + "?" +
                "client_id=" + encodeURI(config.auth.clientId) + "&" +
                "response_type=" + encodeURI(config.auth.responseType) + "&" +
                "redirect_uri=" + encodeURI("http://localhost:61739/") + "&" +
                "scope=" + encodeURI(scope) + "&" +
                "state=" + encodeURI(+new Date);
        }
    }

    function _getQueryParam(name) {
        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)", "gi"),
        results = regex.exec(location.search);
        return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    }

    return model;
});