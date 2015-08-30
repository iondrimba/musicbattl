define(["collections/allTimeWinnersCollection"], function (Collection) {
    var AllTimeWinnersViewModel = Backbone.Model.extend({
        url: "/api/AllTimerWinners/",
        initialize: function () {
            this.total = 0;
            this.page = 0;
            this.collection = Collection.toJSON();
            this.bind("change", this.onModelChange);
        },
        getPage: function (page) {
            this.page = page;
            this.collection = Collection.toJSON();
            this.collection = Collection.toJSON().filter(function (model) {
                return model.Image = "/img/album/{0}".format(model.AlbumCover);
            });
            this.url = "/api/AllTimerWinners/Get/0/{0}/{1}".format(this.page, this.collection.length);
            this.fetch();
        },
        map: function (collection) {
            var col = collection,
                i = 0,
                total = 0;
            total = col.length;
            for (i; i < total; i += 1) {
                if (col[i].ArtistId) {
                    this.collection[i] = col[i];
                    this.collection[i].Image = "/img/album/mini/{0}".format(col[i].AlbumCover);
                }
            }
        },
        update: function (data) {
            this.total = data.Total;
            this.map(data.Collection);
        },
        onModelChange: function (data) {
            console.log(data);
            this.total = data.get("Total");
            this.map(data.get("Collection"));
        }
    });

    return AllTimeWinnersViewModel;
});