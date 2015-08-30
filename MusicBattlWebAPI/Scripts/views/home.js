define(["views/battl",
    "views/pastBattls",
    "views/allTimeWinners",
    "views/mostVoted",
    "views/topUsers",
    "viewModels/homeViewModel"
],
    function (
        BattlView,
        PastBattlsView,
        AllTimeWinnersView,
        MostVotedView,
        TopUsersView,
        HomeViewModel
        ) {
        var Home = Backbone.View.extend({
            el: ".home",
            initialize: function () {
                var battlloaded = false,
                    pastbattlloaded = false,
                    alltimeloaded = false,
                    mostvotedloaded = false,
                    userloaded = false;

                eventHandler.on('battlloaded', function () {
                    battlloaded = true;
                });
                eventHandler.on('pastbattlloaded', function () {
                    pastbattlloaded = true;
                });
                eventHandler.on('alltimeloaded', function () {
                    alltimeloaded = true;
                });
                eventHandler.on('mostvotedloaded', function () {
                    mostvotedloaded = true;
                });
                eventHandler.on('userloaded', function () {
                    userloaded = true;
                });


                this.model = new HomeViewModel();
                this.model.bind("change", $.proxy(this.onModelChange, this));

                this.battl = new BattlView();
                this.pastBattls = new PastBattlsView();
                this.allTimeWinners = new AllTimeWinnersView();
                this.mostVoted = new MostVotedView();
                this.topUsers = new TopUsersView();
                var scope = this;
                if (master.loadedFirstTime === false) {
                    var interval = setInterval(function () {
                        if (battlloaded) {
                            eventHandler.off('battlloaded');

                            clearInterval(interval);
                            scope.battl.load();
                            scope.model.fetch();
                            eventHandler.trigger('loaded');
                        }
                    }, 1000);
                } else {
                    eventHandler.off('battlloaded');

                    clearInterval(interval);
                    clearInterval(interval);
                    scope.battl.load();
                    scope.model.fetch();
                    eventHandler.trigger('loaded'); eventHandler.trigger('loaded');
                }

                this.$el.hide();
                this.$el.removeClass("hidden");
                this.$el.fadeIn(350);
            },
            dispose: function () {
                this.battl.dispose();
                this.pastBattls.dispose();
                this.allTimeWinners.dispose();
                this.mostVoted.dispose();
                this.topUsers.dispose();
                this.undelegateEvents();
                $(this.el).removeData().unbind();
            },
            render: function () {
                return this;
            },
            events: {
                "click .sub-menu-link": "onSubMenuLinkClick"
            },
            onSubMenuLinkClick: function (evt) {
                var path = $(evt.currentTarget).attr("href");
                musicBattlUtils.trackPageview(path);
            },
            onModelChange: function (data) {
                this.pastBattls.update(data.changed.pastbattleresut);
                this.allTimeWinners.update(data.changed.alltimeresult);
                this.mostVoted.update(data.changed.mosteVotedresult);
                this.topUsers.update(data.changed.topusersresult);
            }
        });

        return Home;
    });