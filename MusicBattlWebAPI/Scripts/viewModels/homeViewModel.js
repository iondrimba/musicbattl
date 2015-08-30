define([], function () {
    var HomeViewModel = Backbone.Model.extend({
        url: "api/Battl/LoadData/",
        initialize: function () {            
            this.bind("change", this.onModelChange);
        },
        onModelChange: function (data) {
        }
    });

    return HomeViewModel;
});