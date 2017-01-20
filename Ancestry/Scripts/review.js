var myApp = angular.module('myApp', []);
myApp.controller('ReviewController', ['$scope', '$http', function ($scope, $http) {
    $scope.model = {};

    console.log("HERE");

    $scope.sendForm = function () {
        $http({
            method: 'POST',
            url: 'api/Review',
            data: $scope.model
        }).success(function (data, status, headers, config) {

        }).error(function (data, status, headers, config) {

        });
    };
}]);