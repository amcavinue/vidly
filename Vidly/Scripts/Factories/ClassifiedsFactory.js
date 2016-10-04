var ClassifiedsFactory = function ($http) {
    return {
        getClassifieds: function () {
            return $http.get("http://" + location.host + "/api/movies")
            .then(function (response) {
                return response.data;
            })

            return $http.get("http://" + location.host + "/temp/classifieds.json").then(function(res) { return res.data});
        }
    }
}

ClassifiedsFactory.$inject = ['$http'];
