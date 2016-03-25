define(["config", "services/cart"], function (config, cart) {
    return {
        siteName: config.site.name,
        siteLogo: config.site.logo
    };
});