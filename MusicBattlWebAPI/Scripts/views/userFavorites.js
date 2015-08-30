define([
    "text!../../templates/html/big-album-list.html",
    "text!../../templates/html/pagination.html",
    "viewModels/userFavoritesViewModel",
    "views/paging"], function (
        html,
        paging,
        ViewModel,
        PagingView) {
        var UserFavorites = Backbone.View.extend({
            el: ".user-favorites",
            initialize: function () {
                this.profileId = master.loginManager.loggedUser.profileId;
                this.model = new ViewModel();
                this.model.url = "/api/UserProfile/Favorites/{0}/?page={1}&rowCount={2}".format(this.profileId, 0, this.model.collection.length);
                this.model.bind("change", $.proxy(this.onModelChange, this));
                this.render();
                this.model.fetch();
            },
            render: function () {
                var hbrs = Handlebars.compile(html),
                    tplt;

                tplt = hbrs({ data: this.model.collection, title: "FAVORITE SONGS" });

                this.$el.find(".ph").html(tplt);
                this.$el.find(".ph").parent().find(".pagination").remove();
                this.$el.find(".ph").parent().append(paging);

                if (this.pagingView) {
                    this.pagingView.dispose();
                }

                this.pagingView = new PagingView({ el: this.$el.find(".pagination").selector, currentPage: this.model.page, total: this.model.total, maxItens: this.model.collection.length });
                this.pagingView.on("onPaginar", $.proxy(this.onPaginar, this));

                this.showFavorites();
                return this;
            },
            showFavorites: function () {
                var rows = this.$el.find(".big-album:not([data-name=])");
                rows.each(function (index) {
                    var elmt = $(this);
                    elmt.removeClass("opaque-content");
                });
            },
            events: {
            },
            onPaginar: function (page) {
                this.model.url = "/api/UserProfile/Favorites/{0}/?page={1}&rowCount={2}".format(this.profileId, page, this.model.collection.length);
                this.model.getPage(page);
            },
            onModelChange: function () {
                this.render();
            }
        });

        return UserFavorites;
    });