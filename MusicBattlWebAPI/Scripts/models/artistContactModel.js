define([], function () {
    var ArtistContactModel = Backbone.Model.extend({
        initialize: function () {
            this.url = "/api/Artists/Get";
            this.bind("change", $.proxy(this.onModelChange, this));
        },
        onModelChange: function (view, data) {
        }
    });

    return ArtistContactModel;
});