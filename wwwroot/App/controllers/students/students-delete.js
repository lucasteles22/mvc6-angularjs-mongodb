(function () {
    'use strict';
    angular.module('WebApi').controller('StudentDeleteController', StudentDeleteController);

    StudentDeleteController.$inject = ['$http', '$routeParams', '$location', '$scope'];

    function StudentDeleteController($http, $routeParams, $location, $scope) {
        activate();

        function activate() {
            $http.get('api/students/' + $routeParams.id).success(function (res) {
                $scope.student = res;
            });
        }
        
        $scope.submit = function () {
            $http.delete('api/students/' + $routeParams.id).success(function (res) {
                alert($scope.student.FirstName + ' has been removed!')
                //toastr.success(vm.student.Name + ' excluido com sucesso', 'Sucesso');
                $location.path('/students');
            });
        };
    }
})();