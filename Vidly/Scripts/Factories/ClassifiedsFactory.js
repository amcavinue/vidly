var ClassifiedsFactory = function ($http) {
    return {
        getClassifieds: function() {
            return $http.get('../temp/classifieds.json');
        }
    }
}

ClassifiedsFactory.$inject = ['$http'];
