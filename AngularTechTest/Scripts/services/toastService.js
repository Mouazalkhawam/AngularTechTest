(function () {
    try {
        angular.module('MyApp')
            .factory('toastService', function ($timeout) {
                return {
                    show: function (message, type, duration) {
                        var toastType = type || 'info';
                        var toastDuration = duration || 3000;

                        var toastHtml = '<div class="toast-notification toast-' + toastType + '">' +
                            '<span class="toast-message">' + message + '</span>' +
                            '</div>';

                        $('.toast-container').remove();
                        $('body').append('<div class="toast-container"></div>');
                        $('.toast-container').append(toastHtml);

                        $timeout(function () {
                            $('.toast-notification').fadeOut(300, function () {
                                $(this).remove();
                            });
                        }, toastDuration);
                    },

                    success: function (message) {
                        this.show(message, 'success');
                    },

                    error: function (message) {
                        this.show(message, 'error');
                    },

                    warning: function (message) {
                        this.show(message, 'warning');
                    },

                    info: function (message) {
                        this.show(message, 'info');
                    }
                };
            });
    } catch (e) {
        console.log('Toast service waiting for module...');
    }
})();