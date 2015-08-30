define([ "collections/versusCollection"], function ( Collection) {
    var BattlsWon = Backbone.Model.extend({
        initialize: function () {
            this.userId = master.loginManager.loggedUser.profileId;
            this.total = 0;
            this.collection = Collection;
            this.url = "/api/UserProfile/GetBattlsWon/{0}".format(this.userId);
            this.bind("change", this.onModelChange);
            this.fetch({ success: $.proxy(this.onModelChange, this) });
        },
        onModelChange: function (data) {
            console.log("model battls-won", data.get("Total"));
        }
    });

    return BattlsWon;
});