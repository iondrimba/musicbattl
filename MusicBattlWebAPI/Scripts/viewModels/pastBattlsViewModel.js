define(["collections/versusCollection"], function (Collection) {
    var PastBattlsViewModel = Backbone.Model.extend({
        url: "api/PastBattls",
        initialize: function () {
            this.total = 0;
            this.page = 0;
            this.collection = Collection.toJSON();
            this.bind("change", this.onModelChange);
        },
        getPage: function (page) {
            this.page = page;
            this.url = "api/PastBattls/Get/0/{0}/{1}".format(page, this.collection.length);
            this.fetch();
        },
        map: function (collection) {
            var col = collection,
                i = 0,
                total = 0;
            total = col.length;
            for (i; i < total; i += 1) {
                if (col[i].BattlId) {
                    this.collection[i] = col[i];
                }
            }
        },
        update: function (data) {
            this.total = data.total;
            this.map(data.Collection);
        },
        onModelChange: function (data) {
            this.total = data.get("Total");
            this.map(data.get("Collection"));
        }
    });

    return PastBattlsViewModel;
});