
(function ($) {
    $.dough = function (name, value, option) {
        // Override options if specified
        option = $.extend({}, $.dough.option, option);

        // We"ll need this later on
        var days = option.expires;

        // Get cookie value
        if (value === undefined) {
            var results = document.cookie.match(name + "=([^;]*)(;|$)");
            if (results != null) {
                if (results[1][0] === "{") {
                    // Parse as JSON
                    return $.parseJSON(results[1]);
                } else {
                    return results[1];
                }
            } else {
                return;
            }
        }

        // Remove cookie
        if (value == "remove") {
            days = -1;
            value = "";
        }

        // Start the baking
        var bake = name + "=" + value;

        // Set the date
        if (days) {
            var date = new Date();
            // Get current date add/remove days "til expired
            date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
            // Convert to UTC string.
            bake += "; expires=" + date.toUTCString();
        }

        // Set the path
        if (option.path == "current") {
            bake += ";";
        } else {
            bake += "; path=" + option.path + ";";
        }

        // Set the domain
        if (option.domain) {
            if (option.domain == "auto") {
                // Get domain name or IP address. Returns 192.168.1.1 or .example.com for use with subdomains
                var ipAddress = window.location.hostname.match(/\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b/g),
					domainName = "." + window.location.hostname;
                // Is locaiton an IP address or domain name?
                var currentLocation = ipAddress ? ipAddress.toString() : domainName.toString();
                bake += "; domain=" + currentLocation + ";";
            } else {
                // If domain specified
                bake += "; domain=" + option.domain + ";";
            }
        }

        // If secure connection required
        if (option.secure) {
            bake += "; secure";
        }

        // Cookie is baked.
        document.cookie = bake;
    };

    // default options
    $.dough.option = {
        expires: false,
        path: "/",
        domain: false,
        secure: false
    };
})(jQuery);