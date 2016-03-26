define({
    startPage: "#home",
    pageHost: ".page-host",
    api: {
        resBaseUrl: "https://localhost:44390/api",
        authBaseUrl: "https://localhost:44345/"
    },
    routes: [
        { hash: "#home", title: 'Home', path: 'pages/home', icon: "home" },
        { hash: "#products", title: 'Products', path: 'pages/products', icon: "gift" },
        { hash: "#about", title: 'About', path: 'pages/about', icon: "info-sign" },
        { hash: "#history", title: 'History', path: 'pages/history', icon: "list" },
        { hash: "#test", title: 'Test', path: 'pages/test', icon: "flash" },
        { hash: "#colors", title: 'Colors', path: 'pages/colors', icon: "flash" }
    ],
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