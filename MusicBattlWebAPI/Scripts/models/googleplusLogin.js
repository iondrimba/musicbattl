define([], function () {
    var GoogleplusLogin = Backbone.Model.extend({
        initialize: function () {
            this.returnedUser = {};
            this.loadedUser = false;
        },
        getLogedUser: function (accessToken) {
            var obj,
                scope = this;

            gapi.client.load("plus", "v1", function () {
                var request = gapi.client.plus.people.get({
                    "userId": "me"
                });
                request.execute(function (data) {
                    obj = {};
                    obj.name = data.displayName;
                    obj.id = 0;
                    obj.customId = data.id;
                    obj.gender = data.gender.replace(/male/, "M").replace(/Female/, "F");
                    obj.picture = data.image.url.replace(/\?sz=50/, "?sz=60");
                    obj.type = musicBattlUtils.enumLoginType.googleplus;

                    scope.returnedUser = obj;

                    if (!scope.loadedUser) {
                        scope.loadedUser = true;
                        scope.url = "/api/Account/SignIn/{0}".format(data.id);
                        scope.save({}, { success: $.proxy(scope.onLoginReturn, scope, obj), error: $.proxy(scope.onModelError, scope) });
                    }
                });
            });
        },
        login: function () {
            var scope = this,
                additionalParams;

            window.signinCallback = function (data) {
                if (data.error) {
                    return;
                }
                scope.getLogedUser(data.access_token);
            };

            additionalParams = {
                'callback': signinCallback,
                'clientid': '785627913508.apps.googleusercontent.com',
                'cookiepolicy': 'single_host_origin',
                'requestvisibleactions': 'http://schemas.google.com/AddActivity',
                'scope': 'https://www.googleapis.com/auth/plus.login'
            };
            gapi.auth.signIn(additionalParams);
        },
        logout: function (id) {
            this.url = "/api/Account/SignOut/{0}".format(id);
            this.save(this.usuario, { success: $.proxy(this.onLogoutReturn, this), error: $.proxy(this.onModelError, this) });
        },
        onLogoutReturn: function (view, data) {
            eventHandler.trigger("onLogoutReturn");
        },
        onLoginReturn: function (result, obj) {
            result.id = obj.changed.UserId;
            result.profileId = obj.changed.ProfileId;
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
        }
    });

    return GoogleplusLogin;
});