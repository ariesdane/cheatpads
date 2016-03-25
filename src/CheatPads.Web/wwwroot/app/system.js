define(["jquery", "ko", "text"], function ($, ko, text) {
    // composition   
    var _compose = function (options, params) { // options = { target, view, model }
        var $node = $('<div class="composed"></div>'),
            $target = $(options.target).data(options),
            promise1 = $.Deferred(),
            promise2 = $.Deferred();

        !/\.html/.test(options.view)
            ? promise1.resolve(options.view)
            : require(["text!" + options.view], promise1.resolve);

        typeof options.model !== "string"
            ? promise2.resolve(options.model)
            : require([options.model], function (model) {
                _tryInvoke(model, "init", [params]);
                promise2.resolve(model);
            });

        return $.when(promise1, promise2).then(function (html, model) {
            $node.append(html).appendTo($target.empty());
            ko.applyBindings(model || {}, $node[0]);
            _addLogEntry("log", "Composition Ok", options.view);
            _tryInvoke(model, "render", [$node]);
            return options;
        });
    }

    var _tryInvoke = function (obj, fn, params) {
        if ($.isPlainObject(obj) && $.isFunction(obj[fn])) {
            obj[fn].apply(this, params);
        }
    }

    ko.components.register("compose", {     
        template: "<div data-bind='attr: { init: init($element) }'></div>",
        viewModel: function () {
            this.init = function (element) {
                var $parent = $(element).parent(), path = $parent.attr("path");
                _compose({ target: $parent, view: path + ".html", model: path });
            }
        }
    });

    // logging
    var _entries = ko.observableArray();

    var _addLogEntry = function (type, message, data) {
        _entries.push({
            type: type,
            message: message,
            data: data,
            timestamp: +new Date,
            source: location.hash
        });
        if (console && $.isFunction(console[type])) {
            data ? console[type](message, data) : console[type](message);
        }
        return this;
    }

    //  navigation
    var _routeMap = {}, _currentRoute = ko.observable();

    var _navigate = function (hash, params) {                               // params are optional, default to querystring when available
        var route = _routeMap[hash || "#"], promise = $.Deferred();
  
        if (!route) {
            _addLogEntry("error", "404 - Route Not Found", hash);
            promise.reject(hash);
        }
        else {
            _currentRoute(route);
            _addLogEntry("log", "Navigation Ok", hash);
            _compose(route, params).fail(promise.reject).done(promise.resolve);
        }
        return promise;
    }

    var _getSearchParams = function (search) {
        var re = /([^&=]+)=?([^&]*)/g, params = {}, match;
        while (match = re.exec(search.replace(/\+/g, " ")))
            params[match[1]] = decodeURIComponent(match[2]);
        return params;
    }
 
    var _configureRouting = function (options) {
        options.routes.forEach(function (route) {
            _routeMap[route.hash] = $.extend({         // extend route for use with compose
                view: route.path + ".html",
                model: route.path,
                target: options.pageHost || "body"                          
            }, route);
        });
        _routeMap["#"] = _routeMap[options.homePage] || options.routes[0];       

        $(window).bind("hashchange", function () {      
            var uri = location.hash.split("?").concat([""]);
            _navigate(uri[0], _getSearchParams(uri[1]));
        });
        return this;
    }

    // widgets
    var _configureWidgets = function (widgets) {        
        widgets.forEach(function (widget) {             
            ko.components.register(widget.name, {       // register widgets by tagname along with a resolver
                viewModel: { require: widget.path },    // ko will call require(widget.path) to get viewModel
                template: { require: "text!" + widget.path + ".html" }
            });
        });
        return this;
    }

    // public
    return {
        // configuration
        initRouting: _configureRouting,     // options<object>
        initWidgets: _configureWidgets,     // widgets<array>

        // routing  
        currentRoute: _currentRoute,
        navigate: _navigate,                // hash<string>, params<object>

        // logging
        log: function (message, data) {                 
            return _addLogEntry("log", message, data);
        },
        info: function (message, data) {                 
            return _addLogEntry("info", message, data);
        },
        warn: function (message, data) {
            return _addLogEntry("warn", message, data);
        },
        error: function (message, data) {
            return _addLogEntry("error", message, data);
        },
        assert: function (message, data) {
            return _addLogEntry("assert", message, data);
        },
        entries: _entries,                 

        // composition 
        compose: _compose,                  // options<object>, params<object>
    };
});