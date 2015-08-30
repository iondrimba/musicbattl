define([
    "text!../../templates/html/versus-list.html",
    "text!../../templates/html/pagination.html",
    "viewModels/pastBattlsViewModel",
    "views/paging"],
    function (
        html,
        paging,
        ViewModel,
        PagingView) {
        var PastBattls = Backbone.View.extend({
            el: ".past-battls",
            initialize: function () {
                var battleEnded = $.proxy(this.onBattlEnded, this);
                eventHandler.on("onBattlEnded", battleEnded);

                this.model = new ViewModel();
                this.model.bind("change", $.proxy(this.onModelChange, this));
                this.render();                
            },
            load: function () {
                this.model.getPage(0);
            },
            update: function(data) {
                this.model.update(data);
                this.model.total = data.Total;
                this.render();
            },
            dispose: function () {
                this.stopListening();
                this.undelegateEvents();
                $(this.el).removeData().unbind();
            },
            render: function () {
                var hbrs = Handlebars.compile(html),
                    tplt;

                tplt = hbrs({ data: this.model.collection, title: "PAST BATTLS" });

                this.$el.find(".ph").html(tplt);
                this.$el.find(".ph").parent().find(".pagination").remove();
                this.$el.find(".ph").parent().append(paging);

                if (this.pagingView) {
                    this.pagingView.dispose();
                }

                this.pagingView = new PagingView({ el: this.$el.find(".pagination").selector, currentPage: this.model.page, total: this.model.total, maxItens: this.model.collection.length });
                this.pagingView.on("onPaginar", $.proxy(this.onPaginar, this));

                this.showWinners();

                eventHandler.trigger('pastbattlloaded');
                return this;
            },
            showWinners: function () {
                var rows = this.$el.find(".versus-row");
                rows.each(function (index) {
                    var elmt = $(this),
                        leftSong = {},
                        rightSong = {};

                    leftSong = elmt.find(".left-album:not([data-songid=0]:eq(1))");
                    rightSong = elmt.find(".right-album:not([data-songid=0]:eq(0))");

                    if (leftSong.data("votes") > rightSong.data("votes")) {
                        leftSong.find("[data-badge]").addClass("won");
                        rightSong.find("[data-badge]").addClass("loss");
                    }
                    if (leftSong.data("votes") < rightSong.data("votes")) {
                        leftSong.find("[data-badge]").addClass("loss");
                        rightSong.find("[data-badge]").addClass("won");
                    }
                });
            },
            fillToolTipData: function (elmt, data) {
                elmt.find(".artist").text(data.artist);
                elmt.find(".song").text(data.song);
            },
            showVotes: function (linha) {
                linha.find(".votes").removeClass("hidden");
            },
            removeVotes: function () {
                var row = this.$el.find(".versus-row");
                this.$el.find(".votes").addClass("hidden");
                row.removeClass("active");
                row.find(".versus-min").removeClass("expand");

                TweenLite.to(this.$el.find(".versus-row"), .5, { opacity: 1 });
            },
            showBattlDetails: function (id, nameLeft, nameRight) {
                var url = "#/site/battl-info/{0}/{1}-VS-{2}".format(id, nameLeft.replace(/\W/g, "-"), nameRight.replace(/\W/g, "-"));
                master.navigateDetails(url.toLowerCase());
            },
            events: {
                "mouseenter .versus-row": "onMouseOver",
                "mouseleave .versus-row": "onMouseOut",
                "click .versus-row": "onRowClick"
            },
            onRowClick: function (evt) {
                var item = $(evt.currentTarget),
                    battlId = 0,
                    nameLeft = "",
                    nameRight = "";

                battlId = parseInt(item.data("id"), 10);
                nameLeft = "{0}-{1}".format(item.find(".left-album").data("artist"), item.find(".left-album").data("song"));
                nameRight = "{0}-{1}".format(item.find(".right-album").data("artist"), item.find(".right-album").data("song"));;

                this.showBattlDetails(battlId, nameLeft, nameRight);
            },
            onMouseOver: function (evt) {
                var linha = $(evt.currentTarget);
                linha.addClass("active");
                TweenLite.to(linha.parent().find(".versus-row:not(.active)"), .5, { opacity: .3 });
            },
            onMouseOut: function (evt) {
                this.removeVotes();
            },
            onBattlEnded: function (data) {                
                this.model.getPage(0);
            },
            onPaginar: function (page) {
                this.model.getPage(page);
            },
            onModelChange: function (data) {                
                this.render();
            }
        });

        return PastBattls;
    });