define([], function () {
    var BattlInfoViewModel = Backbone.Model.extend({
        url: "/api/PastBattls/ById/{0}",
        initialize: function () {
            this.url = this.url.format(this.attributes.artistId);
            this.bind("change", this.onModelChange);
        },
        onModelChange: function (data) {            
            this.data = data.changed;
        }
    });

    return BattlInfoViewModel;
});