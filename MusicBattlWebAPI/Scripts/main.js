(function (window, document) {    
    require.config({
        baseUrl: "/Scripts/",        
        noGlobal: true
    });

    require(['utils.js', 'plugins/plugins.js', "signalr/hubs?", "views/master"], function (utils, plugins, signalR, Master) {
        eventHandler = {};
        _.extend(eventHandler, Backbone.Events);

        toastr.options = {
            "closeButton": false,
            "debug": false,
            "positionClass": "toast-top-full-width",
            "onclick": null,
            "showDuration": "1",
            "hideDuration": "1",
            "timeOut": "1500",
            "extendedTimeOut": "10000"
        }

        BrowserDetect.init();
        var browser = BrowserDetect.browser.toLowerCase(),
            os = BrowserDetect.OS.toLowerCase().replace(/" "/, ""),
            version = BrowserDetect.version,
            typeos = "{0} {1}-{2} {3}".format(browser, browser, version, os);

        window.typeos = os.toLowerCase();
        window.userBrowser = browser;

        $("html").addClass(typeos);
        toastr = toastr;
        Backbone.history.start();
        master = new Master();
    });
}(this, document));