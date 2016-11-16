define([
    "text!../../templates/html/pagination.html",
    "text!../../templates/html/most-voted.html",
    "viewModels/mostVotedViewModel",
    "views/paging"],
    function (
        paging,
        html,
        ViewModel,
        PagingView) {
        var MostVoted = Backbone.View.extend({
            el: ".most-liked",
            events: {
                "click .tab-day": "onDayClick",
                "click .tab-week": "onWeekClick",
                "click .tab-month": "onMonthClick"
            },
            initialize: function () {
                var battleEnded = $.proxy(this.onBattlEnded, this);
                eventHandler.on("onBattlEnded", battleEnded);

                this.model = new ViewModel();
                
                this.activateTab(0);
                this.render();               
            },
            update: function (data) {
                this.model.update(data);
                this.render();
            },
            load: function () {
                this.onMonthGet(0);
            },
            dispose: function () {
                this.stopListening();
                this.undelegateEvents();
                $(this.el).removeData().unbind();
            },
            render: function () {
                var list = this.$el.find(".most-voted-list").find(".ph"),
                    hbrs,
                    data;

                list.empty();
                list.parent().find(".pagination").remove();
                hbrs = Handlebars.compile(html);
                data = this.model.collection;
                
                tplt = hbrs({ data: data });
                                
                list.html(tplt);
                list.parent().append(paging);
                list.find(".media-list").hide();
                list.find(".media-list").fadeIn(200);
                
                if (this.pagingView) {
                    this.pagingView.dispose();
                }


                this.pagingView = new PagingView({ el: this.$el.find(".pagination").selector, currentPage: this.model.page, total: this.model.total, maxItens: this.model.collection.length });
                this.pagingView.on("onPaginar", $.proxy(this.onPaginar, this));

                this.showMostVoted();
                
                eventHandler.trigger('mostvotedloaded');
            },
            showMostVoted: function () {
                var rows = this.$el.find(".mini-album:not([data-name=])");
                rows.each(function (index) {
                    var elmt = $(this);
                    elmt.removeClass("opaque-content");
                });
            },
            getActiveTab: function () {
                var active = 0;
                active = $(".most-voted-tab").find(".active-tab").index();
                return active;
            },
            activateTab: function (index) {
                var tab = $(".most-voted-tab"),
                    tabItens = tab.find("li"),
                    activeTab;

                tabItens.removeClass("active-tab");
                tabItens.find("span").removeClass("tab-fonts-active").addClass("tab-fonts");

                activeTab = tab.find("li:eq({0})".format(index));
                activeTab.addClass("active-tab");
                activeTab.find("span").removeClass("tab-fonts").addClass("tab-fonts-active");
            },
            onDayClick: function (evt) {
                var options = {};
                options.category = "Home";
                options.action = "MostVoted";
                options.label = "Day";
                musicBattlUtils.trackEvent(options);

                this.activateTab(2);
                this.onDayGet(0);
            },
            onWeekClick: function (evt) {
                var options = {};
                options.category = "Home";
                options.action = "MostVoted";
                options.label = "Week";
                musicBattlUtils.trackEvent(options);

                this.activateTab(1);
                this.onWeekGet(0);
            },
            onMonthClick: function (evt) {
                var options = {};
                options.category = "Home";
                options.action = "MostVoted";
                options.label = "Month";
                musicBattlUtils.trackEvent(options);

                this.activateTab(0);
                this.onMonthGet(0);
            },
            onDayGet: function (page) {
                this.model.url = "api/MostVoted/SongsDay/0/{0}/{1}".format(page, this.model.collection.length);
                this.model.page = page;
                this.model.fetch({ success: $.proxy(this.onModelChange, this) });
            },
            onWeekGet: function (page) {
                this.model.url = "api/MostVoted/SongsWeek/0/{0}/{1}".format(page, this.model.collection.length);
                this.model.page = page;
                this.model.fetch({ success: $.proxy(this.onModelChange, this) });
            },
            onMonthGet: function (page) {
                this.model.url = "api/MostVoted/SongsMonth/0/{0}/{1}".format(page, this.model.collection.length);
                this.model.page = page;
                this.model.fetch({ success: $.proxy(this.onModelChange, this) });
            },
            onBattlEnded: function (data) {
                this.onPaginar(0);
            },
            onModelChange: function () {
                this.render();
            },
            onPaginar: function (page) {
                if (this.getActiveTab() === 2) {
                    this.model.page = page;
                    this.onDayGet(this.model.page);
                }

                if (this.getActiveTab() === 1) {
                    this.model.page = page;
                    this.onWeekGet(this.model.page);
                }
                if (this.getActiveTab() === 0) {
                    this.model.page = page;
                    this.onMonthGet(this.model.page);
                }
            }
        });

        return MostVoted;
    });