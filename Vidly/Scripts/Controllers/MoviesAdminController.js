var MoviesAdminController = function ($scope, $state, $window, $templateCache) {
    // TODO: Same thing as with CustomersAdminController.
    $templateCache.removeAll();

    $("#movies").on("click", ".movie-delete", function () {
        var button = $(this);

        if (confirm("Are you sure you want to delete this movie?")) {
            $.ajax({
                url: "http://" + location.host + "/movies/delete/" + button.attr("data-movie-id"),
                method: "POST",
                success: function (response) {
                    if (response !== null && response.success) {
                        button.parents("tr").remove();
                    } else {
                        alert('failed');
                    }
                }
            });
        }
    });
}

MoviesAdminController.$inject = ['$scope', '$state', '$window', '$templateCache'];