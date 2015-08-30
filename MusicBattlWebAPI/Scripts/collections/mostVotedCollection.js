define(["models/mostVotedModel"], function (Model) {
    'use strict';
    var MostVotedCollection = new Backbone.Collection([
        { AlbumCover: "dummy-album.jpg", ArtistName: "", SongName: "", AlbumName: "", ArtistId: 0 },
        { AlbumCover: "dummy-album.jpg", ArtistName: "", SongName: "", AlbumName: "", ArtistId: 0 },
        { AlbumCover: "dummy-album.jpg", ArtistName: "", SongName: "", AlbumName: "", ArtistId: 0 },
        { AlbumCover: "dummy-album.jpg", ArtistName: "", SongName: "", AlbumName: "", ArtistId: 0 },
        { AlbumCover: "dummy-album.jpg", ArtistName: "", SongName: "", AlbumName: "", ArtistId: 0 }
    ], {
        model: Model
    });

    return MostVotedCollection;
});