(function () {
    'use strict'; 
    config.$inject = ['$routeProvider']; 
    angular.module('WebApi', ['ngRoute']).config(config);
    function config($routeProvider) {
        $routeProvider
            .when('/', {
              templateUrl: 'app/views/students/index.html',
              controller: 'StudentController'
            })
            .when('/students', {
              templateUrl: 'app/views/students/index.html',
              controller: 'StudentController'
            })
            .when('/students/create', {
                controller: 'StudentCreateController',
                templateUrl: 'app/views/students/create.html'
            })
            .when('/students/edit/:id', {
                controller: 'StudentEditController',
                templateUrl: 'app/views/students/edit.html'
            })
            .when('/students/delete/:id', {
                controller: 'StudentDeleteController',
                templateUrl: 'app/views/students/delete.html'
            })
            .when('/students/details/:id', {
                controller: 'StudentDetailsController',
                controllerAs: 'vm',
                templateUrl: 'app/views/students/details.html'
            });
    } 
})();