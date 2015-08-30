define([
    "../text!../../templates/html/big-album-list.html",
    "../text!../../templates/html/pagination.html",
    "viewModels/allTimeWinnersViewModel",
    "views/paging"],
    function (
        html,
        paging,
        ViewModel,
        PagingView) {
        var AllTimeWinners = Backbone.View.extend({
            el: ".all-time-winners",
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
            update: function (data) {      
                this.model.update(data);
                this.render();
            },
            dispose: function () {
                this.stopListening();
                this.undelegateEvents();
                $(this.el).removeData().unbind();
            },
            render: function () {
                var hbrs = Handlebars.compile(html);

                tplt = hbrs({ data: this.model.collection, title: "ALL TIME WINNERS" });

                this.$el.find(".ph").html(tplt);
                this.$el.find(".ph").parent().find(".pagination").remove();
                this.$el.find(".ph").parent().append(paging);

                if (this.pagingView) {
                    this.pagingView.dispose();
                }

                this.pagingView = new PagingView({ el: this.$el.find(".pagination").selector, currentPage: this.model.page, total: this.model.total, maxItens: this.model.collection.length });
                this.pagingView.on("onPaginar", $.proxy(this.onPaginar, this));

                this.showWinners();

                eventHandler.trigger('alltimeloaded');

                return this;
            },
            showWinners: function () {
                var rows = this.$el.find(".big-album:not([data-name=])");
                rows.each(function (index) {
                    var elmt = $(this);
                    elmt.removeClass("opaque-content");
                });
            },
            events: {
            },
            onBattlEnded: function (data) {
                this.model.getPage(0);
            },
            onPaginar: function (page) {
                this.model.getPage(page);
            },
            onModelChange: function () {
                this.render();
            }
        });

        return AllTimeWinners;
    });