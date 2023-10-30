'use strict';

var ngApp = angular.module('ngApp', ['ngRoute', 'ngSanitize', 'ngAnimate', 'ngCookies', 'kendo.directives', 'ngDialog']);

ngApp.config(['$routeProvider', '$httpProvider', '$locationProvider', function ($routeProvider, $httpProvider, $locationProvider, ngDialog) {
    //   $httpProvider.defaults.withCredentials = true;
    $httpProvider.defaults.useXDomain = true;
    delete $httpProvider.defaults.headers.common['X-Requested-With'];

    $routeProvider
                    .when('/', {
                        templateUrl: 'views/pages/login.html',
                        controller: 'logincontroller'
                    })
            .when('/login', {
                templateUrl: 'views/pages/login.html',
                controller: 'logincontroller'
            })
            .when('/index', {
                templateUrl: 'index.html',
                controller: 'logincontroller'
            })
            .when('/Vendor', {
                templateUrl: 'views/pages/vendors.html',
                controller: 'shopritecontroller',
                requireLogin: true
            })
            .when('/AddVendor', {
                templateUrl: 'views/pages/AddVendor.html',
                controller: 'vendorcontroller'
            })

    ;

    $locationProvider.html5Mode(true);
}]).run(function ($rootScope, $location) {
    $rootScope.$on("$routeChangeStart", function (event, next, current) {
        if ($rootScope.loggedInUser == "false") {
            // no logged user, redirect to /login
            if (next.templateUrl === "views/pages/login.html") {
            } else {
                $location.path("/login");
            }
        }
    })
})
;

