(function () {
    var mainApp = angular.module("mainApp", ["ui.router", "LocalStorageModule"]);

    mainApp.config(["$stateProvider", "$urlRouterProvider", "$locationProvider",
    function ($stateProvider, $urlRouterProvider, $locationProvider) {
        $urlRouterProvider.otherwise("/authorized");

        $stateProvider
            .state("authorized", {
                url: "/authorized",
                templateUrl: "/templates/authorized.html",
                controller: "AuthorizedController"
            })
		        .state("home", { abstract: true, url: "/home", templateUrl: "/templates/home.html" })

		        .state("overview", {
		            abstract: true,
		            parent: "home",
		            url: "/overview",
		            templateUrl: "/templates/overview.html"
		        })
		        .state("details", {
		            parent: "overview",
		            url: "/details/:id",
		            templateUrl: "/templates/details.html",
		            controller: "UserEventsController",
		            resolve: {
		                UserEventsService: "UserEventsService",

		                userEvents: [
		                    "UserEventsService", function (UserEventsService) {
		                        return UserEventsService.GetUserEvents();
		                    }
		                ],
		                userEvent: [
		                    "UserEventsService", "$stateParams", function (UserEventsService, $stateParams) {
		                        var id = $stateParams.id;
		                        console.log($stateParams.id);
		                        return UserEventsService.GetUserEvent({ id: id });
		                    }
		                ]
		            }
		        })
                .state("overviewindex", {
                    parent: "overview",
                    url: "/overviewindex",
                    templateUrl: "/templates/overviewindex.html",
                    controller: "OverviewController",
                    resolve: {
                        UserEventsService: "UserEventsService",

                        userEvents: [
		                    "UserEventsService", function (UserEventsService) {
		                        return UserEventsService.GetUserEvents();
		                    }
                        ]
                    }
                })
		        .state("create", {
		            parent: "overview",
		            url: "/create",
		            templateUrl: "/templates/create.html",
		            controller: "UserEventsController",
		            resolve: {
		                userEvents: [
		                    "UserEventsService", function (UserEventsService) {
		                        return UserEventsService.GetUserEvents();
		                    }
		                ],
		                userEvent: [
		                    function () {
		                        return { Id: "", Name: "", Description: "", Timestamp: "2015-08-28T09:57:32.4669632" };
		                    }
		                ]

		            }
		        })
                // USER DOCUMENTS
                .state("documentindex", {
                    parent: "overview",
                    url: "/documentindex",
                    templateUrl: "/templates/documentindex.html",
                    controller: "UserDocumentIndexController",
                    resolve: {
                        UserEventsService: "UserDocumentsService",
                        userDocuments: [
		                    "UserDocumentsService", function (UserDocumentsService) {
		                        return UserDocumentsService.GetUserDocuments();
		                    }
                        ]
                    }
                });

		    $locationProvider.html5Mode(true);
		}
    ]
    );

    mainApp.run(["$rootScope", function ($rootScope) {

        $rootScope.$on('$stateChangeError', function(event, toState, toParams, fromState, fromParams, error) {
            console.log(event);
            console.log(toState);
            console.log(toParams);
            console.log(fromState);
            console.log(fromParams);
            console.log(error);
        });

        $rootScope.$on('$stateNotFound', function(event, unfoundState, fromState, fromParams) {
            console.log(event);
            console.log(unfoundState);
            console.log(fromState);
            console.log(fromParams);
        });

    }]);

})();