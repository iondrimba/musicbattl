define([], function () {
    var Account = Backbone.Model.extend({
        initialize: function () {
        },
        create: function (user) {
            this.url = "/api/Account/Create";

            this.usuario = {};
            this.usuario.UsuarioId = user.id;
            this.usuario.CustomId = user.customId;
            this.usuario.Name = user.name;
            this.usuario.Email = user.email;
            this.usuario.ProfileId = user.profileId;
            this.usuario.Birthdate = user.birthdate || "";
            this.usuario.Password = "";
            this.usuario.Created = "";
            this.usuario.Udated = "";
            this.usuario.Gender = user.gender;
            this.usuario.Picture = user.picture;
            this.usuario.SocialType = user.type;
            this.save(this.usuario, { success: $.proxy(this.onModelChange, this), error: $.proxy(this.onModelError, this) });
        },
        remove: function (userId) {
        },
        update: function (user) {
        },
        getUserDetails: function () {
            this.url = "/api/Account/UserDetails/{0}".format(master.loginManager.loggedUser.id);
            this.fetch({ success: $.proxy(this.onModelFetch, this), error: $.proxy(this.onModelError, this) });
        },
        updateUser: function (data) {
            this.url = "/api/Account/UserUpdate/";
            this.save(data, { success: $.proxy(this.onModelUpdated, this), error: $.proxy(this.onModelError, this) });
        },
        changePassword: function (data) {
            this.url = "/api/Account/ChangePassword/";
            this.save(data, { success: $.proxy(this.onModelPasswordUpdated, this), error: $.proxy(this.onModelError, this) });
        },
        createUser: function (data) {
            this.url = "/api/Account/Create/";
            this.save(data, { success: $.proxy(this.onModelChange, this), error: $.proxy(this.onModelError, this) });
        },
        onModelChange: function (view, data) {
            var obj = this.mapDataUser(data);
            eventHandler.trigger("onAccountCreate", obj);
        },
        onModelPasswordUpdated: function (view, data) {
            var obj = this.mapDataUser(data);
            eventHandler.trigger("onPasswordChanged", obj);
        },
        onModelError: function (view, data) {
            var title = "",
                message = "";

            title = data.statusText;
            message = data.responseText;
            musicBattlUtils.showError(message, title);
        },
        onModelUpdated: function (view, data) {
            var obj = this.mapDataUser(data);
            eventHandler.trigger("onDisplayLoggedUser", obj);
        },
        onModelFetch: function (view, data) {
            eventHandler.trigger("onAccountReturn", data);
        },
        mapDataUser: function (data) {
            var obj = {};
            obj.name = data.Name;
            obj.id = data.UserId;
            obj.profileId = data.ProfileId;
            obj.picture = data.Picture;
            obj.type = 0;

            if (this.usuario  && this.usuario.SocialType) {
                obj.type = this.usuario.SocialType;
            }

            return obj;
        }
    });
    return Account;
});