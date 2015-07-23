(function () {
    'use strict';
    angular.module('WebApi').controller('StudentController', StudentController);
    StudentController.$inject = ['$http', '$scope'];
    function StudentController($http, $scope) {
        activate();
        var students = [];
        function activate() {            
            $http.get('/api/students/').success(function (res) {
                angular.forEach(res, function(item) {
                    students.push(item);
                });
               $scope.students = students;
            });
        }
    }
})();