﻿define(["system", "config", "storage", "jquery", "ko"], function (system, config, storage, $, ko) {
    
    var _loginUrl = config.auth.loginUrl + "?" +
            "client_id=" + encodeURI(config.auth.clientId) + "&" +
            "scope=" + encodeURI(config.auth.scope) + "&" +
            "response_type=" + encodeURI(config.auth.responseType) + "&" +
            "redirect_uri=" + encodeURI(config.auth.loginUrlReturn) + "&" +
            "state=" + encodeURI(+new Date);

    var _logoutUrl = config.auth.logoutUrl + "?" +
            "post_logout_redirect_uri=" +  encodeURIComponent(config.auth.logoutUrlReturn);

    var _identity = ko.observable({
        userName: "",
        accessToken: "",
    });

    var _authenticated = ko.observable(false);

    var _createIdentity = function (token) {
        var identity = {
            accessToken: token,
            userName: "admin" // todo: load from api
        };      
        _identity(identity);
        _authenticated(true);
        storage.set("identity", identity);
    }

    var _clearIdentity = function () {           
        _identity({
            accessToken: "",
            userName: ""
        });
        _authenticated(false);
        storage.remove("identity");
    }

    var _restoreIdentity = function () {
        var identity = storage.get("identity");
        if (identity) {
            _identity(identity);
            _authenticated(_identity.accessToken !== undefined);
        }   
    }

    var _initialize = function () {
        var accessToken = _getQueryParam("access_token");

        if (accessToken) {          
            _createIdentity(accessToken);
            system.log("Created User Identity", _identity().userName);

            location.href = storage.get("returnUrl");
        }
        else {
            _restoreIdentity();

            if (_authenticated()) {
                system.log("Obtained Cached Identity", _identity().userName);
            }
        }
    }

    var _login = function () {
        system.log("Redirecting to Login.", _loginUrl);

        storage.set("returnUrl", location.hash);
        location.href = _loginUrl;
    }

    var _logout = function () {
        system.log("Logout & Removed Identity", _identity().userName);

        _clearIdentity();
        location.href = _logoutUrl;
    }

    var _header = function () {
        if (_authenticated()) {
            $.ajaxSetup({
                beforeSend: function (xhr) {
                    xhr.setRequestHeader('Authorization', 'Bearer ' + _identity().accessToken);
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
        logout: _logout,
        header: _header,
        authenticated: _authenticated,
        identity: _identity,
        init: _initialize
    }
});