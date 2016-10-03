var CustomersAdminEditController = function ($scope, $state, $http) {
    $scope.onFormSubmit = function () {
        var formData = new FormData(angular.element('#new-customer-form')[0]);

        $.ajax({
            type: 'POST',
            data: formData,
            url: "http://" + location.host + "/Customers/Save",
            processData: false,
            contentType: false,
            cache: false,
            dataType: 'json',
            success: function (response) {
                if (response !== null && response.success) {
                    $state.transitionTo('customersAdmin', {}, {
                        reload: true, inherit: true, notify: true
                    });
                } else if (response !== null) {
                    response.errors.forEach(function(element, index, array) {
                        angular.element('#new-customer-form-errors')
                        .append('<li>' + element + '</li>');
                    });
                } else {
                    alert('failed');
                }
            }
        });
    }
}

CustomersAdminEditController.$inject = ['$scope', '$state', '$http'];