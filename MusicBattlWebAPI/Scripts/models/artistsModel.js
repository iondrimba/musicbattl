define([], function () {
    var ArtistsModel = Backbone.Model.extend({
        initialize: function () {
            this.url = "/api/Artists/Get";
            this.bind("change", $.proxy(this.onModelChange, this));
        },
        voteSong: function (data) {
            this.save(data, { success: $.proxy(this.onModelChange, this) });
        },
        onModelChange: function (view, data) {
        }
    });

    return ArtistsModel;
});