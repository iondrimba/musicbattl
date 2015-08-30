define([ "models/chartsTopUsersListModel"], function ( Model) {
    'use strict';
    var ChartsTopUsersListCollection = new Backbone.Collection([
        { ProfileId: 0, Name: "", Picture: "/img/artist/mini/mini-user.png" },
        { ProfileId: 0, Name: "", Picture: "/img/artist/mini/mini-user.png" },
        { ProfileId: 0, Name: "", Picture: "/img/artist/mini/mini-user.png" }
    ], {
        model: Model
    });

    return ChartsTopUsersListCollection;
});