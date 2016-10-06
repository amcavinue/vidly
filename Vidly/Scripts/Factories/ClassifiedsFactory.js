var ClassifiedsFactory = function ($http) {
    return {
        getClassifieds: function () {
            return $http.get("http://" + location.host + "/api/movies")
            .then(function (response) {
                return response.data;
            })
        }
    }
}

ClassifiedsFactory.$inject = ['$http'];
