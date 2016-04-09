define(["jquery", "ko"], function ($, ko) {
     return function (params) {
         var widget = this;

         widget.options = params.options || [];
         widget.disabled = params.disabled || false;
         widget.open = ko.observable(false);

         if (ko.isObservable(params.value)) {
             widget.value = params.value;
             params.syncLabel = params.syncLabel !== false;
         }
         else {
             widget.value = ko.observable(params.value);
         }      

        widget.label = ko.pureComputed(function () {
            return widget.value() && params.syncLabel
                ? widget.getOptionText(widget.value())
                : ko.unwrap(params.label);
        });

        
        widget.getOptionText = function (item) {
            if (typeof item == "object") {
                return item[params.optionTextField] || item["name"] || item["title"];
            }
            return item;
        }

        widget.select = function (item) {
            widget.value(item);
            widget.open(false);

            if(typeof params.select === "function"){
                params.select(item);
            }
        }

        widget.toggle = function () {
            widget.open(!widget.open());
        }

        widget.init = function (element, context) {
 
        }
    }
});