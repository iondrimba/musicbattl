define([
    "text!../../templates/html/graph-top.html",
    "viewModels/graphTopViewModel"],
    function (
        html,
        ViewModel) {
        var GraphTop = Backbone.View.extend({
            el: ".graph",
            getDataByType: function (timeSpanType) {
                this.model.url = "/api/MostVoted/{0}{1}ArtistNameDesc/?page=0&rowCount=10".format(this.options.type, timeSpanType);
                this.model.fetch({ success: $.proxy(this.onModelChange, this) });
            },
            selectGraphMenu: function (type) {
                var menu = this.$el.find(".graph-menu");
                menu.find(".graph-item-active").removeClass("graph-item-active").addClass("graph-item");
                menu.find("li").each(function (index) {
                    var elmt = $(this);
                    if (elmt.find("span").text().toLowerCase() === type.toLowerCase()) {
                        elmt.removeClass("graph-item").addClass("graph-item-active");
                    }
                });
            },
            initialize: function (options) {
                this.options = options;
                this.model = new ViewModel();
                this.model.bind("change", $.proxy(this.onModelChange, this));
                this.timeSpanType = "Month";
                this.render();
                //this.getDataByType(this.timeSpanType);
            },
            update: function (data) {
                this.render(data);
            },
            render: function (data) {
                var hbrs = Handlebars.compile(html),
                    data = data?data.Collection: this.model.collection,
                    tplt,
                    scope = this,
                    totalVotos,
                    i = 0,
                    total = 0;

                tplt = hbrs({ data: data, title: this.options.title, type: this.options.type });
                this.$el.html(tplt);

                this.chartData = _.map(data, function (obj) {
                    var data = {};
                    if (scope.options.type.toLowerCase() === "songs") {
                        data.name = obj.SongName;

                        data.total = obj.Total;
                    } else {
                        data.name = obj.AlbumName;

                        data.total = obj.TotalVotes;
                    }

                    data.artistName = obj.ArtistName;
                    data.songName = obj.SongName;
                    data.albumName = obj.AlbumName;
                    data.albumCover = obj.AlbumCover;

                    return data;
                });
                this.votes = _.map(this.chartData, function (obj) {
                    return obj.total;
                });

                this.colors = ["bar-bg-first",
                    "bar-bg-second",
                    "bar-bg-third",
                    "bar-bg-fourth",
                    "bar-bg-fifth",
                    "bar-bg-sixth",
                    "bar-bg-seventh",
                    "bar-bg-eight",
                    "bar-bg-nineth",
                    "bar-bg-tenth"
                ];

                totalVotos = _.reduce(this.votes, function (memo, num) { return memo + num; }, 0);
                total = this.chartData.length;

                this.selectGraphMenu(this.timeSpanType);

                for (i; i < total; i += 1) {
                    if (this.chartData[i].name !== "Song") {
                        var item = this.$el.find(".graph-item-ph.hidden").clone(),
                            legend = this.$el.find(".graph-legend-item.hidden").clone();

                        legend.removeClass("hidden");
                        item.removeClass("hidden");
                        item.find(".graph-bar").addClass(this.colors[0]);
                        var h = Math.round(this.chartData[i].total / totalVotos * 100);
                        var percent = (100 - h);
                        if (!isNaN((100 - h))) {
                            item.find(".round-counter").text(i + 1);
                            
                            TweenLite.to(item.find(".graph-bar"), .4, { top: '{0}%'.format(percent), delay: i * .15});                            
                            item.find(".graph-img").attr("src", "/img/album/mini/" + this.chartData[i].albumCover);

                            legend.find(".round-counter").text(i + 1);
                            legend.find(".song").text(this.chartData[i].songName);
                            legend.find(".album").text(this.chartData[i].albumName);
                            legend.find(".artist").text(this.chartData[i].artistName);

                            this.$el.find(".graph-legend-container").find("ul").append(legend);

                            this.$el.find(".graph-container").append(item);
                        }
                    }
                }

                return this;
            },
            events: {
                "click .graph-item": "onGraphMenuClick"
            },
            onGraphMenuClick: function (evt) {
                this.timeSpanType = $(evt.target).text();

                var options = {};
                options.category = "Charts";
                options.action = this.timeSpanType;
                options.label = this.options.title;
                musicBattlUtils.trackEvent(options);

                this.getDataByType(this.timeSpanType);
            },
            onModelChange: function () {
                this.render();
            }
        });

        return GraphTop;
    });