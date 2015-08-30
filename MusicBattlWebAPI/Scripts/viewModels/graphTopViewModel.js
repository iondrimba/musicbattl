define([
    "collections/graphTopCollection"],
    function (
        Collection) {
        var GraphTopViewModel = Backbone.Model.extend({
            url: "",
            initialize: function () {
                this.total = 0;
                this.page = 0;
                this.collection = Collection.toJSON();
                this.bind("change", this.onModelChange);
            },
            onModelChange: function (data) {
                this.total = data.get("Total");
                var col = data.get("Collection"),
                    i = 0,
                    total = 0;

                if (col) {
                    total = col.length;
                    this.collection = col;
                }
            }
        });

        return GraphTopViewModel;
    });