var ReadMoreDirective = function ($timeout) {
    return {
        link: function ($scope, element, attrs) {
            $scope.$on('cardsLoaded', function () {
                $timeout(function () {
                    $('.read-more').readmore('destroy');
                    $('.read-more').readmore();
                 }, 0, false);
            })
        }
    }        
}

ReadMoreDirective.$inject = ['$timeout'];
