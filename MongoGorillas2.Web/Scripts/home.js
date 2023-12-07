var app = angular.module('homeApplication', []);

app.controller('homeController', function ($scope, $http) {
    $http.get('/service/Gorillas').then(function(data) {
        $scope.Gorillas = data.data;
    });

    $scope.spawn = function () {
        $http.post('/service/spawn').then(function(data) {
            $scope.Gorillas.push(data.data);
        });
    }

    $scope.remove = function (Gorilla) {
        if (confirm('Are you sure?')) {
            $http.post('/service/remove', JSON.stringify(Gorilla)).then(function(data) {
                if (data.data) {
                    $scope.Gorillas.splice($scope.Gorillas.indexOf(Gorilla), 1);
                }
            });
        }
    }
});