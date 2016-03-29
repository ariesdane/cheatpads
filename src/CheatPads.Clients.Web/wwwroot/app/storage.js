define(["jquery", "base64"], function ($, base64) {

    var _removeCookie = function (key) {
        if (_getCookie(key) !== undefined) {
            _setCookie(key, '', { expires: -1 });
            return true;
        }
        return false;
    };

    var _getCookie = function (key) {
        var cookies = document.cookie.split('; ');
        for (var i = 0; i < cookies.length; i++) {
            var parts = cookies[i].split('='), name = parts.shift(), val = parts.join('=');
            if (key === name) {
                try {
                    val = base64.decode(val);
                    return JSON.parse(val);
                } catch (er) { }
            }
        }
        return undefined;
    };

    var _setCookie = function (key, data, options) {
        options = $.extend({}, options)
        if (typeof options.expires === 'number') {
            var days = options.expires, t = options.expires = new Date();
            t.setDate(t.getDate() + days);
        }
        document.cookie =
            key + '=' + base64.encode(JSON.stringify(data))
            + (options.expires ? '; expires=' + options.expires.toUTCString() : '')
            + (options.path ? '; path=' + options.path : '')
            + (options.domain ? '; domain=' + options.domain : '')
            + (options.secure ? '; secure' : '');
    };

    return {
        get: _getCookie,
        set: _setCookie,
        remove: _removeCookie
    }
});