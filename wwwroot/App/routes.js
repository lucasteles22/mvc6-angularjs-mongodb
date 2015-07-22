
(function () {
    'use strict'; 
 
    config.$inject = ['$routeProvider', '$locationProvider']; 
 
    angular.module('WebApi', ['ngRoute']).config(config);
 
    function config($routeProvider, $locationProvider) {
        $routeProvider
            .when('/', {
              templateUrl: '/index.html',
              controller: 'StudentController'
            }) 
        $locationProvider.html5Mode(true); 
    }
 
})();