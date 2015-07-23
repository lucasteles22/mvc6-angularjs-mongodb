(function () {
    'use strict';
    angular.module('WebApi').controller('StudentCreateController', StudentCreateController);
    StudentCreateController.$inject = ['$http', '$location', '$scope'];
    function StudentCreateController($http, $location, $scope) {
        $scope.student = {
            FirstName: '',
            LastName: '',
            JoinAt: new Date()
        };

        activate();

        function activate() {
        }

        $scope.submit = function () {
            $http.post('api/students', $scope.student).success(function (res) {
                console.log($scope)
                alert($scope.student.FirstName + ' incluido com sucesso', 'Sucesso');
                $location.path('/');
            });
        };
    }
})();