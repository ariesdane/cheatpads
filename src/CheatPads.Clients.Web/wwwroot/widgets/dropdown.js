define(["jquery"], function ($) {
    function toggleEvent(event) {
        var $el = $(event.currentTarget).parents(".dropdown:first"),
            className = "open";

        $el.hasClass(className)
            ? $el.removeClass(className)
            : $el.addClass(className);
    }

    return function (params) {
        this.label = params.label || "Dropdown";
        this.options = params.options || [];

        this.getOptionText = function (item) {
            if (typeof item == "object") {
                return item[params.optionTextField] || item["name"] || item["title"];
            }
            return item;
        }

        this.toggle = function (data, event) {
            toggleEvent(event);
        }

        this.select = function (item, event) {
            if(typeof params.select === "function"){
                params.select(item);
            }
            toggleEvent(event);
        }
    }



});