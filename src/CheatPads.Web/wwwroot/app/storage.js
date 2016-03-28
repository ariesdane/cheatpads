define(["jquery", "app/base64"], function ($, base64) {

    var _removeCookie = function (key, options) {
        if ($.cookie(key) !== undefined) {
            $.cookie(key, '', $.extend({}, options, { expires: -1 }));
            return true;
        }
        return false;
    };


    var _getCookie = function (key) {
        var cookies = document.cookie.split('; '), result = {};
        for (var i = 0; i < cookies.length; i++) {
            var parts = cookies[i].split('='), name = parts.shift(), val = parts.join('=');
            try {
                val = base64.decode(val);
                val = JSON.parse(val);
            } catch (er) { }
            if (!key) result[name] = val;
            else if (key === name) return val;
        }
        return !key ? result : undefined;
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

    /*
    var _getCookie = function (key) {
        var cookies = document.cookie.split('; '), result = {};
        for (var i = 0; i < cookies.length; i++) {
            var parts = cookies[i].split('='), name = parts.shift(), val = parts.join('=');
            try {
                if (val[0] === '"') val = val.slice(1, -1).replace(/\\"/g, '"').replace(/\\\\/g, '\\');
                if (val.length > 5 && val.substr(1, 5) === '"c$v"') val = JSON.parse(val).c$v;
            } catch (er) { }
            if (!key) result[name] = val;
            else if (key === name) return val;
        }
        return !key ? result : undefined;
    };

    var _setCookie = function (key, data, options) {
        options = $.extend({}, options)
        if (typeof options.expires === 'number') {
            var days = options.expires, t = options.expires = new Date();
            t.setDate(t.getDate() + days);
        }
        document.cookie =
            key + '=' + JSON.stringify({ c$v: data })
            + (options.expires ? '; expires=' + options.expires.toUTCString() : '')
            + (options.path ? '; path=' + options.path : '')
            + (options.domain ? '; domain=' + options.domain : '')
            + (options.secure ? '; secure' : '');
    };
    */

    return {
        get: _getCookie,
        set: _setCookie,
        remove: _removeCookie
    }
});