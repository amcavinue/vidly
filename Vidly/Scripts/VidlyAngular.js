var VidlyAngular = angular.module('VidlyAngular', ['ui.router', 'ngMaterial']);

VidlyAngular.controller('LandingPageController', LandingPageController);
VidlyAngular.controller('ClassifiedsController', ClassifiedsController);

VidlyAngular.factory('AuthHttpResponseInterceptor', AuthHttpResponseInterceptor);
VidlyAngular.factory('ClassifiedsFactory', ClassifiedsFactory);

VidlyAngular.directive('classifiedCard', ClassifiedCardDirective);

var config = function ($stateProvider, $httpProvider, $locationProvider) {
    $locationProvider.hashPrefix('!').html5Mode({
        enabled: true,
        requireBase: false
    });

    $stateProvider
        .state('stateOne', {
            url: '/StateOne',
            views: {
                "containerOne": {
                    templateUrl: '/One'
                }
            }
        })
        .state('classifieds', {
            url: '/',
            views: {
                "containerOne": {
                    templateUrl: '/ClassifiedsPartial',
                    controller: 'ClassifiedsController as vm'
                }
            }
        })
        .state('customersAdmin', {
            url: '/CustomersAdmin',
            views: {
                "containerOne": {
                    templateUrl: '../Customers/Index'
                }
            }
        })
        .state('moviesAdmin', {
            url: '/MoviesAdmin',
            views: {
                "containerOne": {
                    templateUrl: '../Movies/Index'
                }
            }
        });

    $httpProvider.interceptors.push('AuthHttpResponseInterceptor');
}
config.$inject = ['$stateProvider', '$httpProvider', '$locationProvider'];

VidlyAngular.config(config);
