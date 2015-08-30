define([ "models/account"], function ( Account) {
    var CreateAccount = Backbone.View.extend({
        el: ".create-account",
        initialize: function () {
            this.form = this.$el.find(".formulario");
            $(".datebr").mask('99/99/9999');
            eventHandler.on("onAccountCreate", $.proxy(this.onAccountCreated, this));

            this.loader = this.$el.find(".loader");
            this.txtUserName = this.$el.find(".name");
            this.txtBirthdate = this.$el.find(".birthdate");
            this.txtEmail = this.$el.find(".email");
            this.txtPassword = this.$el.find(".password");
            this.profileImage = "profile-mini-user.png";

            this.userData = {};
            this.model = new Account();
        },
        dispose: function () {
            eventHandler.off("onAccountCreate");
        },
        render: function () {
            return this;
        },
        events: {
            "click .btn-save": "onBtnSaveClick",
            "click .radio-group-item": "onRadioClick"
        },
        getGenderSelected: function () {
            var selectedValue = this.$el.find(".radio-group-item.active").data("val");
            return selectedValue;
        },
        save: function () {
            this.userData = {};
            this.userData.Name = this.txtUserName.val();
            this.userData.Birthdate = moment(musicBattlUtils.formatDate(this.txtBirthdate.val())).format("DD/MM/YYYY");
            this.userData.Email = this.txtEmail.val();
            this.userData.Picture = this.profileImage;
            this.userData.Password = this.txtPassword.val();
            this.userData.Gender = this.getGenderSelected();

            this.model.createUser(this.userData);
        },
        onBtnSaveClick: function (evt) {
            var options = {};
            this.form.validate();
            if (!this.form.valid()) {
                return false;
            }

            options.category = "Account";
            options.action = "Create";
            options.label = "";
            musicBattlUtils.trackEvent(options);

            evt.preventDefault();
            this.loader.removeClass("hidden");

            this.save();
        },
        onAccountCreated: function (data) {
            var obj = { password: this.userData.Password, email: this.userData.Email };
            eventHandler.off("onAccountCreate");
            master.loginManager.loginNormal(obj);
        },
        onRadioClick: function (evt) {
            var target = $(evt.currentTarget);
            this.$el.find(".radio-group-item").removeClass("active");
            target.addClass("active");
        }
    });

    return CreateAccount;
});