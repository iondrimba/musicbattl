define([], function () {
    var BattlModel = Backbone.Model.extend({
        initialize: function () {
            this.url = "/api/Battl/VoteSong/";
            this.bind("change", $.proxy(this.onModelChange, this));
        },
        voteSong: function (data) {
            this.url = "/api/Battl/VoteSong/";
            this.save(data, { success: $.proxy(this.onModelChange, this) });
        },
        onModelChange: function (view, data) {
        }
    });

    return BattlModel;
});