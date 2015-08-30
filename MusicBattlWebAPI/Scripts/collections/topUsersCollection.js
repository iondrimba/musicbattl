define(["models/topUsersModel"], function (Model) {
    'use strict';
    var TopUsersCollection = new Backbone.Collection([
        { ProfileId: 0, Name: "", Picture: "/img/user/mini-user.png" },
        { ProfileId: 0, Name: "", Picture: "/img/user/mini-user.png" },
        { ProfileId: 0, Name: "", Picture: "/img/user/mini-user.png" }
    ], {
        model: Model
    });

    return TopUsersCollection;
});