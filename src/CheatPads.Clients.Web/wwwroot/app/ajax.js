define(['jquery'], function ($) {
    // exported model
    var _AJAX = {};
           
    // private
    function _url (url, path, id) {
        if (path.slice(-1) == "/") path = path.slice(0, -1);
        if (!/http/i.test(path)) path = (url || "") + "/" + path;
        if (id !== undefined) path += "/" + id;
        return path + "?" + +new Date();
    }

    function _queryString (data) {
        if (typeof data === 'object') {
            var parts = [], key, val;
            for (key in data) {
                val = $.isArray(data[key]) ? data[key].join(",") : data[key];
                parts.push(key + "=" + window.encodeURIComponent(val));
            }
            return "&" + parts.join("&");
        }
        return "";
    }

    function _ajax(options) {
        var task = $.Deferred(),
            promise = task.promise(),
            error_fn = options.error,
            success_fn = options.success;

        function applyInterceptors(scopes, args) {
            _AJAX.interceptors.forEach(function (intercepetor) {
                scopes.forEach(function (scope) {
                    if (typeof intercepetor[scope] === "function") {
                        intercepetor[scope].apply(options, args);
                    }
                });
            });
        }

        options.error = function (xhr, status, error) {
            applyInterceptors(["response", "error", xhr.status], [xhr.status, xhr.statusText]);
            error_fn && error_fn.apply(options, [xhr.status, xhr.statusText]);
        };

        options.success = function (data, message, xhr) {
            applyInterceptors(["response", "success", xhr.status], [xhr.status, data]);
            success_fn && success_fn.apply(options, [xhr.status, data]);
        }

        applyInterceptors(["request"], [options]);

        // using jquery as the underlying ajax library
        $.ajax(options).done(task.resolve).fail(task.reject);

        return $.extend(promise, { as: promise.done });
    };


    // public
    _AJAX.addApi = function(apiName, baseUrl) {
        var methods = {
            get: function (path, id, query) {
                if (typeof id === "object") {
                    query = id;
                    id = undefined;
                }
                return _ajax({ url: _url(baseUrl, path, id) + _queryString(query), type: "GET" });
            },
            post: function (path, data) {
                return _ajax({ url: _url(baseUrl, path), data: data, type: "POST" });
            },
            put: function (path, id, data) {
                return _ajax({ url: _url(baseUrl, path, id), data: data, type: "PUT" });
            },
            delete: function (path, id) {
                return _ajax({ url: _url(baseUrl, path, id), type: "DELETE" });
            }
        };
        if (apiName) {
            _AJAX[apiName] = methods;
        }
        else{
            $.extend(_AJAX, methods);
        }
    }

    _AJAX.interceptors = [
            //{
            //    request: fn // intercept all requests
            //    response: fn, // intercept all error responses
            //    error: fn,   // intercept all error responses
            //    success: fn, // intercept all successful responses
            //    401: fn      // intercept 401 responses 
            //}
    ];

    // preloading generic ajax methods to model root
    _AJAX.addApi();
    
    return _AJAX;
});