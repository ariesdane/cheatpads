define(['jquery'], function ($) {
    var _self,
        _interceptors = [
            //{
            //    request: fn // intercept all requests
            //    response: fn, // intercept all error responses
            //    error: fn,   // intercept all error responses
            //    success: fn, // intercept all successful responses
            //    401: fn      // intercept 401 responses 
            //}
        ];
    
    var _url = function (path, id) {
        if (path.slice(-1) == "/") path = path.slice(0, -1);
        if (!/http/i.test(path)) path = _self.baseUrl + "/" + path;
        if (id !== undefined) path += "/" + id;
        return path;
    }

    var _queryString = function (data) {
        if (typeof data === 'object') {
            var parts = [], key, val;
            for (key in data) {
                val = $.isArray(data[key]) ? data[key].join(",") : data[key];
                parts.push(key + "=" + window.encodeURIComponent(value));
            }
            return "?" + parts.join("&");
        }
        return "";
    }

    var _ajax = function (options) {
        var task = $.Deferred(),
            promise = task.promise(),
            error_fn = options.error,
            success_fn = options.success;

        function applyInterceptors(scopes, args) {
            _interceptors.forEach(function (intercepetor) {
                scopes.forEach(function (scope) {
                    if (typeof intercepetor[scope] === "function") {
                        intercepetor[scope].apply(options.context, args);
                    }
                });
            });
        }

        options.error = function (xhr, status, error) {
            applyInterceptors(["response", "error", xhr.status], arguments);
            error_fn && error_fn.apply(options.context, arguments);
        };

        options.success = function (data, message, xhr) {
            applyInterceptors(["response", "success", xhr.status], arguments);
            success_fn && success_fn.apply(options.context, arguments);
        }

        applyInterceptors(["request"], [options]);

        // using jquery as the underlying ajax library
        $.ajax(options).done(task.resolve).fail(task.reject);

        return $.extend(promise, { as: promise.done });
    };

    
    return _self = {   
        ajax: _ajax,
        get: function (path, id, query) {
            if (typeof id === "object") {
                query = id;
                id = undefined;
            }
            return _ajax({ url: _url(path, id) + _queryString(query), type: "GET" });
        },
        post: function (path, data) {
            return _ajax({ url: _url(path), data: data, type: "POST" });
        },
        put: function (path, id, data) {
            return _ajax({ url: _url(path, id), data: data, type: "PUT" });
        },       
        delete: function (path, id) {
            return _ajax({ url: _url(path, id), type: "DELETE" });
        },       
        interceptors: _interceptors,
        baseUrl: "",
    }

});