(function () {
    try {
        angular.module('MyApp')
            .directive('loader', function () {
                return {
                    restrict: 'A',
                    scope: {
                        isLoading: '=loader',
                        clickAction: '&'
                    },
                    link: function (scope, element, attrs) {
                        var originalText = element.html();

                        element.bind('click', function () {
                            if (!scope.isLoading) {
                                scope.$apply(function () {
                                    scope.isLoading = true;
                                });

                                element.html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Saving...');
                                element.prop('disabled', true);

                                var result = scope.clickAction();

                                if (result && result.finally) {
                                    result.finally(function () {
                                        scope.$apply(function () {
                                            scope.isLoading = false;
                                        });
                                        element.html(originalText);
                                        element.prop('disabled', false);
                                    });
                                } else {
                                    scope.$apply(function () {
                                        scope.isLoading = false;
                                    });
                                    element.html(originalText);
                                    element.prop('disabled', false);
                                }
                            }
                        });
                    }
                };
            });
    } catch (e) {
        console.log('Loader directive waiting for module...');
    }
})();