define(["models/versusModel"], function ( Model) {
    'use strict';
    var VersusCollection = new Backbone.Collection([
        { FirstAlbumCover: "dummy-album.jpg", SecondAlbumCover: "dummy-album.jpg", BattlId: 0, FirstSongId: 0, TotalFirst: 0, SecondSongId: 0, TotalSecond: 0 },
        { FirstAlbumCover: "dummy-album.jpg", SecondAlbumCover: "dummy-album.jpg", BattlId: 0, FirstSongId: 0, TotalFirst: 0, SecondSongId: 0, TotalSecond: 0 },
        { FirstAlbumCover: "dummy-album.jpg", SecondAlbumCover: "dummy-album.jpg", BattlId: 0, FirstSongId: 0, TotalFirst: 0, SecondSongId: 0, TotalSecond: 0 },
        { FirstAlbumCover: "dummy-album.jpg", SecondAlbumCover: "dummy-album.jpg", BattlId: 0, FirstSongId: 0, TotalFirst: 0, SecondSongId: 0, TotalSecond: 0 },
        { FirstAlbumCover: "dummy-album.jpg", SecondAlbumCover: "dummy-album.jpg", BattlId: 0, FirstSongId: 0, TotalFirst: 0, SecondSongId: 0, TotalSecond: 0 }
    ], {
        model: Model
    });

    return VersusCollection;
});