define([
        "views/battlsWon",
        "views/battlsLost",
        "views/userFavorites",
        "models/account"
],
    function (
        BattlsWonView,
        BattlsLostView,
        UserFavoritesView,
        Account) {
        var UserProfile = Backbone.View.extend({
            el: ".user-profile",
            events: {
                "click .btn-edit": "onBtnEditClick"
            },
            initialize: function () {
                eventHandler.on("onAccountReturn", $.proxy(this.render, this));

                if (master.loginManager.loggedUser.id === master.idSystemUser) {
                    this.$el.find('.btn-edit').remove();
                } else {
                    this.$el.find('.btn-edit').removeClass('hidden');
                }

                this.battlsWon = new BattlsWonView();
                this.battlsLost = new BattlsLostView();
                this.userFavoritesView = new UserFavoritesView();
                this.model = new Account();
                this.model.getUserDetails();
            },
            onBtnEditClick: function (evt) {
                var path = $(evt.currentTarget).attr("href");
                musicBattlUtils.trackPageview(path);
            },
            onLoginReturn: function (result) {
                master.navigate("#/site/home");
            },
            dispose: function () {
                this.undelegateEvents();
                $(this.el).removeData().unbind();
            },
            render: function (data) {
                var cityCountry = "";
                this.userData = data;
                this.$el.find(".name").text(data.Name);

                if (data.City) {
                    cityCountry = data.City;
                }

                if (data.Country) {
                    if (data.City) {
                        cityCountry = "{0}-{1}".format(data.City, data.Country);
                    } else {
                        cityCountry = data.Country;
                    }
                }

                this.$el.find(".city-country").text(cityCountry);
                this.profileImage = this.$el.find(".profile-img");
                this.originalPicture = data.Picture;
                this.picture = data.Picture;

                if (master.loginManager.loggedUser.profileId) {
                    this.$el.find(".user-profile-text").removeClass("hidden");
                } else {
                    this.$el.find(".user-profile-text").addClass("hidden");
                }

                if (master.loginManager.loggedUser.type === musicBattlUtils.enumLoginType.facebook) {
                    this.picture = this.originalPicture + "?height=153";
                }
                if (master.loginManager.loggedUser.type === musicBattlUtils.enumLoginType.googleplus) {
                    this.picture = this.originalPicture.replace(/\=60/, "=227");
                }

                if (this.picture) {
                    if (this.picture.indexOf("profile-mini-user") === -1) {
                        if (this.picture.indexOf("http") > -1) {
                            this.profileImage.attr("src", this.picture);
                        } else {
                            this.profileImage.attr("src", "/Files/profile/{0}".format(this.picture));
                        }                        
                    }
                }
                return this;
            }
        });

        return UserProfile;
    });