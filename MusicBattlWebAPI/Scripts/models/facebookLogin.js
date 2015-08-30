define([], function () {
    var FacebookLogin = Backbone.Model.extend({
        initialize: function () {
            this.loadedUser = false;
        },
        getLogedUser: function () {
            var scope = this;
            FB.getLoginStatus(function (response) {
                if (response.status === 'connected') {
                    scope.fetchData();
                }
            });
        },
        login: function () {
            var scope = this;
            FB.getLoginStatus(function (response) {
                FB.Event.subscribe('auth.authResponseChange', function (response) {
                    if (response.status === 'connected') {
                        scope.getLogedUser();
                    }
                });

                if (response.status === 'connected') {
                    scope.fetchData();
                } else {
                    FB.login();
                }
            });
        },
        logout: function (id) {
            this.url = "/api/Account/SignOut/{0}".format(id);
            this.save(this.usuario, { success: $.proxy(this.onLogoutReturn, this), error: $.proxy(this.onModelError, this) });
        },
        onLogoutReturn: function (view, data) {
            this.logoutFaceBook();
        },
        onLoginReturn: function (obj) {
            eventHandler.trigger("onLoginReturn", obj);
        },
        onModelError: function (view, data) {
            var title = "",
                message = "";

            title = data.statusText;
            message = data.responseText;
            eventHandler.trigger("onLoginError", {});
            musicBattlUtils.showError(message, title);
        },
        logoutFaceBook: function () {
            FB.getLoginStatus(function (response) {
                if (response.status === 'connected') {
                    FB.logout(function (response) {
                        eventHandler.trigger("onLogoutReturn");
                    });
                }
            });
        },
        fetchData: function () {
            var obj,
                scope = this;

            FB.api('/me', function (response) {
                obj = {};
                obj.name = response.name;
                obj.id = 0;
                obj.customId = response.id;
                obj.picture = "https://graph.facebook.com/{0}/picture".format(response.username);
                obj.gender = response.gender.replace(/male/, "M").replace(/Female/, "F");
                obj.type = musicBattlUtils.enumLoginType.facebook;

                FB.Event.unsubscribe('auth.authResponseChange', scope);

                if (!scope.loadedUser) {
                    scope.loadedUser = true;
                    scope.url = "/api/Account/SignIn/{0}".format(response.id);
                    scope.save({}, { success: $.proxy(scope.onLoginReturn, scope, obj), error: $.proxy(scope.onModelError, scope) });
                }
            });
        }
    });

    return FacebookLogin;
});