define([ "models/userFavoritesModel"], function ( Model) {
    'use strict';
    var AllTimeWinnersCollection = new Backbone.Collection([
        { AlbumCover: "dummy-album.jpg", ArtistName: "", SongName: "", AlbumName: "", ArtistId: 0 },
        { AlbumCover: "dummy-album.jpg", ArtistName: "", SongName: "", AlbumName: "", ArtistId: 0 },
        { AlbumCover: "dummy-album.jpg", ArtistName: "", SongName: "", AlbumName: "", ArtistId: 0 },
        { AlbumCover: "dummy-album.jpg", ArtistName: "", SongName: "", AlbumName: "", ArtistId: 0 }
    ], {
        model: Model
    });

    return AllTimeWinnersCollection;
});