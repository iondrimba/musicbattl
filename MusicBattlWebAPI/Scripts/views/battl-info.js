define([
    "text!../../templates/html/battl-info-details.html",
    "viewModels/battlInfoViewModel"],
    function (
        html,
        ViewModel,
        hb) {
        var BattlInfo = Backbone.View.extend({
            el: ".battl-info",
            initialize: function (options) {
                this.options = options;
                eventHandler.off("onSoundFinished", this.onSoundFinished, this);
                eventHandler.off("onStreamingReady", this.onStreamingReady, this);

                eventHandler.on("onSoundFinished", this.onSoundFinished, this);
                eventHandler.on("onStreamingReady", this.onStreamingReady, this);

                this.model = new ViewModel({ artistId: this.options.id });
                this.model.bind("change", $.proxy(this.onModelChange, this));
                this.render();
                $(".modal-ph").width(610);
                this.model.fetch();
            },
            dispose: function () {
                $(".modal-ph").width(600);
                eventHandler.off("onSoundFinished", this.onSoundFinished, this);
                eventHandler.off("onStreamingReady", this.onStreamingReady, this);
                if (master.modalSong) {
                    master.stopSounds();
                }
            },
            render: function () {
                var hbrs = Handlebars.compile(html),
                    tplt;

                tplt = hbrs({ data: this.model.data });
                this.$el.find(".ph").html(tplt);
            },
            events: {
                "click .play": "onPlayClick",
                "click .pause": "onPauseClick"
            },
            onPlayClick: function (evt) {
                var target = $(evt.currentTarget),
                    url = "",
                    id = 0,
                    options = {},
                    album = "",
                    artist = "",
                    song = "",
                    battlePh;

                battlePh = target.parent().parent().parent();
                id = target.attr("data-songid");

                this.$el.find(".star").addClass("hidden");
                this.$el.find(".pause").addClass("hidden");
                this.$el.find(".play").removeClass("hidden");

                song = battlePh.find(".fontface-1").text();
                album = $(battlePh.find(".fontface-3")[0]).text();
                artist = $(battlePh.find(".fontface-3")[1]).text();

                options.category = "Song";
                options.action = "Play";
                options.label = "{0} - {1} / {2}".format(song, album, artist);
                musicBattlUtils.trackEvent(options);

                if (master.currentSong.id == id) {
                    target.next().removeClass("hidden");
                    target.next().next().next().removeClass("hidden");
                } else {
                    target.next().next().removeClass("hidden");
                }

                target.addClass("hidden");
                url = target.data("songurl");
                master.playSound(url, id, true);
            },
            onPauseClick: function (evt) {
                var target = $(evt.currentTarget),
                    url = "",
                    options = {};

                target.find(".pause").addClass("hidden");
                target.find(".play").removeClass("hidden");

                options.category = "Song";
                options.action = "Pause";
                options.label = "";
                musicBattlUtils.trackEvent(options);

                target.prev().removeClass("hidden");
                target.addClass("hidden");
                target.next().next().addClass("hidden");
                url = target.data("songurl");

                master.pauseSound();
            },
            onSoundFinished: function () {

                this.$el.find(".pause").addClass("hidden");
                this.$el.find(".loading").addClass("hidden");
                this.$el.find(".play").removeClass("hidden");

                if (master.modalSong) {
                    master.stopSounds();
                }
            },
            onStreamingReady: function (sound) {
                var playButton = {};

                if (master.currentSong.sound) {
                    if (master.currentSong.sound.muted === false || master.currentSong.sound.paused === false) {

                        playButton = this.$el.find(".play[data-songid='{0}']".format(master.currentSong.id));
                        playButton.addClass("hidden");
                        playButton.next().next().addClass("hidden");
                        playButton.next().removeClass("hidden");
                        playButton.next().next().next().removeClass("hidden");

                        master.showSoundWave();
                        master.resumeSoundWave();
                    }
                }
            },
            onModelChange: function () {
                this.render();
            }
        });

        return BattlInfo;
    });