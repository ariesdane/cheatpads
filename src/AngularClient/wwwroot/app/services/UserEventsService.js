(function () {
    'use strict';

    function UserEventsService($http, $log, $q, $rootScope) {
        $log.info("UserEventsService called");

        var baseUrl = "https://localhost:44390/";
	    var AddUserEvent = function (userEvent) {
	        var deferred = $q.defer();

	        console.log("addUserEvent started");
	        console.log(userEvent);

	        $http({
	            url: baseUrl + 'api/UserEvents',
	            method: "POST",
	            data: userEvent
	        }).success(function (data) {
	            deferred.resolve(data);
	        }).error(function (error) {
	            deferred.reject(error);
	        });
	        return deferred.promise;
	    };

	    var UpdateUserEvent = function (userEvent) {
	        var deferred = $q.defer();

	        console.log("addUserEvent started");
	        console.log(userEvent);

	        $http({
	            url: baseUrl + 'api/UserEvents/' + userEvent.Id,
	            method: "PUT",
	            data: userEvent
	        }).success(function (data) {
	            deferred.resolve(data);
	        }).error(function (error) {
	            deferred.reject(error);
	        });
	        return deferred.promise;
	    };

	    var DeleteUserEvent = function (id) {
	        var deferred = $q.defer();

	        console.log("DeleteUserEvent begin");
	        console.log(id);

	        $http({
	            url: baseUrl + 'api/UserEvents/' + id,
	            method: "DELETE",
	            data: ""
	        }).success(function (data) {
	            deferred.resolve(data);
	        }).error(function (error) {
	            deferred.reject(error);
	        });
	        return deferred.promise;
	    };

	    var GetUserEvents = function () {
	     
	        var deferred = $q.defer();

	        console.log("GetUserEvents started");
	        console.log($rootScope.authorizationData);

	        $http({
	            url: baseUrl + 'api/UserEvents',
	            method: "GET"
	            //headers:  {
	            //    "accept": "application/json; charset=utf-8",
	            //    'Authorization': 'Bearer ' + $rootScope.authorizationData
	            //}
	        }).success(function (data) {
	            console.log("GetUserEvents success");
	            deferred.resolve(data);
	        }).error(function (error) {
	            console.log("GetUserEvents error");
	            deferred.reject(error);
	        });

	        return deferred.promise;

	    }

	    var GetUserEvent = function (id) {
	        $log.info("UserEventservice GetUserEvent called: " + id.id);
	        $log.info(id);

	        var deferred = $q.defer();

	        $http({
	            url: baseUrl + "api/UserEvents/" + id.id,
	            method: "GET"
	            //headers:  {
	            //    "accept": "application/json; charset=utf-8",
	            //    'Authorization': 'Bearer ' + $rootScope.authorizationData
	            //}
	        }).success(function (data) {
	            console.log("GetUserEvents success");
	            deferred.resolve(data);
	        }).error(function (error) {
	            console.log("GetUserEvents error");
	            deferred.reject(error);
	        });

	        return deferred.promise;

	        return $http.get(baseUrl + "api/UserEvents/" + id.id)
			.then(function (response) {
			    return response.data;
			});
	    }

		return {
		    AddUserEvent: AddUserEvent,
		    UpdateUserEvent: UpdateUserEvent,
		    DeleteUserEvent: DeleteUserEvent,
		    GetUserEvents: GetUserEvents,
		    GetUserEvent: GetUserEvent
		}
	}

	var module = angular.module('mainApp');

	module.factory("UserEventsService",
		[
			"$http",
			"$log",
            "$q",
            "$rootScope",
			UserEventsService
		]
	);

})();
