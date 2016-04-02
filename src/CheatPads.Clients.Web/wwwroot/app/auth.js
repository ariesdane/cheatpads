define(["system", "config", "storage", "base64", "jquery", "ko"], function (system, config, storage, base64, $, ko) {
    
    var _loginUrl = config.auth.loginUrl + "?" +
            "client_id=" + encodeURI(config.auth.clientId) + "&" +
            "scope=" + encodeURI(config.auth.scope) + "&" +
            "response_type=" + encodeURI(config.auth.responseType) + "&" +
            "redirect_uri=" + encodeURI(config.auth.loginUrlReturn) + "&" +
            "state=" + encodeURI(+new Date),

        _logoutUrl = config.auth.logoutUrl + "?" +
            "post_logout_redirect_uri=" +  encodeURIComponent(config.auth.logoutUrlReturn),

        _emptyIdentity = {
            protocol: {},
            token: undefined,
            id: undefined,
            userName: "",
            email: "",
            roles: []
        },
        _identity = ko.observable(_emptyIdentity),
        _authenticated = ko.observable(false);

    function _createIdentity(token) {
        var tokenParts = token.split("."),
            meta = JSON.parse(base64.decode(tokenParts[0])),
            claims = JSON.parse(base64.decode(tokenParts[1])),
            identity = {
                meta: meta,
                token: token,
                id: claims.sub[0],
                userName: claims.sub[1],
                displayName: claims.preferred_username,
                firstName: claims.given_name,
                lastName: claims.family_name,
                fullName: claims.name,
                gender: claims.gender,
                email: claims.email,
                roles: claims.role,
                issued: claims.auth_time,
                expires: claims.exp
            };
        _identity(identity);
        _authenticated(true);
    }

    function _getQueryParam (name) {
        var regex = new RegExp("[\\?&#]" + name + "=([^&]*)", "gi"), results = regex.exec(location);
        return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    }

    return {
        authenticated: _authenticated,
        identity: _identity,
        login: function () {
            system.log("Redirecting to Login.", _loginUrl);

            storage.set("post_login_url", location.hash);
            location.href = _loginUrl;
        },
        logout: function () {
            system.log("Logout & Removed Identity", _identity().userName);

            _identity(_emptyIdentity);
            _authenticated(false);

            storage.remove("access_token");
            location.href = _logoutUrl;
        },
        setBearerToken: function () {
            $.ajaxSetup({
                beforeSend: function (xhr) {
                    //xhr.setRequestHeader('Authorization', _authenticated()
                    //    ? "Bearer " + _identity().accessToken
                    //    : "Basic " + base64.encode(config.auth.clientId)
                    //);
                    if (_authenticated()) {
                        xhr.setRequestHeader('Authorization', "Bearer " + storage.get("access_token"));
                    }
                }
            });
        },
        init: function(){
            var accessToken = _getQueryParam("access_token"),
                cachedToken = storage.get("access_token");

            if (accessToken) {
                _createIdentity(accessToken);
            
                storage.set("access_token", accessToken);
                system.log("Created User Identity", _identity().userName);

                location.href = storage.get("post_login_url");
            }
            else if(cachedToken) {
                _createIdentity(cachedToken);

                if (_authenticated()) {
                    system.log("Loaded Cached Identity", _identity().userName);
                }
            }
        }
    }
});