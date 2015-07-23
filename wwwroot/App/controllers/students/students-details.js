(function () {
    'use strict';
    angular.module('WebApi').controller('StudentDetailsController', StudentDetailsController);

    StudentDetailsController.$inject = ['$http', '$routeParams', '$scope'];

    function StudentDetailsController($http, $routeParams, $scope) {
        activate();

        function activate() {
            $http.get('api/students/' + $routeParams.id).success(function (res) {
                $scope.student = res;
            });
        }
    }
})();