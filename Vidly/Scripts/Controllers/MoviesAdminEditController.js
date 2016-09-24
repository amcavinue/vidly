﻿var MoviesAdminEditController = function ($scope, $state, $http) {
    $scope.onFormSubmit = function () {
        var formData = new FormData(angular.element('#new-movie-form')[0]);

        // This works now, but it doesn't work when required fields are empty.
        // The fail needs to handle that, and then send info back to the form...
        // State.go needs to resend/update from the database.
        $.ajax({
            type: 'POST',
            data: formData,
            url: '../../Movies/Save',
            processData: false,
            contentType: false,
            cache: false,
            dataType: 'json'
        })
        .done(function () {
            alert('success');
            $state.go('moviesAdmin');
        })
        .fail(function () {
            alert('failed');
            $state.go('moviesAdmin');
        });
    }
}

MoviesAdminEditController.$inject = ['$scope', '$state', '$http'];