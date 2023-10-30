'use strict';

angular.module('ngApp').service('AppSettings', function () {
    var that = this;

    this.ServerBaseUrl = 'http://localhost:53272/';

    this.getServerBaseUrl = function () {
        var ServerBaseUrl = 'http://localhost:53272/api/';
        return ServerBaseUrl;
    };

    this.ServerUrls = {
        'GetVendors': 'Shoprite/GetVendors',
        'ChangerOrderState': 'Shoprite/ChangeOrderState',
        'ChangeVendor': 'Shoprite/ChangeVendor',
        'ChangeClaimState': 'Shoprite/ChangeClaimState',
        'AddVendor': 'Shoprite/AddVendor',
        'DeleteVendor': 'Shoprite/DeleteVendor',
        'GetOrder': 'Shoprite/GetOrder',
        'Authenticate': 'Shoprite/Authenticate'
    };

    this.getUrl = function (serviceName, params) {
        var serviceLocation = that.ServerUrls[serviceName];
        var ret = this.getServerBaseUrl() + serviceLocation + '/';
        var separator = '?';

        if (params !== null) {
            for (var obj in params) {
                if (params.hasOwnProperty(obj)) {
                    ret = ret + separator + obj + "=" + params[obj];
                    separator = '&';
                }
            }
        }

        return ret;
    };

});
