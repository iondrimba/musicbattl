define([], function () {
    var TwitterLogin = Backbone.Model.extend({
        initialize: function () {
            this.fetchData();
        },
        getLogedUser: function () {
        },
        login: function () {
            //window.location = "https://api.twitter.com/oauth/request_token";
            var cb = new Codebird();
            cb.setConsumerKey("YxiSRxmvxZAP8H3ykMK9Ww", "BkgyrD3hasEEvksCKGKsLXoKaMDmhCAKciUg2WTgX8");

            cb.__call(
                "oauth_requestToken",
                { oauth_callback: "http://musicbattl.com/home/callback" },
                function (reply) {
                    // stores it
                    cb.setToken(reply.oauth_token, reply.oauth_token_secret);

                    musicBattlUtils.saveCookie("oauth_token", reply.oauth_token);
                    musicBattlUtils.saveCookie("oauth_token_secret", reply.oauth_token_secret);

                    // gets the authorize screen URL
                    cb.__call(
                        "oauth_authorize",
                        {},
                        function (auth_url) {
                            window.location.href = auth_url;
                        }
                    );
                }
            );
        },
        logout: function (id) {
            this.url = "/api/Account/SignOut/{0}".format(id);
            this.save(this.usuario, { success: $.proxy(this.onLogoutReturn, this), error: $.proxy(this.onModelError, this) });
        },
        onLogoutReturn: function (view, data) {
            musicBattlUtils.deleteCookie("oauth_token");
            musicBattlUtils.deleteCookie("oauth_token_secret");

            eventHandler.trigger("onLogoutReturn");
        },
        onLoginReturn: function (result, obj) {
            result.id = obj.changed.UserId;
            result.profileId = obj.changed.ProfileId;
            master.loginManager.activeLogin = master.loginManager.twitter;
            eventHandler.trigger("onLoginReturn", result);
        },
        onModelError: function (view, data) {
            var title = "",
                message = "";

            title = data.statusText;
            message = data.responseText;
            eventHandler.trigger("onLoginError", {});
            musicBattlUtils.showError(message, title);
        },
        fetchData: function () {
            var cb = new Codebird(),
                parameters = {},
                scope = this;

            parameters.oauth_token = musicBattlUtils.cookieExists("oauth_token");
            parameters.oauth_token_secret = musicBattlUtils.cookieExists("oauth_token_secret");
            parameters.oauth_verifier = musicBattlUtils.cookieExists("oauth_verifier");

            if (parameters.oauth_verifier) {
                parameters.oauth_verifier = parameters.oauth_verifier.replace(/oauth_verifier=/, "");

                cb.setConsumerKey("YxiSRxmvxZAP8H3ykMK9Ww", "BkgyrD3hasEEvksCKGKsLXoKaMDmhCAKciUg2WTgX8");

                cb.setToken(parameters.oauth_token, parameters.oauth_token_secret);
                cb.__call(
                    "oauth_accessToken",
                    {
                        oauth_verifier: parameters.oauth_verifier
                    },
                    function (reply) {
                        cb.setToken(reply.oauth_token, reply.oauth_token_secret);

                        musicBattlUtils.saveCookie("oauth_token", reply.oauth_token);
                        musicBattlUtils.saveCookie("oauth_token_secret", reply.oauth_token_secret);

                        //GET USER DETAILS
                        var params = {
                            screen_name: reply.screen_name,
                            user_id: reply.user_id
                        };
                        cb.__call(
                            "users_show",
                            params,
                            function (data) {
                                var obj = {};
                                musicBattlUtils.deleteCookie("oauth_verifier");

                                obj.name = data.name;
                                obj.id = 0;
                                obj.customId = data.id;
                                obj.type = musicBattlUtils.enumLoginType.twitter;
                                obj.picture = data.profile_image_url;

                                scope.url = "/api/Account/SignIn/{0}".format(data.id);
                                scope.save({}, { success: $.proxy(scope.onLoginReturn, scope, obj), error: $.proxy(scope.onModelError, scope) });
                            }
                        );
                    }
                );
            }
        }
    });

    return TwitterLogin;
});