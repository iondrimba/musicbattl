define(["models/normalLogin"],
    function (NormalLogin) {
        var LoginManager = Backbone.Model.extend({
            initialize: function (options) {
                var i,
                    nameType;

                this.activeLogin = {};
                this.visitor = { name: "System", id: options.master.idSystemUser, profileId: options.master.idProfileSystemUser, customId: 0, type: 0, accessToken: null, picture: "4l5kvimulrb875328-15082706084508.jpg", gender: "M" };
                this.loggedUser = this.checkCookie() || this.visitor;

                this.NormalLogin = NormalLogin;
                this.normal;

                if (this.loggedUser.id !== options.master.idSystemUser) {
                    this.activetLogin(this.loggedUser.type);
                } else {
                    this.normal = new NormalLogin();
                }
                eventHandler.trigger("onDisplayLoggedUser", this.loggedUser);
            },
            toUpper: function (char) {
                return char.toUpperCase();
            },
            dispose: function () {
                this.loggedUser = this.visitor;
            },
            checkCookie: function () {
                var user = {};

                user = musicBattlUtils.cookieExists("user");

                if (user) {
                    user.picture = musicBattlUtils.cookieExists("picture").picture;
                }

                return user;
            },
            getLogedUser: function () {
                return this.loggedUser;
            },
            activetLogin: function (type) {
                for (i in musicBattlUtils.enumLoginType) {
                    if (musicBattlUtils.enumLoginType.hasOwnProperty(i)) {
                        nameType = "{0}Login".format(i.replace(/\b./g, $.proxy(this.toUpper, this)));
                        if (type === musicBattlUtils.enumLoginType[i] && this[nameType] != undefined) {
                            this[i] = new this[nameType]();
                            this.activeLogin = this[i];
                        }
                    }
                }
            },
            login: function (type) {
                var i;
                for (i in musicBattlUtils.enumLoginType) {
                    if (musicBattlUtils.enumLoginType.hasOwnProperty(i)) {
                        if (musicBattlUtils.enumLoginType[i] === type) {
                            this["{0}Login".format(i)]();
                        }
                    }
                }
            },
            loginNormal: function (obj) {
                this.activeLogin = this.normal;
                this.normal.login(obj);
            },
            logout: function () {
                musicBattlUtils.deleteCookie("user");
                musicBattlUtils.deleteCookie("picture");
                this.activeLogin.logout(this.loggedUser.id);
            }
        });

        return LoginManager;
    });