define([], function () {
    var Header = Backbone.View.extend({
        el: ".header-ph",
        initialize: function () {
            this.btnSignInOut = this.$el.find(".button-signin");
            this.userName = this.$el.find(".username");
            this.profileImage = this.$el.find(".profile-image");
        },
        render: function () {
        },
        showLoggedUser: function (data) {
            this.userName.text(data.name);
            this.btnSignInOut.find("span").text("Sign out");
            this.btnSignInOut.unbind("click");
            this.btnSignInOut.click(this.onSignOutClick);

            if (data.picture && data.picture.indexOf("http") > -1) {
                this.profileImage.attr("src", data.picture);
            } else if(data.picture){
                this.profileImage.attr("src", "/Files/profile/small/{0}".format(data.picture));
            }            
        },
        showVisitor: function (data) {
            this.userName.text(data.name);
            this.btnSignInOut.find("span").text("Sign in");
            this.btnSignInOut.unbind("click");
            this.profileImage.attr("src", "/Files/profile/small/{0}".format(data.picture));
        },
        selectMenu: function (elmt) {
            this.$el.find(".full-opacity").removeClass("full-opacity");
            elmt.addClass("full-opacity");
        },
        selectMenuItemByHash: function (hash) {
            var selector = ".btn-" + hash,
                elmt = {};

            if (hash.indexOf("artist-contact") > -1) {
                selector = ".btn-artists";
            } else {
                this.$el.find(".full-opacity").removeClass("full-opacity");
            }

            elmt = $(selector);

            if (elmt.length) {
                this.selectMenu(elmt);
            }
        },
        events: {
            "click .social-button": "onSocialBtnClick",
            "click .btn-home": "onBtnHomeClick",
            "click .btn-charts-ranking": "onBtnChartsClick",
            "click .btn-artists": "onBtnArtistsClick",
            "click .user-login-image": "onProfileImageClick",
            "click .button-signin": "onBtnSignInClick",
            "click .logo": "onLogoClick",
            "click .muted": "onMutedClick",
            "click .bars-header": "onBarsHeaderClick"
        },
        onMutedClick: function (evt) {
            master.toogleSoundWave();
        },
        onBarsHeaderClick:function(evt) {
            master.toogleSoundWave();
        },
        onLogoClick: function (evt) {
            if (master.currentView.$el.selector !== ".home") {
                master.navigate("#/site/home");
            }            
        },
        onBtnSignInClick: function (evt) {
            musicBattlUtils.trackPageview("#/site/sign-in");
        },
        onSignOutClick: function (evt) {
            musicBattlUtils.trackPageview("Account/PostSignOut");
            evt.preventDefault();
            master.loginManager.logout();
        },
        onBtnHomeClick: function (evt) {
            this.selectMenu($(evt.currentTarget));
            if (master.currentView.$el.selector !== ".home") {
                master.navigate("#/site/home");
            }            
        },
        onBtnChartsClick: function (evt) {
            this.selectMenu($(evt.currentTarget));
            master.navigate("#/site/charts-ranking");
        },
        onBtnArtistsClick: function (evt) {
            this.selectMenu($(evt.currentTarget));
            master.navigate("#/site/artists");
        },
        onProfileImageClick: function (evt) {
            master.navigate("#/site/user-profile");
        },
        onSocialBtnClick: function (evt) {
            var social = "",
                options = {};

            social = $(evt.target).attr("class").split(" ")[0]

            options.category = "Home";
            options.action = "Social";
            options.label = social;
            musicBattlUtils.trackEvent(options);
        }
    });

    return Header;
});