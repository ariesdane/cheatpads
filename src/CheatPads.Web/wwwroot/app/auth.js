define(["system", "config", "storage", "jquery"], function (system, config, storage, $) {
    
    var _loginUrl = config.auth.loginUrl + "?scope=userEvents&" +
            "client_id=" + encodeURI(config.auth.clientId) + "&" +
            "response_type=" + encodeURI(config.auth.responseType) + "&" +
            "redirect_uri=" + encodeURI(config.auth.returnUrl) + "&" +
            "state=" + encodeURI(+new Date);
    
    var _identity = {
        userName: "",
        accessToken: "",
    };

    var _loadIdentity = function (token) {
        _identity.accessToken = token;
        _identity.userName = "admin"; // todo: load from api
        storage.set("identity", _identity);
    }

    var _initialize = function () {
        var accessToken = _getQueryParam("access_token");

        _identity = storage.get("identity");

        if (accessToken) {
            system.log("Obtained Access Token", accessToken);

            _loadIdentity(accessToken);
            system.navigate(storage.get("returnUrl"));
        }
        else if(_identity && _identity.accessToken){
            system.log("Access Token Exists", _identity.accessToken);
        }
    }

    var _login = function () {
        system.log("Redirecting to Login.", _loginUrl);

        storage.set("returnUrl", location.hash);
        location.href = _loginUrl;
    }

    var _header = function () {
        if (_identity && _identity.accessToken) {
            $.ajaxSetup({
                beforeSend: function (xhr) {
                    xhr.setRequestHeader('Authorization', 'Bearer ' + _identity.accessToken);
                }
            });
        }
    }

    var _getQueryParam = function(name) {
        var regex = new RegExp("[\\?&#]" + name + "=([^&]*)", "gi"),
        results = regex.exec(location);
        return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    }

    return {
        login: _login,
        header: _header,
        identity: _identity,
        init: _initialize
    }
});