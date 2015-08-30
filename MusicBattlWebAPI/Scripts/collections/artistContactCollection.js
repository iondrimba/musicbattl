define([ "models/artistContactModel"], function ( Model) {
    'use strict';
    var ArtistContactCollection = new Backbone.Collection([
        { Name: "", Picture: "dummy-artist.jpg", Description: "", bandcamp: "", twitter: "", facebook: "", tumblr: "", soundcloud: "", website: "", email: "" }
    ], {
        model: Model
    });

    return ArtistContactCollection;
});