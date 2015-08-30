define([
    "views/chartsTopSongsList",
    "views/chartsTopUsersList",
    "views/graphTop",
    "views/pieChart",
    "viewModels/chartsRankingViewModel"
],
    function (
        ChartsTopSongsList,
        ChartsTopUsersList,
        GraphTop,
        PieChart,
        ChartsRankingViewModel) {
        var ChartsRanking = Backbone.View.extend({
            el: ".charts-ranking",
            events: {
            },
            initialize: function () {

                this.model = new ChartsRankingViewModel();
                this.model.bind("change", $.proxy(this.onModelChange, this));
                this.model.fetch();

                //GRAPH TOP SONGS
                this.graphTopSongs = new GraphTop({ el: ".graph-top-songs", title: "TOP 10 SONGS", type: "Songs" });

                //GRAPH TOP ALBUMS
                this.graphTopAlbums = new GraphTop({ el: ".graph-top-albums", title: "TOP 10 ALBUMS", type: "Albums" });

                //PIE CHART GENDER
                this.pieChartGender = new PieChart({ el: ".pie-chart-gender", title: "GENDER", type: "gender", colors: ["#006AF1", "#DE02FC"] });

                //PIE CHART AGE
                this.pieChartAge = new PieChart({ el: ".pie-chart-age", title: "AGE", type: "age", colors: ["#6633cc", "#00cc65", "#FFFF00"] });

                //PIE CHART ACTIVITY
                this.pieChartActivity = new PieChart({ el: ".pie-chart-activity", title: "ONLINE ACTIVITY", type: "activity", colors: ["#000034", "#ffff01"] });
            },
            render: function () {
                return this;
            },
            onModelChange: function (data) {                
                this.graphTopSongs.update(data.changed.songsTotalModel);
                this.graphTopAlbums.update(data.changed.albumsTotalModel);

                this.pieChartGender.update(data.changed.gendersTotalModel);
                this.pieChartAge.update(data.changed.userAgesTotalModel);
                this.pieChartActivity.update(data.changed.activityByHourModel);
            }
        });

        return ChartsRanking;
    });