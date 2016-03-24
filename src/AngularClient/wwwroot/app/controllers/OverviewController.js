(function () {
	'use strict';

	var module = angular.module("mainApp");

	// this code can be used with uglify
	module.controller("OverviewController",
		[
			"$scope",
			"$log",
			"userEvents",
			"UserEventsService",
            "$state",
			OverviewController
		]
	);

	function OverviewController($scope, $log, userEvents, UserEventsService, $state) {

		$log.info("OverviewController called");
		$scope.message = "Overview";

		$scope.UserEventsService = UserEventsService;

		$log.info(userEvents);
		$scope.userEvents = userEvents;
	
		$scope.Delete = function (id) {
		    $log.info("deleting");
		    $scope.UserEventsService.DeleteUserEvent(id).then(
		        function () {
		            $state.go($state.current, {}, { reload: true });
		        });;
		};
	}
})();
