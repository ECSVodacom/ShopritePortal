/// <reference path="C:\D DRIVE\WORK\ProvisioningPortal\Shoprite.Web\views/pages/AddVendor.html" />
/// <reference path="C:\D DRIVE\WORK\ProvisioningPortal\Shoprite.Web\views/pages/AddVendor.html" />
'use strict';

angular.module('ngApp').controller('shopritecontroller', ['$scope', '$rootScope', '$location', 'ShopriteDataService', 'ngDialog', '$interval', function ($scope, $rootScope, $location, ShopriteDataService, ngDialog, $interval) {
    var isKendoRendered = false;
    $scope.isViewInitialised = false;
    $scope.Vendors = null;
    $scope.Vendor = null;
    $scope.Order = null;
    $scope.Busy = true;
    $scope.CheckTime = 1;
    $scope.Autenitcated = false;

    initialiseView();


    function initialiseView() {
        $scope.isViewInitialised = true;
        // $scope.Text = Autenticate("pretoran", "@nc6672*", "VF-ROOT")

        $interval(callAtInterval, 5000);
        ShopriteDataService.Autenticate("pretoran", "@nc6672*", "VF-ROOT")
             .then(function (data) {
             $scope.Autenitcated = data;
             })

        ShopriteDataService.GetVendors().then(function (data) {
            $scope.Vendors = data.Vendors;
            $scope.Busy = false;
        })
    };

    if ($scope.Autenitcated === true) {

       
    }

    $scope.Autenticate = function (UserName, Password, Domain) {
        ShopriteDataService.Autenticate(UserName, Password, Domain)
        .then(function (data) {
            $scope.Autenitcated = data;
        })

    }

    function callAtInterval() {
        $scope.CheckTime += 1;

    };

    $scope.alert = function (vendorId) {

        ShopriteDataService.ChangeOrderState(vendorId)
        .then(function (data) {
            vendor.enableOrders = data.enableOrders;
        })

    };

    $scope.ChangeClaim = function (vendorId) {

        ShopriteDataService.ChangeClaimState(vendorId)
        .then(function (data) {
            vendor.enableClaims = data.enableClaims;
        })

    };

    $scope.DeleteVendor = function (vendorId) {

        ShopriteDataService.DeleteVendor(vendorId)
        .then(function (data) {
            if (data.Vendors = true) {
                alert("Successfully Deleted Record");
            }
            else { alert("Could delete record"); }
            ngDialog.close();
            ShopriteDataService.GetVendors().then(function (data) {
                $scope.Vendors = data.Vendors;
            })
        })

    };

    $scope.GetOrder = function (OrderNumber) {
        $scope.Busy = true;
        ShopriteDataService.GetOrder(OrderNumber)
        .then(function (data) {
            $scope.Order = data.Order;

        })
        $scope.Busy = false;
    };

    $scope.AddVendor = function (vendor) {

        ShopriteDataService.AddVendor(angular.toJson(vendor, false))
        .then(function (data) {
            if (data.Vendors = true) {
                alert("Successfully Saved Record");
            }
            else { alert("Could not save record"); }
            ngDialog.close();
            ShopriteDataService.GetVendors().then(function (data) {
                $scope.Vendors = data.Vendors;
            })

        })

    };

    $scope.editRecord = function (item, indx) {
        $scope.hideOnBlur = true;
        $scope.inputShow = true;
        $scope.item = item;
        $scope.index = indx;
    };

    $scope.ngBlur = function (vendor) {
        $scope.isBlur = true;
        $scope.blur = "Ng-Blur True";
        //alert(vendor.vendorName + " " + vendor.Id + " lost focus");
        ShopriteDataService.ChangeVendor(angular.toJson(vendor, false))
                .then(function (data) {
                    //vendor.enableOrders = data.enableOrders;
                })
    };

    $scope.OpenDialog = function (page) {
        ngDialog.open({
            template: 'views/pages/' + page,//AddVendor.html',
            width: '50%',
            scope: $scope,
        });
    }

    $scope.OpenOrderDialog = function () {
        ngDialog.open({
            template: 'views/pages/orders.html',
            width: '40%',
            scope: $scope,
        });
    }

}]);



