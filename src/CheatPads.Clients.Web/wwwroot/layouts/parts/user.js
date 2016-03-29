define(["auth", "ko"], function (auth, ko) {
    return {
        authenticated: auth.authenticated,
        userName: ko.pureComputed(function () {
            return auth.authenticated() ? auth.identity().userName : "Guest";
        }),
        login: auth.login,
        logout: auth.logout,
    };
});