/// <reference path="C:\D DRIVE\WORK\ProvisioningPortal\Shoprite.Web\views/pages/vendors.html" />
angular.module('ngApp').controller('logincontroller', ['$scope', '$rootScope', '$location', 'ShopriteDataService', 'ngDialog', '$interval', function ($scope, $rootScope, $location, ShopriteDataService, ngDialog, $interval) {


    initialiseView();

    function initialiseView() {
        alert("Login Controller");

        $scope.username = "Anco";

        ShopriteDataService.Autenticate("pretoran", "@nc6672*", "VF-ROOT")
 .then(function (data) {
     $scope.Autenitcated = data;
     $rootScope.loggedInUser = data.Autenticated;
 })
        //$rootScope.loggedInUser = ShopriteDataService.Autenticate("pretoran", "@nc6672*", "VF-ROOT").Autenticated;
        $location.path("/views/pages/vendors.html");
        //};
    };





}]);