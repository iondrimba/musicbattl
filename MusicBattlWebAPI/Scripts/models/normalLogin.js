define([], function () {
    var NormalLogin = Backbone.Model.extend({
        initialize: function () {
            this.usuario = {};
            this.usuario.Name = "";
            this.usuario.Password = "";
        },
        getLogedUser: function () {
        },
        login: function (data) {
            this.url = "/api/Account/SignIn";
            this.usuario.Password = data.password;
            this.usuario.Email = data.email;
            this.save(this.usuario, { success: $.proxy(this.onLoginReturn, this), error: $.proxy(this.onModelError, this) });
        },
        logout: function (id) {
            this.url = "/api/Account/SignOut/{0}".format(id);
            this.save(this.usuario, { success: $.proxy(this.onLogoutReturn, this), error: $.proxy(this.onModelError, this) });
        },
        fetchData: function () {
        },
        onLoginReturn: function (view, data) {
            var obj = {};
            obj.name = data.Name;
            obj.id = data.UserId;
            obj.profileId = data.ProfileId;
            obj.type = musicBattlUtils.enumLoginType.normal;

            musicBattlUtils.saveCookie("user", JSON.stringify(obj));
            musicBattlUtils.saveCookie("picture", JSON.stringify({ picture: data.Picture }));
            obj.picture = data.Picture;

            eventHandler.trigger("onLoginReturn", obj);
        },
        onLogoutReturn: function (view, data) {
            eventHandler.trigger("onLogoutReturn", data);
        },
        onModelError: function (view, data) {
            var title = "",
                message = "";

            title = data.statusText;
            message = data.responseText;
            eventHandler.trigger("onLoginError", {});
            musicBattlUtils.showError(message, title);
        }
    });

    return NormalLogin;
});