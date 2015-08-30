define(["models/battlModel"], function (Model) {
    'use strict';
    var BattlCollection = new Backbone.Collection([
        { AlbumCover: "battle-album-bg.jpg", ArtistName: "", SongName: "", AlbumName: "", ArtistId: 0 },
        { AlbumCover: "battle-album-bg.jpg", ArtistName: "", SongName: "", AlbumName: "", ArtistId: 0 }
    ], {
        model: Model
    });

    return BattlCollection;
});