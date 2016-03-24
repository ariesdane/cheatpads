(function () {
	'use strict';

	var module = angular.module('mainApp');

	// this code can be used with uglify
	module.controller('UserEventsController',
		[
			'$scope',
			'$log',
			'userEvent',
            'UserEventsService',
            '$state',
			UserEventsController
		]
	);

	function UserEventsController($scope, $log, userEvent, UserEventsService, $state) {
	    $log.info("UserEventsController called");
		$scope.message = "UserEvent Create, Update or Delete";
	    $scope.UserEventsService = UserEventsService;
	    $scope.state = $state;

		$scope.userEvent = userEvent;

		$scope.Update = function() {
		    $log.info("Updating");
		    $log.info(userEvent);
		    $scope.UserEventsService.UpdateUserEvent(userEvent).then(
		        function() {
		            $scope.state.go("overviewindex");
		        });
		};

		$scope.Create = function () {
		    $log.info("Creating");
		    $log.info(userEvent);
		    $scope.UserEventsService.AddUserEvent(userEvent).then(
		        function () {
		            $scope.state.go("overviewindex");
		        });
		};

	}

})();
