define([], function () {
    var ChartsRankingViewModel = Backbone.Model.extend({
        url: "api/Charts/LoadData/",
        initialize: function () {            
            this.bind("change", this.onModelChange);
        },
        onModelChange: function (data) {
        }
    });

    return ChartsRankingViewModel;
});