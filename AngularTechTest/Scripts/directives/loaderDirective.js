angular.module('MyApp').directive('loader', function () {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            var originalText = element.html();

            element.bind('click', function () {
                if (!scope[attrs.loader]) {
                    scope.$apply(function () {
                        scope[attrs.loader] = true;
                    });

                    element.html('<span class="spinner-border"></span> Saving...');
                    element.prop('disabled', true);

                    var result = scope.$eval(attrs.ngClick);

                    if (result && result.finally) {
                        result.finally(function () {
                            scope.$apply(function () {
                                scope[attrs.loader] = false;
                            });
                            element.html(originalText);
                            element.prop('disabled', false);
                        });
                    }
                }
            });
        }
    };
});