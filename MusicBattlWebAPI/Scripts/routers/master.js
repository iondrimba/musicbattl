define([], function () {
    var MasterRouter = Backbone.Router.extend({
        routes: {
            "site/:area": "onAreaChange",
            "site/:area/:id/:title": "onAreaChangeDetails"
        },
        onAreaChange: function (area) {
            if (area === "random-battl" ||
                    area === "change-password" ||
                    area === "sign-in" ||
                    area === "create-account" ||
                    area === "forgot-password"
                    ) {
                eventHandler.trigger("onNavigateModal", area);
                return;
            }

            eventHandler.trigger("onNavigate", area);
        },
        onAreaChangeDetails: function (area, id, title) {
            eventHandler.trigger("onNavigateModalDetails", area, id, title);
        }
    });

    return MasterRouter;
});