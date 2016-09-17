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
            url: '/Angular/StateOne',
            views: {
                "containerOne": {
                    templateUrl: '/Angular/One'
                }
            }
        })
        .state('classifieds', {
            url: '/Angular/Classifieds',
            views: {
                "containerOne": {
                    templateUrl: '/Angular/ClassifiedsPartial',
                    controller: 'ClassifiedsController as vm'
                }
            }
        });

    $httpProvider.interceptors.push('AuthHttpResponseInterceptor');
}
config.$inject = ['$stateProvider', '$httpProvider', '$locationProvider'];

VidlyAngular.config(config);
