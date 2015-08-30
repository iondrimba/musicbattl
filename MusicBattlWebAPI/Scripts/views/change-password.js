define([ "models/account"], function ( Account) {
    var ChangePassword = Backbone.View.extend({
        el: ".change-password",
        initialize: function () {
            this.render();
        },
        validForm: function () {
            var retorno = true;

            retorno = this.txtNewPass.val() === this.txtConfirmPass.val();

            return retorno;
        },
        render: function () {
            this.form = this.$el.find(".formulario");
            this.account = new Account();
            this.txtCurrentPass = this.$el.find(".current-pass");
            this.txtNewPass = this.$el.find(".new-pass");
            this.txtConfirmPass = this.$el.find(".confirm-pass");

            eventHandler.on("onPasswordChanged", $.proxy(this.onPasswordChange, this));

            return this;
        },
        dispose: function () {
            eventHandler.off("onPasswordChanged");
        },
        events: {
            "click .button-save": "onButtoSaveClick"
        },
        onPasswordChange: function (data) {
            musicBattlUtils.showSuccess("Password updated successfully.", "Success!");
            this.dispose();
            master.navigate("#/site/edit-profile");
            master.modal.close();
        },
        onButtoSaveClick: function (evt) {
            var valid = false,
                data = {};

            this.form.validate();
            if (!this.form.valid() | !this.validForm()) {
                musicBattlUtils.showError("New password and Confirm password don't match.", "Error!");
                return false;
            }

            var options = {};
            options.category = "EditProfile";
            options.action = "Password";
            options.label = "Save";
            musicBattlUtils.trackEvent(options);

            data.IdUsuario = master.loginManager.loggedUser.id;
            data.CurrentPassword = this.txtCurrentPass.val();
            data.NewPassword = this.txtNewPass.val();
            data.ConfirmPassword = this.txtConfirmPass.val();

            evt.preventDefault();
            this.account.changePassword(data);
        }
    });

    return ChangePassword;
});