var ClassifiedCardDirective = function () {
    return {
        templateUrl: "/Angular/MovieCard",
        scope: {
            classifieds: "=classifieds",
            classifiedsFilter: "=classifiedsFilter",
            category: "=category"
        },
        controller: classifiedCardController,
        controllerAs: "vm"
    };

    function classifiedCardController($state, $scope, $mdDialog, $mdToast) {
        var vm = this;

    }
}

ClassifiedCardDirective.$inject = [];
