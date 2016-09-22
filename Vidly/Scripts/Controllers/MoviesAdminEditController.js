var MoviesAdminEditController = function ($scope, $state, $http) {
    $scope.onFormSubmit = function () {
        $http({
            method: 'Post',
            url: '../../Movies/Save',
            headers: { 'enctype': 'multipart/form-data' }
        });

        $state.go('moviesAdmin');
    }
}

MoviesAdminEditController.$inject = ['$scope', '$state', '$http'];