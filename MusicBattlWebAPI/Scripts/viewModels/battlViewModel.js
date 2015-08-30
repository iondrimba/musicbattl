define(["collections/battlCollection"], function ( Collection) {
    var BattlViewModel = Backbone.Model.extend({
        url: "/api/Battl/Current",
        initialize: function () {
            this.collection = Collection.toJSON();
            this.startTime = 0;
            this.endTimer = 0;
            this.battlId = 0;
            this.battlDate = "";

            this.bind("change", this.onModelChange);
        },
        update: function (data) {
            onModelChange(data);
            this.trigger("change");
        },
        onModelChange: function (data) {
            if (data.changed) {
                this.battlDate = data.changed.BattlDate;
                this.battlId = data.changed.BattlId;
                this.endTime = data.changed.EndTime;
                this.startTime = data.changed.StartTime;

                this.collection[0].BattlId = this.battlId;
                this.collection[0].AlbumCover = data.changed.FirstAlbumCover;
                this.collection[0].AlbumName = data.changed.FirstAlbumName;
                this.collection[0].ArtistId = data.changed.FirstArtistId;
                this.collection[0].ArtistName = data.changed.FirstArtistName;
                this.collection[0].SongId = data.changed.FirstSongId;
                this.collection[0].SongUrl = data.changed.FirstSongUrl;
                this.collection[0].SongName = data.changed.FirstSongName;
                this.collection[0].Votes = data.changed.FirstSongVotes;

                this.collection[1].BattlId = this.battlId
                this.collection[1].AlbumCover = data.changed.SecondAlbumCover;
                this.collection[1].AlbumName = data.changed.SecondAlbumName;
                this.collection[1].ArtistId = data.changed.SecondArtistId;
                this.collection[1].ArtistName = data.changed.SecondArtistName;
                this.collection[1].SongId = data.changed.SecondSongId;
                this.collection[1].SongUrl = data.changed.SecondSongUrl;
                this.collection[1].SongName = data.changed.SecondSongName;
                this.collection[1].Votes = data.changed.SecondSongVotes;
            }
        }
    });

    return BattlViewModel;
});