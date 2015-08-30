define([ "collections/artistContactCollection"], function ( Collection) {
    var ArtistContactViewModel = Backbone.Model.extend({
        url: "/api/ArtistContact/Get/{0}",
        initialize: function () {
            this.url = this.url.format(this.attributes.artistId);
            this.total = 0;
            this.page = 0;
            this.collection = Collection.toJSON();
            this.bind("change", this.onModelChange);
        },
        onModelChange: function (data) {
            this.collection[0] = data.changed;
        }
    });

    return ArtistContactViewModel;
});