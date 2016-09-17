var VidlyAngular = angular.module('VidlyAngular', ['ui.router']);

VidlyAngular.controller('LandingPageController', LandingPageController);

// TODO: Remove these & files.
VidlyAngular.factory('AuthHttpResponseInterceptor', AuthHttpResponseInterceptor);
/* VidlyAngular.factory('LoginFactory', LoginFactory);
VidlyAngular.factory('RegistrationFactory', RegistrationFactory); */

var config = function ($stateProvider, $httpProvider, $locationProvider) {
    $locationProvider.hashPrefix('!').html5Mode({
        enabled: true,
        requireBase: false
    });

    $stateProvider
        .state('stateOne', {
            url: '/stateOne?donuts',
            views: {
                "containerOne": {
                    templateUrl: '/Angular/One'
                }
            }
        });

    $httpProvider.interceptors.push('AuthHttpResponseInterceptor');
}
config.$inject = ['$stateProvider', '$httpProvider', '$locationProvider'];

VidlyAngular.config(config);
