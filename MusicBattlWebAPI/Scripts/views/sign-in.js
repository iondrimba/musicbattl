define(["models/loginManager"],
    function (LoginManager) {
        var SignIn = Backbone.View.extend({
            el: ".sign-in",
            initialize: function () {
                this.form = this.$el.find(".formulario");
                this.loader = this.$el.find(".loader");
                master.loginManager = new LoginManager({ master: master });

                eventHandler.on("onLoginError", $.proxy(this.onLoginError, this));
            },
            render: function () {
                return this;
            },
            dispose: function () {
                eventHandler.off("onLoginError");
                this.undelegateEvents();
                $(this.el).removeData().unbind();
            },
            events: {
                "click .button-facebook": "onBtnFacebookClick",
                "click .button-google-plus": "onBtnGooglePlusClick",
                "click .button-twitter": "onBtnTwitterClick",
                "click .button-save": "onButtonSignInClick",
                "click .button-create-account": "onButtonCreateAccountClick"
            },
            onLoginError: function (evt) {
                this.loader.addClass("hidden");
            },
            onButtonCreateAccountClick: function (evt) {
                var path = $(evt.currentTarget).attr("href");
                musicBattlUtils.trackPageview(path);
            },
            onBtnFacebookClick: function (evt) {
                var options = {};
                options.category = "Login";
                options.action = "SignIn";
                options.label = "Facebook";
                musicBattlUtils.trackEvent(options);
                master.loginManager.login(musicBattlUtils.enumLoginType.facebook);
            },
            onBtnGooglePlusClick: function (evt) {
                var options = {};
                options.category = "Login";
                options.action = "SignIn";
                options.label = "GooglePlus";
                musicBattlUtils.trackEvent(options);
                master.loginManager.login(musicBattlUtils.enumLoginType.googleplus);
            },
            onBtnTwitterClick: function (evt) {
                var options = {};
                options.category = "Login";
                options.action = "SignIn";
                options.label = "Twitter";
                musicBattlUtils.trackEvent(options);

                this.loader.removeClass("hidden");
                master.loginManager.login(musicBattlUtils.enumLoginType.twitter);
            },
            onButtonSignInClick: function (evt) {
                var options = {};
                this.form.validate();
                if (!this.form.valid()) {
                    return false;
                }
                evt.preventDefault();

                options.category = "Login";
                options.action = "SignIn";
                options.label = "Normal";
                musicBattlUtils.trackEvent(options);

                var obj = {};
                obj.email = this.$el.find(".email").val();
                obj.password = this.$el.find(".password").val();
                this.loader.removeClass("hidden");
                master.loginManager.loginNormal(obj);
            }
        });

        return SignIn;
    });