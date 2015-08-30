(function (window, document) {
    var musicBattlUtils = {
        enumLoginType: {
            normal: 0,
            facebook: 1,
            googleplus: 2,
            twitter: 3
        },
        saveCookie: function (key, value) {
            $.dough(key, value);
        },
        deleteCookie: function (key, params) {
            if (params) {
                $.dough(key, "remove", params);
            } else {
                $.dough(key, "remove");
            }
        },
        trackEvent: function (options) {
            //ga('send', 'event', {
            //    eventCategory: options.category,
            //    eventAction: options.action,
            //    eventLabel: options.label,
            //    eventValue: 0
            //});
        },
        openWindow: function (options) {
            var url = options.url,
                name = options.name,
                features = options.features,
                replace = options.replace,
                win = options.window;

            if (win === undefined) {
                win = window;
            }

            win.open(url, name, features, replace);
        },
        trackPageview: function (url) {
            //ga('send', {
            //    'hitType': 'pageview',
            //    'page': url
            //});
        },
        showInfo: function (message, title) {
            $("#toast-container").remove();
            toastr.info(message, title);
        },
        showSuccess: function (message, title) {
            $("#toast-container").remove();
            toastr.success(message, title);
        },
        showError: function (message, title) {
            $("#toast-container").remove();
            toastr.error(message, title);
        },
        showWarning: function (message, title) {
            $("#toast-container").remove();
            toastr.warning(message, title);
        },
        cookieExists: function (key) {
            return $.dough(key);
        },
        convertToNumber: function (text, defaultValue) {
            var retorno = defaultValue;

            retorno = parseInt(text, 10);

            if (isNaN(retorno)) {
                retorno = defaultValue;
            }

            return retorno;
        },
        formatDate: function (date) {
            var retorno;/*1982-07-09T00:00:00*/

            if (date) {
                retorno = date.replace(/\T.+/g, "");
            }
            return retorno;
        },
        convertMillisecondsToDigitalClock: function (ms) {
            var phours = Math.floor(ms / 3600000), // 1 Hour = 36000 Milliseconds
                pminutes = Math.floor((ms % 3600000) / 60000), // 1 Minutes = 60000 Milliseconds
                pseconds = Math.floor(((ms % 360000) % 60000) / 1000); // 1 Second = 1000 Milliseconds
            return {
                hours: phours,
                minutes: (pminutes < 10 ? '0' : '') + pminutes,
                seconds: (pseconds < 10 ? '0' : '') + pseconds,
                clock: pminutes + ":" + pseconds
            };
        },
        stringLimit: function (text, size) {
            var retorno = text;

            if (text.length > size) {
                retorno = text.substr(0, size);
            }

            return retorno;
        }
    };

    window.musicBattlUtils = musicBattlUtils;
}(this, document));