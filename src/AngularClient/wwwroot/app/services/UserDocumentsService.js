(function () {
    'use strict';

    function UserDocumentsService($http, $log, $q, $rootScope) {
        $log.info("UserDocumentsService called");

        var baseUrl = "https://localhost:44390/";
        var AddUserDocument = function (userDocument) {
            var deferred = $q.defer();

            console.log("addUserDocument started");
            console.log(userDocument);

            $http({
                url: baseUrl + 'api/UserDocuments',
                method: "POST",
                data: userDocument
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (error) {
                deferred.reject(error);
            });
            return deferred.promise;
        };

        var UpdateUserDocument = function (userDocument) {
            var deferred = $q.defer();

            console.log("addUserDocument started");
            console.log(userDocument);

            $http({
                url: baseUrl + 'api/UserDocuments/' + userDocument.Id,
                method: "PUT",
                data: userDocument
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (error) {
                deferred.reject(error);
            });
            return deferred.promise;
        };

        var DeleteUserDocument = function (id) {
            var deferred = $q.defer();

            console.log("DeleteUserDocument begin");
            console.log(id);

            $http({
                url: baseUrl + 'api/UserDocuments/' + id,
                method: "DELETE",
                data: ""
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (error) {
                deferred.reject(error);
            });
            return deferred.promise;
        };

        var GetUserDocuments = function () {

            var deferred = $q.defer();

            console.log("GetUserDocuments started");
            console.log($rootScope.authorizationData);

            $http({
                url: baseUrl + 'api/UserDocuments',
                method: "GET"
                //headers:  {
                //    "accept": "application/json; charset=utf-8",
                //    'Authorization': 'Bearer ' + $rootScope.authorizationData
                //}
            }).success(function (data) {
                console.log("GetUserDocuments success");
                deferred.resolve(data);
            }).error(function (error) {
                console.log("GetUserDocuments error");
                deferred.reject(error);
            });

            return deferred.promise;

        }

        var GetUserDocument = function (id) {
            $log.info("UserDocumentservice GetUserDocument called: " + id.id);
            $log.info(id);

            var deferred = $q.defer();

            $http({
                url: baseUrl + "api/UserDocuments/" + id.id,
                method: "GET"
                //headers:  {
                //    "accept": "application/json; charset=utf-8",
                //    'Authorization': 'Bearer ' + $rootScope.authorizationData
                //}
            }).success(function (data) {
                console.log("GetUserDocuments success");
                deferred.resolve(data);
            }).error(function (error) {
                console.log("GetUserDocuments error");
                deferred.reject(error);
            });

            return deferred.promise;

            return $http.get(baseUrl + "api/UserDocuments/" + id.id)
			.then(function (response) {
			    return response.data;
			});
        }

        return {
            AddUserDocument: AddUserDocument,
            UpdateUserDocument: UpdateUserDocument,
            DeleteUserDocument: DeleteUserDocument,
            GetUserDocuments: GetUserDocuments,
            GetUserDocument: GetUserDocument
        }
    }

    var module = angular.module('mainApp');

    module.factory("UserDocumentsService",
		[
			"$http",
			"$log",
            "$q",
            "$rootScope",
			UserDocumentsService
		]
	);

})();
