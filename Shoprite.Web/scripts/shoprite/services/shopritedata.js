'use strict';

angular.module('ngApp').service('ShopriteDataService', ['$http', '$q', 'AppSettings', 'ngDialog', function ($http, $q, AppSettings, ngDialog) {
    var that = this;

    that.GetVendors = function () {
        var deferred = $q.defer();

        $http(
         {
             method: 'Get',
             url: AppSettings.getUrl('GetVendors'),
         })
         .success(function (data, status, headers, config) {
             deferred.resolve({ 'Vendors': data });
         });

        return deferred.promise;
        $scope.Busy = false;
    };

    that.Autenticate = function (userName, passWord, domain) {
          var deferred = $q.defer();

        $http(
         {
            method: 'POST',
             url: AppSettings.getUrl('Authenticate', { UserName:userName,PassWord:passWord,Domain:domain}),
                        })
                        .success(function(data, status, headers, config) {
                        deferred.resolve({ 'Autenticated': data
                        });
                        });

                   return deferred.promise;
                   $scope.Busy = false;
};

    that.ChangeOrderState = function (VendorId) {
        var deferred = $q.defer();

        $http(
         {
                 method: 'POST',
                 url: AppSettings.getUrl('ChangerOrderState', { vendorId: VendorId
         }),
        })
         .success(function (data, status, headers, config) {
             deferred.resolve({ 'Vendor': data
         });
    });

        return deferred.promise;

};

    that.GetOrder = function (OrderNumber) {
        var deferred = $q.defer();

        $http(
         {
                 method: 'POST',
                 url: AppSettings.getUrl('GetOrder', { orderNumber: OrderNumber
         }),
        })
         .success(function (data, status, headers, config) {
             deferred.resolve({ 'Order': data
         });
    });

        return deferred.promise;

};

    that.ChangeClaimState = function (VendorId) {
        var deferred = $q.defer();

        $http(
         {
                 method: 'POST',
                 url: AppSettings.getUrl('ChangeClaimState', { vendorId: VendorId
         }),
        })
         .success(function (data, status, headers, config) {
             deferred.resolve({ 'Vendor': data
         });
    });

        return deferred.promise;

};

        that.ChangeClaimState = function (VendorId) {
        var deferred = $q.defer();

        $http(
         {
                 method: 'POST',
                 url: AppSettings.getUrl('ChangeClaimState', {
                         vendorId: VendorId
         }),
        })
         .success(function (data, status, headers, config) {
             deferred.resolve({
'Vendor': data
         });
        });

        return deferred.promise;

};

    that.DeleteVendor = function (VendorId) {
        var deferred = $q.defer();

        $http(
         {
                 method: 'POST',
                 url: AppSettings.getUrl('DeleteVendor', {
                         vendorId: VendorId
         }),
        })
         .success(function (data, status, headers, config) {
             deferred.resolve({ 'Vendors': data
         });
    });

        return deferred.promise;

};

    that.AddVendor = function (Vendor) {
        var deferred = $q.defer();

        $http(
         {
                 method: 'POST',
                 url: AppSettings.getUrl('AddVendor', { vendor: Vendor
         }),
        })
         .success(function (data, status, headers, config) {
             deferred.resolve({ 'Vendors': data
         });
    });

        return deferred.promise;

};

}]);
