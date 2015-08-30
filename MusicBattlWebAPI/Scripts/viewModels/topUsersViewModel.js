define(["collections/topUsersCollection"], function (Collection) {
    var TopUsersViewModel = Backbone.Model.extend({
        url: "",
        initialize: function () {
            this.total = 0;
            this.page = 0;
            this.collection = Collection.toJSON();
            this.bind("change", this.onModelChange);
        },
        getPage: function (page) {
            this.page = page;
            this.url = "api/TopUsers/Get/0/{0}/{1}".format(page, this.collection.length);
            this.fetch();
        },
        map: function (collection) {
            var col = collection,
                i = 0,
                total = 0;
            total = col.length;
            for (i; i < total; i += 1) {
                if (col[i].ProfileId) {
                    if (col[i].Picture.indexOf("http") == -1) {
                        col[i].Picture = "/Files/profile/mini/{0}".format(col[i].Picture);
                    }

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

    return TopUsersViewModel;
});