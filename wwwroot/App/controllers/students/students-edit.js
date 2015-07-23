
(function () {
    'use strict';
    angular.module('WebApi').controller('StudentEditController', StudentEditController);
    StudentEditController.$inject = ['$http', '$location', '$scope', '$routeParams'];
    function StudentEditController($http, $location, $scope, $routeParams) {
        activate();

        function activate() {
             $http.get('api/students/' + $routeParams.id).success(function (res) {
                $scope.student = res;
            });
        }

        $scope.submit = function () {
            $http.put('api/students/', $scope.student).success(function (res) {
                alert($scope.student.FirstName + ' atualizado com sucesso', 'Sucesso');
                $location.path('/');
            });           
        };
    }
})();