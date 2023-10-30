'use strict';

angular.module('ngApp').controller('vendorcontroller', ['$scope', '$rootScope', '$location', 'ShopriteDataService', function ($scope, $rootScope, $location, ShopriteDataService) {
    var isKendoRendered = false;
    $scope.isViewInitialised = false;
    $scope.Vendors = null;
    initialiseView();


    function initialiseView() {
        $scope.isViewInitialised = true;
        ShopriteDataService.GetVendors().then(function (data) {
            $scope.Vendors = data.Vendors;

        })

    }

    //$scope.alert = function (index, event) {
    //    alert("checkbox " + index + " is " + $scope.Vendors[index]);
    //}

    //$scope.ChangeOrderState = function (Vendors) {

    //    ShopriteDataService.ChangeOrderState(Vendors)
    //    .then(function (data) {
    //        $scope.Vendor = data.Vendor;
    //    })

    //};
    

}]);
