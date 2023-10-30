/// <reference path="angular.min.js" />

var Application = angular
                .module("shopriteModule", [])
                .controller("shopriteController", function ($scope, $http) {
                    $scope.message = "Hellow there";
                });