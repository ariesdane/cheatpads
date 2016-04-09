define({
    startPage: "#home",
    pageHost: ".page-host",
    apis: {
        ecomm: "http://localhost:2716/api",
        users: "https://localhost:44390/api",
        wallet: "https://localhost:44390/api",
    },
    auth: {
        loginUrl: "https://localhost:44345/connect/authorize",
        logoutUrl: "https://localhost:44345/ui/logout",
        loginUrlReturn: "http://localhost:61739/",
        logoutUrlReturn: "http://localhost:61739/",
        clientId: "CheatPads.Clients.Web",
        scope: "CheatPads.Api CheatPads.Wallet",
        responseType: "token"
    },
    routes: [
        { hash: "#home", title: 'Home', path: 'pages/home', icon: "home" },
        { hash: "#products", title: 'Products', path: 'pages/products', icon: "gift" },
        { hash: "#about", title: 'About', path: 'pages/about', icon: "info-sign" },
        { hash: "#history", title: 'History', path: 'pages/history', icon: "list" },
        { hash: "#test", title: 'Test', path: 'pages/test', icon: "flash" },
        { hash: "#colors", title: 'Colors', path: 'pages/colors', icon: "flash" },
        { hash: "#admin/users", title: 'User Admin', path: 'pages/admin/users', icon: "cog" },
    ],
    menus: {
        site: [
            { hash: "#home" },
            { hash: "#products" },
            { hash: "#about" },
            { hash: "#history" },
        ],
        test: [
            { hash: "#test" },
            { hash: "#colors" },
            { hash: "#admin/users"}
        ]
    },
    widgets: [
        { name: "dropdown", path: "widgets/dropdown" }
    ],
    site: {
        name: "CheatPads.com",
        logo: "assets/img/cheatpads-logo.png"
    },
    info: {
        app: "CheatPads.Web",
        version: "Beta.0.3",
        licenses: [
            "CheatPads.com &copy; 2016"
        ],      
        authors: [
		    { name: "Aries", location: "St. Croix, Virgin Islands" },
		    { name: "Ziggy", location: "Prichard, AL" }
        ]
    },
    copyright: "CheatPads.com &copy; 2016"
});