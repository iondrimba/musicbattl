define(["models/allTimeWinnersModel"], function ( Model) {
    'use strict';
    var AllTimeWinnersCollection = new Backbone.Collection([
        { Picture: "dummy-artist.jpg", AlbumCover: "dummy-album.jpg", ArtistName: "", SongName: "", AlbumName: "", ArtistId: 0 },
        { Picture: "dummy-artist.jpg", AlbumCover: "dummy-album.jpg", ArtistName: "", SongName: "", AlbumName: "", ArtistId: 0 },
        { Picture: "dummy-artist.jpg", AlbumCover: "dummy-album.jpg", ArtistName: "", SongName: "", AlbumName: "", ArtistId: 0 },
        { Picture: "dummy-artist.jpg", AlbumCover: "dummy-album.jpg", ArtistName: "", SongName: "", AlbumName: "", ArtistId: 0 }
    ], {
        model: Model
    });
    return AllTimeWinnersCollection;
});