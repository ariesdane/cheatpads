define(["system"], function (system) {
    var model = {};

    model.entries = system.entries;
    model.buttons = [
        { type: "info", name: "Info Button" },
        { type: "warn", name: "Warning Button" },
        { type: "error", name: "Error Button" },
        { type: "assert", name: "Assert Button" },
    ]

    model.getIconClass = function (type) {
        var icons = { warn: "exclamation-sign", error: "minus-sign", assert: "ok-sign", info: "info-sign", log: "flag" };
        return "glyphicon glyphicon-" + icons[type];
    }

    model.testLog = function (item) {
        system[item.type]("Console Mock Entry", item);
    }

    model.formatDate = function (ticks) {
        var d = new Date(ticks);
        function pad(val) {
            return val < 10 ? "0" + val : val;
        }

        return d.getFullYear() + "." + pad(d.getMonth() + 1) + "." + pad(d.getDate()) + " "
            + pad(d.getHours()) + ":" + pad(d.getMinutes()) + ":" + pad(d.getSeconds());
    }

    return model;
});