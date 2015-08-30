define(["text!../../templates/html/battle.html",
    "viewModels/battlViewModel",
    "models/battlModel",
    "views/flipClock"],
    function (html,
        ViewModel,
        BattlModel,
        FlipClock) {
        var BattlView = Backbone.View.extend({
            el: ".battle",
            initialize: function () {
                this.firstTime = true;
                this.counting = false;
                this.votesMultiple = 10;
                this.model = new ViewModel();
                this.model.bind("change", $.proxy(this.onModelChange, this));
                this.render();
            },
            load: function () {
                var scope = this;
                if (master.currentBattle) {
                    this.newBattl = master.currentBattle;
                    this.onBattlStarted();

                    _.delay(function () {
                        scope.model.fetch();
                    }, 300);
                } else {
                    this.model.fetch();
                }
            },
            dispose: function () {
                this.flipClock = null;
                this.undelegateEvents();
                this.stopListening();
                $(this.el).removeData().unbind();
            },
            render: function () {
                var hbrs = Handlebars.compile(html),
                    data = {},
                    tplt,
                    first,
                    second;

                data = this.model.collection;

                tplt = hbrs(data);
                this.$el.html(tplt);
                
                this.flipClock = new FlipClock();

                $(".song-artist-album").each(function (index, elmt) {
                    var textHeight = $(elmt).outerHeight();
                    if (textHeight > 47) {
                        $(elmt).css("margin-top", -(textHeight - 47));
                    }
                });

                first = this.model.collection[0];
                second = this.model.collection[1];

                this.animateVotes(first.SongId, first.Votes);
                this.animateVotes(second.SongId, second.Votes);

                eventHandler.trigger('battlloaded');

                return this;
            },
            enableAlbums: function () {
                this.$el.find(".animate-spinner-left").removeClass("animate-spinner-left");
                this.$el.find(".animate-spinner-right").removeClass("animate-spinner-right");
                this.$el.find(".inner-circle").removeClass("inner-circle-disabled");

                this.events["click .star"] = "onStarClick";
                this.events["click .play"] = "onPlayClick";
                this.events["click .pause"] = "onPauseClick";

                this.delegateEvents(this.events);
            },
            disableAlbums: function () {
                this.delegateEvents(this.events);

                this.$el.find(".inner-circle").addClass("inner-circle-disabled");
            },
            voteSong: function (data) {
                data.profileid = master.loginManager.loggedUser.profileId;
                master.musicBattlSignalR.voteSong(data);
                this.delegateEvents(this.events);
            },
            disableVoting: function () {
            },
            animateVotes: function (songId, votes) {
                var elmt = {},
                    lineVotes = {},
                    newVotes = votes;

                if (songId) {
                    elmt = this.$el.find(".star[data-songid={0}]".format(songId)).parent().parent().next();
                    lineVotes = elmt.find(".status-bar-line")                    
                    if (newVotes < this.votesMultiple) {
                        newVotes = newVotes * this.votesMultiple;
                        lineVotes.width("{0}%".format(newVotes));
                    }
                }
            },
            removeAnimatedStar: function (star) {
                var scope = this;
                TweenLite.to(star, .2, {
                    opacity: 0, onComplete: function (elmt) {
                        elmt.remove();
                    }, onCompleteParams: [star]
                });
            },
            animate: function (songId) {
                var star = this.$el.find(".star[data-songid={0}]".format(songId)),
                    p = star.parent().parent(),
                    percent = 0,
                    newPercent = 0,
                    animatedStar,
                    album,
                    scope = this,
                    statusBar;

                //ANIMATING STAR
                animatedStar = $(".star-vote").clone();
                star.parent().parent().find(".voting-widget-ph").append(animatedStar);
                animatedStar.removeClass("visible-false");

                album = star.parent().parent().parent();
                statusBar = album.find(".status-bar-line");
                percent = Math.round(statusBar.width() / statusBar.parent().width() * 100);

                p.find(".spinner-css").find(".sp_left").find(".fill").addClass("animate-spinner-left");
                p.find(".spinner-css").find(".sp_right").find(".fill").addClass("animate-spinner-right");

                newPercent = percent;
                statusBar.width(newPercent + "%");

                TweenLite.to(animatedStar, .5, { transform: 'translate(85px,-120px)' });
                TweenLite.to(animatedStar, .5, { rotation: 720 });
                TweenLite.to(animatedStar, .7, { scale: 1, onComplete: this.removeAnimatedStar, onCompleteParams: [animatedStar], onCompleteScope: this });

                if (newPercent >= 90) {
                    album.addClass("complete");                                        
                    this.disableVoting();
                    TweenLite.to(statusBar, 0, { width: '100%' });
                    master.musicBattlSignalR.onBattlEnd();
                }
            },
            updateClock: function (data) {
                var min = parseInt(data.minutes, 10),
                    sec = parseInt(data.seconds, 10);

                sec -= 1;

                if (sec < 0) {
                    sec = 59;
                    min -= 1;
                }

                this.timeData.minutes = "{0}".format(min);
                this.timeData.seconds = "{0}".format(sec);

                if (this.flipClock) {
                    if (!this.firstTime) {
                        this.flipClock.updateMinClock(min);
                    } else {
                        this.flipClock.updateMinClockWithoutAnimation(min);
                        this.firstTime = false;
                    }

                    this.flipClock.updateSecClock(sec);
                } 
            },
            showAnimatedBars: function (ph) {
                this.hideAnimatedBars();
                ph.find(".bars").removeClass("hidden");
                ph.find(".bar").addClass("animate");
            },
            hideAnimatedBars: function () {
                this.$el.find(".bars").addClass("hidden");
                this.$el.find(".bar").removeClass("animate");
            },
            pauseSong: function (target) {
                target.find(".pause").addClass("hidden");
                target.find(".play").removeClass("hidden");

                target.prev().removeClass("hidden");
                target.addClass("hidden");
            },
            animateWinner: function (winner) {
                var trophy = $(".trophy").clone(),
                    stars = [];

                $(".trophy-animation-ph").empty();

                trophy.addClass("trophy-center").removeClass("visible-false");
                winner.find(".trophy-animation-ph").prepend(trophy);

                for (var i = 0; i < 10; i++) {
                    var clone = $(".star-vote.visible-false").clone();
                    clone.removeClass("visible-false").addClass("star-winner");
                    TweenLite.to(clone, 0, { scale: .5, opacity: 0 });
                    winner.find(".trophy-animation-ph").append(clone);

                    stars[i] = { star: clone, delay: i * .05 };
                }

                TweenLite.to(winner.find('.status-bar-line'), 0, { width: '100%' });
                TweenLite.to(winner.find('.status-bar-line'), .5, { width: '0%', delay: .5 });

                TweenLite.to(trophy, .5, { top: 105 });

                TweenLite.to(stars[0].star, .5, { opacity: 1, delay: stars[0].delay, rotation: 720, left: 10, top: 207, onComplete: this.removeAnimatedStar, onCompleteParams: [stars[0].star], onCompleteScope: this });
                TweenLite.to(stars[1].star, .5, { opacity: 1, delay: stars[1].delay, rotation: 720, left: 0, top: 158, onComplete: this.removeAnimatedStar, onCompleteParams: [stars[1].star], onCompleteScope: this });
                TweenLite.to(stars[2].star, .5, { opacity: 1, delay: stars[2].delay, rotation: 720, left: 4, top: 108, onComplete: this.removeAnimatedStar, onCompleteParams: [stars[2].star], onCompleteScope: this });
                TweenLite.to(stars[3].star, .5, { opacity: 1, delay: stars[3].delay, rotation: 720, left: 27, top: 62, onComplete: this.removeAnimatedStar, onCompleteParams: [stars[3].star], onCompleteScope: this });
                TweenLite.to(stars[4].star, .5, { opacity: 1, delay: stars[4].delay, rotation: 720, left: 69, top: 36, onComplete: this.removeAnimatedStar, onCompleteParams: [stars[4].star], onCompleteScope: this });
                TweenLite.to(stars[5].star, .5, { opacity: 1, delay: stars[5].delay, rotation: 720, left: 116, top: 36, onComplete: this.removeAnimatedStar, onCompleteParams: [stars[5].star], onCompleteScope: this });
                TweenLite.to(stars[6].star, .5, { opacity: 1, delay: stars[6].delay, rotation: 720, left: 153, top: 62, onComplete: this.removeAnimatedStar, onCompleteParams: [stars[6].star], onCompleteScope: this });
                TweenLite.to(stars[7].star, .5, { opacity: 1, delay: stars[7].delay, rotation: 720, left: 173, top: 108, onComplete: this.removeAnimatedStar, onCompleteParams: [stars[7].star], onCompleteScope: this });
                TweenLite.to(stars[8].star, .5, { opacity: 1, delay: stars[8].delay, rotation: 720, left: 167, top: 158, onComplete: this.removeAnimatedStar, onCompleteParams: [stars[8].star], onCompleteScope: this });
                TweenLite.to(stars[9].star, .5, { opacity: 1, delay: stars[9].delay, rotation: 720, left: 151, top: 203, onComplete: this.removeAnimatedStar, onCompleteParams: [stars[9].star], onCompleteScope: this });
            },
            getWinner: function () {
                var retorno = undefined,
                    votesLeft = 0,
                    votesRight = 0;
                votesLeft = this.$el.find(".status-bar-line:eq(0)").width();
                votesRight = this.$el.find(".status-bar-line:eq(1)").width();
                if (votesLeft > votesRight) {
                    retorno = this.$el.find(".status-bar-line:eq(0)").parent().parent().parent();
                } else if (votesRight > votesLeft) {
                    retorno = this.$el.find(".status-bar-line:eq(1)").parent().parent().parent();
                }

                return retorno;
            },
            events: {
                "click .star": "onStarClick",
                "click .play": "onPlayClick",
                "click .pause": "onPauseClick",

                "touchend .battle-album-img": "onBattlAlbumOver",
                "touchend .battle-album-img-right": "onBattlAlbumOver",

                "animationend .spinner-css": "onAnimateComplete",
                "webkitAnimationEnd .spinner-css": "onAnimateComplete",

                "mouseleave .battle-column-left": "onBattlAlbumOut",
                "mouseleave .battle-column-right": "onBattlAlbumOut"
            },
            onBattlEnded: function (data) {                
                this.model.onModelChange({ changed: data });
                TweenLite.to($(".battle-album-disc-left"), 1, { rotation: -90, left: -90 });
                TweenLite.to($(".battle-album-disc-right"), 1, { rotation: -90, left: 170 });
                this.newBattl = data;
                master.currentBattle = this.newBattl;
                if (!master.modalSong) {
                    master.stopSounds();
                }

                clearInterval(master.timerInterval);
                master.musicBattlSignalR.onBattlReset();
            },
            onAnimateComplete: function (evt) {
                var star,
                    play

                this.delegateEvents(this.events);

                star = this.$el.find(".bg-circle:not(.hidden)").prev().prev();
                play = this.$el.find(".bg-circle:not(.hidden)").next();
                star.removeClass("hidden");
                play.removeClass("hidden");

                this.$el.find(".bg-circle").addClass("hidden");
                this.$el.find(".loader-circle").addClass("hidden");
                this.$el.find(".inner-circle").addClass("hidden");

                if (this.$el.find(".battle-album-column.complete").length) {
                    this.$el.find(".battle-album-column:not(.complete)").addClass("opaque-content");
                } else {
                    this.enableAlbums();
                }
            },
            onBattlStarted: function (data) {
                eventHandler.off("onSoundFinished", this.onSoundFinished);
                eventHandler.off("onStreamingReady", this.onStreamingReady);

                eventHandler.off("onBattlStarted", null, null);
                eventHandler.off("onBattlEnded", null, null);
                eventHandler.off("onBattlReseted", null, null);

                eventHandler.off("onBattlVotesUpdated", null, null);
                eventHandler.off("onBattlTimerUpdated", null, null);

                eventHandler.on("onSoundFinished", this.onSoundFinished, this);
                eventHandler.on("onStreamingReady", this.onStreamingReady, this);

                eventHandler.on("onBattlEnded", $.proxy(this.onBattlEnded, this));
                eventHandler.on("onBattlReseted", $.proxy(this.onBattlReseted, this));

                eventHandler.on("onBattlVotesUpdated", $.proxy(this.onBattlVotesUpdated, this));
                eventHandler.on("onBattlTimerUpdated", $.proxy(this.onBattlTimerUpdated, this));

                this.model.onModelChange({ changed: this.newBattl });

                this.render();
            },
            onStreamingReady: function (data) {
                var playButton = {},
                    battlePh = {},
                    loading,
                    pause,
                    star;

                this.delegateEvents(this.events);

                if (master.currentSong.sound) {
                    if (master.currentSong.sound.muted === false || master.currentSong.sound.paused === false) {
                        if (master.modalSong) {
                            this.$el.find(".pause").addClass("hidden");
                            this.$el.find(".star").removeClass("hidden");
                            this.$el.find(".loading").addClass("hidden");
                            this.$el.find(".play").removeClass("hidden");
                        } else {
                            playButton = this.$el.find(".play[data-songid='{0}']".format(master.currentSong.id));
                            playButton.addClass("hidden");
                            loading = playButton.next().next();
                            pause = playButton.next();
                            star = playButton.next().next().next();

                            loading.addClass("hidden");
                            pause.removeClass("hidden");
                            star.removeClass("hidden");

                            battlePh = playButton.parent().parent().parent();

                            master.showSoundWave();
                            master.resumeSoundWave();
                        }
                    }
                }
            },
            onSoundFinished: function () {
                if (!master.modalSong) {
                    this.hideAnimatedBars();
                    master.stopSounds();
                    this.$el.find(".pause").addClass("hidden");
                    this.$el.find(".star").removeClass("hidden");
                    this.$el.find(".loading").addClass("hidden");
                    this.$el.find(".play").removeClass("hidden");
                    this.delegateEvents(this.events);
                }
            },
            onBattlReseted: function () {
                this.$el.find(".spinner").removeClass("hidden");
                this.$el.find(".versus").addClass("hidden");

                this.counting = false;

                eventHandler.on("onBattlStarted", $.proxy(this.onBattlStarted, this));

                if (this.firstTime === false && this.flipClock) {
                    var winner;

                    this.onSoundFinished();

                    this.$el.find(".song-artist-album").css({ "visibility": "hidden" });
                    this.$el.find(".versus").text("");
                    this.flipClock.reset();

                    winner = this.getWinner();
                    if (winner) {
                        this.animateWinner(winner);
                    } else {
                        TweenLite.to($(".battle-album-ph").find("img"), .5, { opacity: 0 });
                    }
                } else {
                    TweenLite.to($(".battle-album-ph").find("img"), .5, { opacity: 0 });
                    this.$el.find(".song-artist-album").find("h1,h2,h3").text("");
                    this.$el.find(".versus").text("");
                }

                $(".voting-widget-ph").addClass("hidden");
            },
            onBattlTimerUpdated: function (data) {
                if (this.counting === false) {
                    this.counting = true;

                    TweenLite.to($(".battle-album-ph").find("img"), .5, { opacity: 1 });
                    TweenLite.to($(".battle-album-disc-left"), 1, { transform: 'translate(91px,0)' });
                    TweenLite.to($(".battle-album-disc-left"), 1, { rotation: 100 });
                    TweenLite.to($(".battle-album-disc-right"), 1, { transform: 'translate(-91px,0)' });
                    TweenLite.to($(".battle-album-disc-right"), 1, { rotation: -100 });
                    this.$el.find(".song-artist-album").css({ "visibility": "visible" });
                    this.$el.find(".spinner").addClass("hidden");
                    this.$el.find(".versus").removeClass("hidden");
                    this.$el.find(".play").removeClass("hidden");
                    this.$el.find(".star").removeClass("hidden");
                    this.enableAlbums();

                    if (master.currentSong.sound) {
                        if (master.currentSong.sound.muted === 1 || master.currentSong.sound.paused === false) {
                            var t = this.$el.find(".play[data-songid={0}]".format(master.currentSong.id));
                            if (t.length) {
                                t.addClass("hidden");
                                t.next().removeClass("hidden");
                                t.next().next().next().removeClass("hidden");
                            }
                        }
                    }
                }

                this.timeData = data;
                eventHandler.off("onBattlTimerUpdated");
                clearInterval(master.timerInterval);
                
                if (this.timeData.clock === "9:59") {
                    this.timeData.minutes = "10";
                    this.timeData.seconds = "00";
                }
                master.timerInterval = setInterval($.proxy(this.updateClock, this, this.timeData), 1000);
                this.updateClock(this.timeData);
            },
            onBattlVotesUpdated: function (data) {
                var votes = data.Votes;
                if (master.currentBattle) {
                    if (data.SongId === master.currentBattle.FirstSongId) {
                        master.currentBattle.FirstSongVotes = votes;
                    }
                    if (data.SongId === master.currentBattle.SecondSongId) {
                        master.currentBattle.SecondSongVotes = votes;
                    }
                }
                this.animateVotes(data.SongId, votes );
            },
            onStarClick: function (evt) {
                var target = $(evt.currentTarget),
                    data = {},
                    options = {},
                    battlePh = {},
                    scope = this;

                data.songId = target.data("songid");
                data.battlId = target.data("battlid");
                battlePh = target.parent().parent().parent();

                if (master.loginManager.loggedUser.id) {
                    options.category = "Battl";
                    options.action = "Vote";
                    options.label = "Song Id:{0}".format(data.songId);
                    musicBattlUtils.trackEvent(options);

                    battlePh.find(".bg-circle").removeClass("hidden");
                    battlePh.find(".loader-circle").removeClass("hidden");
                    battlePh.find(".inner-circle").removeClass("hidden");

                    battlePh.find(".pause").addClass("hidden");

                    $.when(this.voteSong(data)).then(function () {
                        scope.onBattlModelChange(data.songId);
                    });
                } else {
                    musicBattlUtils.showInfo("Please sign in to vote on this song!", "Info");
                }
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
                master.playSound(url, id);
            },
            onPauseClick: function (evt) {
                var target = $(evt.currentTarget),
                    options = {};
                this.pauseSong(target);

                options.category = "Song";
                options.action = "Pause";
                options.label = "";
                musicBattlUtils.trackEvent(options);

                master.pauseSound();
            },
            onBattlModelChange: function (songId) {
                musicBattlUtils.convertToNumber(songId, 0);
                this.animate(songId);
            },
            onModelChange: function (data) {
                if (master.currentBattle) {
                    this.animateVotes(data.changed.FirstSongId, data.changed.FirstSongVotes * this.votesMultiple);
                    this.animateVotes(data.changed.SecondSongId, data.changed.SecondSongVotes * this.votesMultiple);
                } else {
                    master.currentBattle = data.changed;
                    this.onBattlStarted();
                }
            }
        });
        return BattlView;
    });