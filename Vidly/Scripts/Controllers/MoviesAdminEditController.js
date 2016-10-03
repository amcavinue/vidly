var MoviesAdminEditController = function ($scope, $state, $http, $window) {
    $scope.onFormSubmit = function () {
        var formData = new FormData(angular.element('#new-movie-form')[0]);

        $.ajax({
            type: 'POST',
            data: formData,
            url: "http://" + location.host + "/Movies/Save",
            processData: false,
            contentType: false,
            cache: false,
            dataType: 'json',
            success: function (response) {
                if (response !== null && response.success) {
                    $state.transitionTo('moviesAdmin', {}, {
                        reload: true, inherit: true, notify: true
                    });
                } else {
                    alert('failed');
                }
            }
        });
    }
}

MoviesAdminEditController.$inject = ['$scope', '$state', '$http', '$window'];