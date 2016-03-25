(function () {
	'use strict';

	var module = angular.module('mainApp');

	// this code can be used with uglify
	module.controller('UserDocumentsController',
		[
			'$scope',
			'$log',
			'userDocument',
            'UserDocumentsService',
            '$state',
			UserDocumentsController
		]
	);

	function UserDocumentsController($scope, $log, userDocument, UserDocumentsService, $state) {
		$log.info("UserDocumentsController called");
		$scope.message = "UserDocument Create, Update or Delete";
		$scope.UserDocumentsService = UserDocumentsService;
		$scope.state = $state;

		$scope.userDocument = userDocument;

		$scope.Update = function () {
			$log.info("Updating");
			$log.info(userDocument);
			$scope.UserDocumentsService.UpdateUserDocument(userDocument).then(
		        function () {
		        	$scope.state.go("documentIndex");
		        });
		};

		$scope.Create = function () {
			$log.info("Creating");
			$log.info(userDocument);
			$scope.UserDocumentsService.AddUserDocument(userDocument).then(
		        function () {
		        	$scope.state.go("documentIndex");
		        });
		};

	}

})();
