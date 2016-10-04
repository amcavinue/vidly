var ClassifiedsController = function ($scope, ClassifiedsFactory) {
    var vm = this;
    
    ClassifiedsFactory.getClassifieds().then(function (classifieds) {
        vm.classifieds = classifieds;
        console.log(classifieds);
    });
}

ClassifiedsController.$inject = ['$scope', 'ClassifiedsFactory'];
