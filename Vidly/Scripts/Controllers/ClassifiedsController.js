var ClassifiedsController = function ($scope, ClassifiedsFactory, $rootScope) {
    var vm = this;
    
    ClassifiedsFactory.getClassifieds().then(function (classifieds) {
        vm.classifieds = classifieds;
    });

    $scope.$watch('classifiedsFilter', function () {
        $scope.$emit('cardsLoaded');
    });

    $scope.TriggerReadMore = function () {
        $scope.$emit('cardsLoaded');
        return false;
    }
}

ClassifiedsController.$inject = ['$scope', 'ClassifiedsFactory', '$rootScope'];
