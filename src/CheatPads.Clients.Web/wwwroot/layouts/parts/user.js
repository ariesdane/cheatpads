define(["auth", "ko"], function (auth, ko) {
    return {
        authenticated: auth.authenticated,
        displayName: ko.pureComputed(function () {
            return auth.authenticated() ? auth.identity().displayName : "Guest";
        }),
        login: auth.login,
        logout: auth.logout,
    };
});