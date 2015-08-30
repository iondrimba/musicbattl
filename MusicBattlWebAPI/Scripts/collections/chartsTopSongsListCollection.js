define([ "models/chartsTopSongsListModel"], function ( Model) {
    'use strict';
    var ChartsTopSongsListCollection = new Backbone.Collection([
        { AlbumCover: "dummy-album.jpg", ArtistName: "", SongName: "", AlbumName: "", ArtistId: 0 },
        { AlbumCover: "dummy-album.jpg", ArtistName: "", SongName: "", AlbumName: "", ArtistId: 0 },
        { AlbumCover: "dummy-album.jpg", ArtistName: "", SongName: "", AlbumName: "", ArtistId: 0 }
    ], {
        model: Model
    });
    return ChartsTopSongsListCollection;
});