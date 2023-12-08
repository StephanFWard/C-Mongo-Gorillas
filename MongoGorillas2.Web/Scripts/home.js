var app = angular.module('homeApplication', []);

app.controller('homeController', ['$http', function ($http) {
    'use strict';

    var vm = this;
    vm.Gorillas = [];

    // Fetch Gorillas
    $http.get('/service/Gorillas')
        .then(function (response) {
            vm.Gorillas = response.data;
        })
        .catch(function (error) {
            console.error('Error fetching Gorillas:', error);
        });

    // Add new Gorilla
    vm.spawn = function () {
        $http.post('/service/spawn')
            .then(function (response) {
                vm.Gorillas.push(response.data);
            })
            .catch(function (error) {
                console.error('Error spawning Gorilla:', error);
            });
    };

    // Remove Gorilla
    vm.remove = function (Gorilla) {
        if (confirm('Are you sure?')) {
            $http.post('/service/remove', JSON.stringify(Gorilla))
                .then(function (response) {
                    if (response.data) {
                        vm.Gorillas.splice(vm.Gorillas.indexOf(Gorilla), 1);
                    }
                })
                .catch(function (error) {
                    console.error('Error removing Gorilla:', error);
                });
        }
    };
}]);
