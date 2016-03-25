define(function () {
    // ----------------------------------------------------------------------------------
    // WIDGET : vaultboy
    // ----------------------------------------------------------------------------------
    // Displays a vaultboy icon from RobCo's vaultboy library
    //
    // params : type <int, optional> - the index of the icon to show
    //
    // ex. #1 : <vaultboy></vaultboy>                       // random vaultboy #1 - #20
    // ex, #2 : <vaultboy params="type: 3"></vaultboy>      // vaultboy icon #3
    //
    return function (params) {
        if (!params.type) {
            params.type = Math.ceil(Math.random() * 20);
        }

        this.cssClass = "vaultboy vaultboy-" + params.type;
    }

});