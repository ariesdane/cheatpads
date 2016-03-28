define(["jquery", "system"], function ($, system) {
    var _icons = {
        warn: "exclamation-sign",
        error: "minus-sign",
        assert: "ok-sign",
        info: "info-sign",
        confirm: "question-sign"
    };

    var _titles = {
        warn: "Notice",
        error: "Error",
        assert: "Success",
        info: "Information",
        confirm: "Confirmation"
    };

    var _modal = {
        template: '<div class="modal" style="display: block">'
                +    '<div class="modal-dialog" style="margin: 0 auto">'
                +     '<div class="modal-content">'
                +       '<div class="modal-header">'
                +         '<i data-bind="attr: { class: \'glyphicon glyphicon-\' + icon }"></i>'
                +         '<span data-bind="text: title"></span>'
                +         '<a class="pull-right" data-bind="click: close">&times;</a>'
                +       '</div>'
                +       '<div class="modal-body scroll" data-bind="html: message"></div>'
                +       '<div class="modal-footer" data-bind="foreach: buttons">' 
                +         '<button class="btn" data-bind="text: $data, click: $parent.buttonClick"></button>'
                +       '</div>'
                +     '</div>'
                +    '</div>'
                +  '</div>',
        render: function ($node){
            $node.prependTo($("body")).find(".modal-dialog").css({ });
        }
    };

    var _toast =  {
        template: '<div class="toast">'
                +    '<div class="toast-title">'
                +      '<i data-bind="attr: { class: \'glyphicon glyphicon-\' + icon }"></i>'
                +      '<span data-bind="text: title"></span>'
                +    '</div>'
                +    '<p data-bind="html: message"></p>'
                +  '</div>',
        render: function ($node) {
            $node.prependTo($(".toast-anchor"));
            window.setTimeout(function () { $node.remove(); }, 2000);
        }
    };

    var _showDialog = function (dialog, type, message, buttons, title) {
        var $node = $("<div></div>"), promise = $.Deferred();

        system.compose({
            target: $node,
            view: dialog.template,
            model: {
                title: title || _titles[type],
                icon: _icons[type],
                message: message,
                buttons: buttons,
                close: function(o, event){
                    this.buttonClick("close", event);
                },
                buttonClick: function (btn, event) {
                    $(event.currentTarget).parents(".composed:first").remove();
                    promise.resolve(btn);
                },
                render: dialog.render
            }
        });
        return promise;
    }

    return {
        modal: {
            alert: function (message) {
                return _showDialog(_modal, "warn", message, ["Ok"]);
            },
            error: function (message) {
                return _showDialog(_modal, "error", message, ["Ok"]);
            },
            confirm: function (message) {
                return _showDialog(_modal, "confirm", message, ["Ok", "Cancel"]);
            },
            info: function (message) {
                return _showDialog(_modal, "info", message, ["Ok"]);
            },
            image: function (title, src) {
                var content = '<img class="modal-image" src="' + src + '"/>';
                return _showDialog(_modal, "info", content, ["Close"], title);
            },
        },
        toast: {
            alert: function (message, title) {
                return _showDialog(_toast, "warn", message, [], title);
            },
            error: function (message, title) {
                return _showDialog(_toast, "error", message, [], title);
            },
            success: function (message, title) {
                return _showDialog(_toast, "assert", message, [], title);
            },
            info: function (message, title) {
                return _showDialog(_toast, "info", message, [], title);
            }
        }
    }
});


/*
var _bindMessage = function (template, data) {
    var carets = template.match(/\$\{[\w\.\$\-]+\}/g), i = 0;
    for (i = 0; carets && i < carets.length; i++) {
        var expr = carets[i].slice(1, -1).split("."), val = data, key;
        try { for (key in expr) val = val[expr[key]]; }
        catch (err) { val = carets[i]; };
        template = template.replace(carets[i], val == null ? '' : val);
    }
    return template;
}
 */