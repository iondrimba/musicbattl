define([], function () {
    var PagingView = Backbone.View.extend({
        el: ".pagination",
        initialize: function (options) {
            this.options = options;
            this.el = this.options.el;
            this.total = this.options.total;
            this.currentPage = this.options.currentPage;
            this.page = 0;
            this.maxPages = 5;
            this.maxItens = this.options.maxItens;
            this.totalPages = this.total / this.maxItens;
            this.url = this.options.url;
            this.previousBtn = this.$el.find(".pagination-previous");
            this.nextBtn = this.$el.find(".pagination-next");

            this.render();

            if (this.total > this.maxItens) {
                this.nextBtn.removeClass("hidden");
                this.previousBtn.removeClass("hidden");
                this.pageActiveSelect(this.page);
            } else {
                this.$el.find(".pagination-item").remove();
            }
        },
        dispose: function () {
            this.undelegateEvents();
            $(this.el).removeData().unbind();
            this.stopListening();
            this.off();
        },
        render: function () {
            var itemTpl = "<li class='pagination-item' data-page='{0}'>{0}</li>",
                i = 0,
                pageGroupIndex = 0,
                element = {},
                index = 0,
                total = 0;

            pageGroupIndex = Math.floor(this.currentPage / this.maxPages);
            total = this.maxPages + (pageGroupIndex * this.maxPages);
            index = pageGroupIndex * this.maxPages;

            this.$el.find(".pagination-item").remove();

            i = index;
            this.page = this.currentPage;
            if (!isNaN(this.currentPage % index)) {
                this.page = this.currentPage % index;
            }

            for (i; i < total; i += 1) {
                element = $(itemTpl.format(i + 1));
                this.$el.find("li").last().before(element);
                if (i >= this.totalPages) {
                    element.addClass("disabled");
                }
            }

            this.pageActiveSelect(this.page);

            this.trigger("onPaginar", this.currentPage);

            return this;
        },
        enablePrevButton: function () {
            this.enableButton(".pagination-previous", 0, "onPagingPrevClick");
        },
        enableNextButton: function () {
            this.enableButton(".pagination-next", Math.ceil(this.totalPages - 1), "onPagingNextClick");
        },
        enableButton: function (button, total, event) {
            if (this.currentPage === total) {
                this.events["click {0}".format(button)] = undefined;
                this.$el.find(button).addClass("disabled");
            } else {
                this.events["click {0}".format(button)] = event;
                this.delegateEvents(this.events);
                this.$el.find(button).removeClass("disabled");
            }
        },
        pageActiveSelect: function (page) {
            this.enablePrevButton();
            this.enableNextButton();
            if (page > this.maxPages) {
                page = page - (this.maxPages - 1);
            }

            this.$el.find(".pagination-item-active").removeClass("pagination-item-active");
            this.$el.find(".pagination-item:eq({0})".format(page)).addClass("pagination-item-active");
        },
        events: {
            "click .pagination-item:not(.disabled)": "onPagingItemClick"
        },
        onPagingItemClick: function (evt) {
            var target = $(evt.currentTarget);
            this.currentPage = musicBattlUtils.convertToNumber(target.text(), 0);
            this.trigger("onPaginar", this.currentPage - 1);
        },
        onPagingPrevClick: function (evt) {
            if (this.currentPage > 0) {
                this.currentPage -= 1;
                this.render();
            }
        },
        onPagingNextClick: function (evt) {
            if (this.currentPage < Math.ceil(this.totalPages) - 1) {
                this.currentPage += 1;
                this.render();
            }
        }
    });

    return PagingView;
});