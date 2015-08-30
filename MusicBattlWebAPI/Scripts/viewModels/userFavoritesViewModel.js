define([ "collections/userFavoritesCollection"], function ( Collection) {
    var UserFavoritesViewModel = Backbone.Model.extend({
        url: "",
        initialize: function () {
            this.total = 0;
            this.page = 0;
            this.collection = this.defaultCollection();
            this.bind("change", this.onModelChange);
        },
        getPage: function (page) {
            this.page = page;
            this.collection = this.defaultCollection();
            this.fetch();
        },
        defaultCollection: function () {
            return this.collection = Collection.toJSON().filter(function (item) {
                return item.Image = "/img/album/small/{0}".format(item.AlbumCover);
            });
        },
        onModelChange: function (data) {
            this.total = data.get("Total");
            var col = data.get("Collection"),
                i = 0,
                total = 0;
            total = col.length;
            for (i; i < total; i += 1) {
                if (col[i].ArtistId) {
                    this.collection[i] = col[i];
                    this.collection[i].Image = "/img/album/small/{0}".format(col[i].AlbumCover);
                }
            }
        }
    });

    return UserFavoritesViewModel;
});