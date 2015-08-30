define([
    "musicBattlSignalR",
    "routers/master",
    "views/header",
    "views/modal",
    "models/loginManager",
    "models/account",
    "views/home",
    "views/charts-ranking",
    "views/artists",
    "views/user-profile",
    "views/create-account",
    "views/sign-in",
    "views/edit-profile",
    "views/artist-contact",
    "views/battl-info"
],
    function (
        MusicBattlSignalR,
        MasterRouter,
        Header,
        Modal,
        LoginManager,
        Account) {
        var Master = Backbone.View.extend({
            el: ".main",
            events: {
            },
            initialize: function () {
                SC.initialize({
                    client_id: 'aba2c7918a43ab0cc467124cfc00a9c7'
                });

                eventHandler.off();

                eventHandler.on('loaded', $.proxy(this.onLoaded, this));

                eventHandler.on("onNavigate", $.proxy(this.onNavigate, this));
                eventHandler.on("onNavigateModal", $.proxy(this.onNavigateModal, this));
                eventHandler.on("onNavigateModalDetails", $.proxy(this.onNavigateModalDetails, this));
                eventHandler.on("onLoginReturn", $.proxy(this.onLoginReturn, this));
                eventHandler.on("onLogoutReturn", $.proxy(this.onLogoutReturn, this));
                eventHandler.on("onDisplayLoggedUser", $.proxy(this.onDisplayLoggedUser, this));
                eventHandler.on("onAccountCreate", $.proxy(this.onAccountCreateReturn, this));
                eventHandler.on("onAccountUpdated", $.proxy(this.onAccountUpdateReturn, this));
                eventHandler.on("onBattlStarted", $.proxy(this.onBattlStarted, this));
                eventHandler.on("onBattlEnded", $.proxy(this.onBattlEnded, this));

                this.timerInterval = 0;
                this.currentBattle = null;
                this.loadedFirstTime = false;
                this.idSystemUser = 22;
                this.idProfileSystemUser = 20;
                this.account = new Account();
                this.currentSong = { track: undefined, sound: undefined, id: 0 };
                this.header = new Header();
                this.router = new MasterRouter();
                this.currentBattlEnded = false;
                this.pastView = null;
                this.currentView = null;
                this.loginManager = new LoginManager({ master: this });
                this.pageContainer = $(".content-ph");
                this.modalSong = false;
                this.modal = new Modal();

                if (window.location.hash.length > 0) {
                    this.navigate(window.location.hash);
                } else if (!window.location.hash.length) {
                    this.navigate("#/site/home");
                }
            },
            onLoaded: function (evt) {
                var scope = this;
                _.delay(function () {
                    if (scope.loadedFirstTime === false) {                        
                        scope.musicBattlSignalR = new MusicBattlSignalR();
                    }                    
                    scope.loadedFirstTime = true;                    
                }, 500);
            },
            loadFirstView: function (page) {
                var scope = this;
                require(["text!../../templates/html/{0}.html".format(page), "views/{0}".format(page)], function (html, view) {
                    scope.pageContainer.empty().append(html);
                    scope.pastView = new view();
                });
            },
            render: function () {
                return this;
            },
            playSound: function (url, id, isModal) {
                var scope = this,
                    warinigMessage = "Track not found!",
                    warinigTittle = "Sorry!";

                this.modalSong = isModal;

                if (this.currentSong.track) {
                    if (!this.currentSong.track.streamable) {
                        musicBattlUtils.showWarning(warinigMessage, warinigTittle);
                        scope.currentSong.track = null;
                        eventHandler.trigger("onSoundFinished");
                        return false;
                    }
                    if (this.currentSong.id === id) {
                        if (this.currentBattlEnded) {
                            if (this.currentSong.sound) {
                                this.currentSong.sound.stop();
                            }
                        } else {
                            this.showSoundWave();
                            this.resumeSoundWave();
                            if (master.currentSong.sound.paused) {
                                this.currentSong.sound.play();
                            }

                            if (master.currentSong.sound.muted) {
                                this.currentSong.sound.unmute();
                            }
                        }
                    } else {
                        if (this.currentSong.sound) {
                            this.currentSong.sound.stop();
                        }
                        this.hideSoundWave();
                        this.loadSounds(url, id);
                    }
                } else {
                    this.hideSoundWave();
                    this.loadSounds(url, id);
                }
            },
            loadSounds: function (url, id) {
                var scope = this,
                    options = {},
                    warinigMessage = "Track not found!",
                    warinigTittle = "Sorry!";

                SC.get('/resolve', { url: url }, function (track) {
                    scope.currentSong.track = track;
                    scope.currentSong.id = id;

                    if (!track.streamable) {
                        musicBattlUtils.showWarning(warinigMessage, warinigTittle);
                        scope.currentSong.track = null;
                        eventHandler.trigger("onSoundFinished");
                    } else {
                        SC.stream(scope.currentSong.track.stream_url, {
                            onload: function (data) {
                            },
                            onfinish: function () {
                                scope.currentSong.track = null;
                                eventHandler.trigger("onSoundFinished");
                            }
                        }, function (sound) {
                            if (!scope.currentBattlEnded) {
                                scope.currentSong.sound = sound;
                                scope.currentSong.sound.play();

                                eventHandler.trigger("onStreamingReady");
                            } else {
                                options.category = "Song";
                                options.action = "Play";
                                options.label = "Not found - {0}".format(url);
                                musicBattlUtils.trackEvent(options);
                            }
                        });
                    }
                });
            },
            pauseSound: function () {
                if (this.currentSong.sound) {
                    this.currentSong.sound.pause();
                    this.hideSoundWave();
                    this.pauseSoundWave();
                    $(".muted").addClass("hidden");
                }
            },
            stopSounds: function () {
                if (this.currentSong.sound) {
                    this.currentSong.id = 0;
                    this.currentSong.sound.stop();
                    this.hideSoundWave();
                }
            },
            resumeSound: function () {
                if (this.currentSong.sound) {
                    this.currentSong.sound.unmute();
                }
            },
            toogleSoundWave: function () {
                var target = $(".bars-header");

                if (target.find(".bar").hasClass("paused")) {
                    this.showSoundWave();
                    this.resumeSoundWave();
                    this.resumeSound();
                } else {
                    this.pauseSoundWave();
                    this.mute();
                }
            },
            hideSoundWave: function () {
                var target = $(".bars-header");
                target.addClass("hidden");
            },
            showSoundWave: function () {
                var target = $(".bars-header");
                target.removeClass("hidden");
                $(".muted").addClass("hidden");
            },
            pauseSoundWave: function () {
                var target = $(".bars-header");
                target.find(".bar").addClass("paused").removeClass("animate");
            },
            resumeSoundWave: function () {
                var target = $(".bars-header");
                target.find(".bar").removeClass("paused").addClass("animate");
            },
            mute: function () {
                if (this.currentSong.sound) {
                    this.currentSong.sound.mute();
                    $(".muted").removeClass("hidden");
                } else {
                    $(".muted").addClass("hidden");
                }
            },
            closeModal: function () {
                if (this.modalSong) {
                    this.stopSounds();
                }
            },
            onBattlStarted: function (data) {
                this.currentBattlEnded = false;
            },
            onBattlEnded: function (data) {
                this.currentBattlEnded = true;
                this.hideSoundWave();
            },
            onDisplayLoggedUser: function (data) {
                if (data.id !== this.idSystemUser) {
                    this.header.showLoggedUser(data);
                } else {
                    this.header.showVisitor(data);
                }
            },
            onAccountUpdateReturn: function (data) {
                this.onAccountCreateReturn(data);
            },
            onAccountCreateReturn: function (data) {
                var user = {};
                user.name = data.name;
                user.id = data.id;
                user.profileId = data.profileId;
                user.type = data.type;

                musicBattlUtils.deleteCookie("user");
                musicBattlUtils.deleteCookie("picture");

                musicBattlUtils.saveCookie("user", JSON.stringify(user));
                musicBattlUtils.saveCookie("picture", JSON.stringify({ picture: data.picture }));

                user.picture = data.picture;
                this.loginManager.loggedUser = user;
                if (user.type) {
                    this.loginManager.activetLogin(user.type);
                    this.loginManager.loggedUser.type = user.type;
                }
                this.header.showLoggedUser(this.loginManager.loggedUser);
            },
            onLoginReturn: function (data) {
                var title = "Heya!",
                    message = "Welcome {0}!",
                    backView = "";

                backView = this.pastView.$el.selector.replace(/\./, "");

                if (this.modal.$el.attr("style") === "display: block;") {
                    this.modal.close();
                }

                this.loginManager.loggedUser = data;
                message = message.format(this.loginManager.loggedUser.name);
                musicBattlUtils.showSuccess(message, title);

                if (this.loginManager.loggedUser.id === 0) {
                    this.account.create(data);
                } else {
                    this.header.showLoggedUser(this.loginManager.loggedUser);
                }

                if (backView !== "home") {
                    master.navigate("#/site/home");
                }
            },
            onLogoutReturn: function (data) {
                var title = "Bye bye",
                    message = "Hope to see you back soon ;)";

                this.loginManager.dispose();
                this.header.showVisitor(this.loginManager.loggedUser);
                message = message.format(this.loginManager.loggedUser.name);
                musicBattlUtils.showInfo(message, title);
                window.location.href = "/#/site/home";
            },
            onNavigate: function (page) {
                if (this.pastView) {
                    if (this.pastView.$el.selector === ".{0}".format(page)) {
                        return;
                    }
                }

                if (this.modalSong) {
                    this.stopSounds();
                }

                require(["text!../../templates/html/{0}.html".format(page), "views/{0}".format(page)], $.proxy(this.onNavigateComplete, this));
            },
            onNavigateModal: function (page) {
                var scope = this;
                if (!this.pastView) {
                    this.loadFirstView("home");
                }

                require(["text!../../templates/html/{0}.html".format(page), "views/{0}".format(page)], $.proxy(this.onNavigateModalComplete, this));
            },
            onNavigateModalDetails: function (page, id, title) {
                var scope = this,
                    prevArea = 'home';

                if (!this.pastView) {
                    if (page !== 'battl-info') {
                        prevArea = 'artists';
                    }
                    this.loadFirstView(prevArea);
                }
                require(["text!../../templates/html/{0}.html".format(page), "views/{0}".format(page)], $.proxy(this.onNavigateModalDetailsComplete, this, id, title));
            },
            onNavigateComplete: function (html, view) {
                var area = "";
                this.pageContainer.empty().append(html);
                this.currentView = new view();
                this.pastView = this.currentView;

                area = this.currentView.$el.selector.replace(/\./, "");

                this.header.selectMenuItemByHash(area);

                if (this.currentSong.sound) {
                    if (this.currentSong.muted === false) {
                        this.showSoundWave();
                        this.resumeSoundWave();
                    }
                } else {
                    this.hideSoundWave();
                }
            },
            onNavigateModalComplete: function (html, view) {
                this.modal.off('modalClose');
                this.modal.on('modalClose', $.proxy(this.closeModal, this));
                this.modal.show(html);
                this.currentView = new view();
            },
            onNavigateModalDetailsComplete: function (id, title, html, view) {
                this.modal.off('modalClose');
                this.modal.on('modalClose', $.proxy(this.closeModal, this));
                this.modal.show(html);
                this.currentView = new view({ id: id });
            },
            getPastViewId: function () {
                var retorno = "";
                retorno = "#/site/" + this.pastView.$el.selector.replace(".", "");
                return retorno;
            },
            navigate: function (path) {
                var area = path.replace(/\#\/site\//, ""),
                    subArea = area.split("/");

                if (subArea.length > 1) {
                    area = subArea[0];
                }

                if (this.currentView && this.currentView.dispose) {
                    this.currentView.dispose();
                } else {
                    this.header.selectMenuItemByHash(area);
                }

                musicBattlUtils.trackPageview(path);
                this.router.navigate(path, { trigger: true, replace: true });
            },
            navigateDetails: function (path) {
                if (this.currentView && this.currentView.dispose) {
                    //this.currentView.dispose();
                }

                musicBattlUtils.trackPageview(path);
                this.router.navigate(path, { trigger: true, replace: true });
            }
        });

        return Master;
    });