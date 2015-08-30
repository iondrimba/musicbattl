define([], function () {
    var MusicBattlSignalR = Backbone.Model.extend({
        initialize: function () {

            this.timer = $.connection.battlTimer;
            this.timer.client.updateBattlTimer = this.updateBattlTimer;
            this.timer.client.updateBattlResetTimer = this.updateBattlResetTimer;
            this.timer.client.battlStarted = this.battlStarted;
            this.timer.client.battlEnded = this.battlEnded;
            this.timer.client.updateBattlVotes = this.updateBattlVotes;
            this.timer.client.battlReset = this.battlReset;
            this.timer.client.battlReseted = this.battlReseted;
            this.battleState = undefined;

            $.connection.hub.url = "/signalr";
            $.connection.hub.logging = false;
            $.connection.hub.start()
                .then($.proxy(this.initSignlR, this))
                .then($.proxy(this.getBattlState, this))
                .done($.proxy(this.onBattlStateResponse, this));
        },
        dispose: function () {
            this.stopListening();
            eventHandler.off("onBattlStart", null, null);
            eventHandler.off("onBattlEnd", null, null);
            eventHandler.off("onBattlReset", null, null);
            eventHandler.off("onBattlVote", null, null);
        },
        initSignlR: function () {
            var scope = this;
            this.bind("change", this.onModelChange);
            eventHandler.on("onBattlStart", $.proxy(this.onBattlStart, this));
            eventHandler.on("onBattlEnd", $.proxy(this.onBattEnd, this));
            eventHandler.on("onBattlReset", $.proxy(this.onBattlReset, this));
            eventHandler.on("onBattlVote", $.proxy(this.onBattlVote, this));

            return this.timer.server.getTime().done(function (data) {
                scope.onBattlStart();
            });
        },
        updateBattlTimer: function (data) {
            var digitalClick = musicBattlUtils.convertMillisecondsToDigitalClock(data);
            eventHandler.trigger("onBattlTimerUpdated", digitalClick);
        },
        updateBattlResetTimer: function (data) {
            eventHandler.trigger("onBattlResetTimerUpdated", {});
        },
        battlStarted: function (data) {
            eventHandler.trigger("onBattlStarted", data);
        },
        battlEnded: function (data) {
            eventHandler.trigger("onBattlEnded", data);
        },
        battlReseted: function (data) {
            eventHandler.trigger("onBattlReseted", {});
        },
        onBattlStart: function () {
            this.timer.server.battlStart();
        },
        onBattlEnd: function () {
            this.timer.server.battlEnd();
        },
        onBattlReset: function () {
            this.timer.server.battlReset();
        },
        onModelChange: function (data) {
        },
        updateBattlVotes: function (data) {
            eventHandler.trigger("onBattlVotesUpdated", data);
        },
        voteSong: function (data) {
            this.timer.server.battlVote(data);
        },
        getBattlState: function () {
            return this.timer.server.getBattlState();
        },
        onBattlStateResponse: function (state) {
            this.battleState = state;

            if (state === 'Open') {
                this.timer.client.battlStarted();
            }
            if (state === 'Reset') {
                this.timer.client.battlReseted();
            }
            if (state === 'Closed') {
                this.timer.client.battlEnded();
            }
        }
    });

    return MusicBattlSignalR;
});