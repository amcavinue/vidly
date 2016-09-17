var ClassifiedsController = function ($scope, $state, $http, ClassifiedsFactory, $mdSidenav, $mdToast, $mdDialog) {
    var vm = this;
    var contact = {
        name: "Ben Collins",
        phone: "555-555-5555",
        email: "abc@def.com"
    };

    vm.categories;
    vm.classified;
    vm.classifieds;
    // vm.deleteClassified = deleteClassified;
    // vm.editClassified = editClassified;
    vm.editing;
    vm.openSidebar = openSidebar;
    vm.saveClassified = saveClassified;
    vm.saveEdit = saveEdit;

    ClassifiedsFactory.getClassifieds().then(function (classifieds) {
        vm.classifieds = classifieds.data;
    });

    $scope.$on('newClassified', function (event, classified) {
        classified.contact = contact;
        classified.id = vm.classifieds.length + 1;
        vm.classifieds.push(classified);
        showToast('Classified saved!');
    });

    $scope.$on('editSaved', function (event, message) {
        showToast(message);
    });

    function openSidebar() {
        // $mdSidenav('left').open();
        $state.go('classifieds.new');
    }

    function saveClassified(classified) {
        if (classified) {
            classified.contact = contact;
            vm.classifieds.push(classified);
            vm.classified = {};
            closeSidebar();
            showToast("Classified saved!");
        }
    }

    function saveEdit() {
        vm.editing = false;
        vm.classified = {};
        closeSidebar();
        showToast("Edit saved!");
    }

    function showToast(message) {
        $mdToast.show(
            $mdToast.simple()
                .content(message)
                .position('top, right')
                .hideDelay(3000)
        );
    }
}

ClassifiedsController.$inject = ['$scope', '$state', '$http', 'ClassifiedsFactory', '$mdSidenav', '$mdToast', '$mdDialog'];