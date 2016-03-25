(function () {
    'use strict';

    var module = angular.module("mainApp");

    // this code can be used with uglify
    module.controller("UserDocumentsIndexController",
		[
			"$scope",
			"$log",
			"userDocuments",
			"UserDocumentsService",
            "$state",
			OverviewController
		]
	);

    function OverviewController($scope, $log, userDocuments, UserDocumentsService, $state) {

        $log.info("UserDocumentsIndexController called");
        $scope.message = "UserDocumentsIndex";

        $scope.UserDocumentsService = UserDocumentsService;

        $log.info(userDocuments);
        $scope.userDocuments = userDocuments;

        $scope.Delete = function (id) {
            $log.info("deleting");
            $scope.UserDocumentsService.DeleteUserDocument(id).then(
		        function () {
		            $state.go($state.current, {}, { reload: true });
		        });;
        };
    }
})();
