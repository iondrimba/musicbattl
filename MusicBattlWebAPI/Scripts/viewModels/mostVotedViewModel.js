define(["collections/mostVotedCollection"], function (Collection) {
    var MostVotedViewModel = Backbone.Model.extend({
        url: "",
        initialize: function () {
            this.total = 0;
            this.page = 0;
            this.collection = Collection.toJSON();
            this.bind("change", this.onModelChange);
        },
        map: function (collection) {
            var col = collection,
                i = 0,
                total = 0;
            total = col.length;
            this.collection = Collection.toJSON();
            for (i; i < total; i += 1) {
                if (col[i].ArtistId) {
                    this.collection[i] = col[i];
                }
            } 
        },
        update: function (data) {
            this.total = data.Total;
            this.map(data.Collection);
        },
        onModelChange: function (data) {            
            this.total = data.get("Total");
            this.map(data.get("Collection"));
        }
    });

    return MostVotedViewModel;
});