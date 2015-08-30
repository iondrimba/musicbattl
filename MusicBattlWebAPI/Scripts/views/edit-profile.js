define([
    "models/account"],
    function (
        Account) {
        var EditProfile = Backbone.View.extend({
            el: ".edit-profile",
            initialize: function () {
                this.form = this.$el.find(".formulario");
                $(".datebr").mask('99/99/9999');

                eventHandler.on("onAccountReturn", $.proxy(this.onAccountReturn, this));

                this.txtUserName = this.$el.find(".username");
                this.txtBirthdate = this.$el.find(".byrthdate");
                this.txtCountry = this.$el.find(".country-field");
                this.txtCity = this.$el.find(".city");
                this.txtEmail = this.$el.find(".email");
                this.profileImage = this.$el.find(".profile-img");
                this.userData = {};

                $(".country-field").focus($.proxy(this.onCountryFocus, this));
                $(".country-field").focusout($.proxy(this.onCountryFocusOut, this));

                this.configUpload();
                this.model = new Account();
                this.model.getUserDetails();
            },
            dispose: function () {
                eventHandler.off("onAccountReturn");
                eventHandler.off("onDisplayLoggedUser");
                this.undelegateEvents();
                $(this.el).removeData().unbind();
            },
            render: function (data) {
                var dateFormated,
                    picture = "user-profile-default.png";

                if (data.Birthdate) {
                    dateFormated = moment(musicBattlUtils.formatDate(data.Birthdate)).format("DD/MM/YYYY");
                }

                if (data.Picture.indexOf("mini") > -1) {
                    data.Picture = picture;
                }

                this.userData = data;
                this.txtUserName.val(data.Name);
                this.txtBirthdate.val(dateFormated);
                this.txtCountry.val(data.Country);
                this.txtCity.val(data.City);
                this.txtEmail.val(data.Email);
                this.originalPicture = data.Picture;
                this.picture = this.originalPicture;

                if (master.loginManager.loggedUser.type === musicBattlUtils.enumLoginType.facebook) {
                    this.picture = this.originalPicture + "?height=153";
                }
                if (master.loginManager.loggedUser.type === musicBattlUtils.enumLoginType.googleplus) {
                    this.picture = this.originalPicture.replace(/\=60/, "=227");
                }

                if (master.loginManager.loggedUser.type === musicBattlUtils.enumLoginType.normal) {
                    this.profileImage.attr("src", "/Files/profile/{0}".format(this.picture));
                } else {
                    this.profileImage.attr("src", "{0}".format(this.picture));
                }

                return this;
            },
            configUpload: function () {
                this.data = null;
                var scope = this;
                this.$el.find(".upload").jUpload({
                    dataType: 'json',
                    add: function (e, data) {
                        scope.$el.find(":hidden[name='userId']").val(master.loginManager.loggedUser.id);
                        scope.data = data;
                        data.submit();
                        scope.$el.find('.upload-label').text("uploading...");
                    },
                    done: function (e, data) {
                        musicBattlUtils.deleteCookie("picture");
                        musicBattlUtils.saveCookie("picture", JSON.stringify({ picture: data.result.Picture }));

                        master.header.showLoggedUser({ picture: data.result.Picture });
                        scope.profileImage.attr("src", "/Files/profile/{0}".format(data.result.Picture));
                        toastr.success("Image updated successfully", "Success!");
                        scope.$el.find('.upload-label').text("Change image");
                    },
                    fail: function (e, data) {
                        musicBattlUtils.showWarning(e);
                        scope.$el.find('.upload-label').text("Change image");
                    },
                    progress: function (e, data) {
                        var progress = parseInt(data.loaded / data.total * 100, 10);
                        if (progress > 0) {
                        }

                        if (progress === 100) {
                        }
                    }
                });
            },
            showCountries: function () {
                this.$el.find(".country-list").removeClass("hidden");
                this.$el.find(".country-list").find("hidden");
            },
            hideCountries: function () {
                this.$el.find(".country-list").addClass("hidden");
            },
            selectCountry: function (country) {
                this.$el.find(".country-field").val(country);
                this.hideCountries();
            },
            saveChanges: function () {
                this.userData.Name = this.txtUserName.val();
                this.userData.Birthdate = moment(this.txtBirthdate.val()).format("DD/MM/YYYY");
                this.userData.Country = this.txtCountry.val();
                this.userData.City = this.txtCity.val();
                this.userData.Email = this.txtEmail.val();
                this.userData.Picture = this.originalPicture;
                eventHandler.on("onDisplayLoggedUser", $.proxy(this.onAccountUpdated, this));
                this.model.updateUser(this.userData);
                master.header.showLoggedUser({ name: this.userData.Name });
            },
            events: {
                "click .button-save": "onBtnSaveChangesClick",
                "click .button-change": "onBtnChangePasswordClick",
                "click .upload": "onUploadClick",
                "mousedown .country-list li": "onCountryListClick"
            },
            onBtnChangePasswordClick: function (evt) {
                var path = $(evt.currentTarget).attr("href");
                musicBattlUtils.trackPageview(path);
            },
            onUploadClick: function (evt) {
                var options = {};
                options.category = "EditProfile";
                options.action = "Upload";
                options.label = "";
                musicBattlUtils.trackEvent(options);
            },
            onAccountReturn: function (data) {
                this.render(data);
            },
            onAccountUpdated: function (data) {
                musicBattlUtils.showSuccess("Profile updated successfully.", "Success");
                eventHandler.off("onDisplayLoggedUser");
            },
            onCountryListClick: function (evt) {
                var target = $(evt.currentTarget),
                    country = target.text();
                this.selectCountry(country);
            },
            onCountryFocus: function (evt) {
                this.showCountries();
            },
            onCountryFocusOut: function (evt) {
                this.hideCountries();
            },
            onBtnSaveChangesClick: function (evt) {
                var options = {};
                this.form.validate();
                if (!this.form.valid()) {
                    return false;
                }

                options.category = "EditProfile";
                options.action = "Save";
                options.label = "";
                musicBattlUtils.trackEvent(options);

                evt.preventDefault();
                this.saveChanges();
            }
        });

        return EditProfile;
    });