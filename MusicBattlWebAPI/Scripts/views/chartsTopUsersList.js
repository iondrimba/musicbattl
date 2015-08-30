define([
    "text!../../templates/html/top-users.html",
    "text!../../templates/html/pagination.html",
    "viewModels/chartsTopUsersListViewModel",
    "views/paging"],
    function (
        html,
        paging,
        ViewModel,
        PagingView) {
        var ChartsTopUsersList = Backbone.View.extend({
            el: ".top-users-list",
            events: {
            },
            initialize: function () {
                this.model = new ViewModel();
                this.model.url = "/api/Charts/TopUsers{0}/?page={1}&rowCount={2}".format(this.options.type, this.model.page, this.model.collection.length);
                this.model.bind("change", $.proxy(this.onModelChange, this));
                this.render();
                this.model.getPage(0);
            },
            render: function () {
                var hbrs = Handlebars.compile(html),
                    tplt;

                tplt = hbrs({ data: this.model.collection, title: this.options.title });

                this.$el.find(".ph").html(tplt);
                this.$el.find(".ph").parent().find(".pagination").remove();
                this.$el.find(".ph").parent().append(paging);

                if (this.pagingView) {
                    this.pagingView.dispose();
                }

                this.pagingView = new PagingView({ el: this.$el.find(".pagination").selector, currentPage: this.model.page, total: this.model.total, maxItens: this.model.collection.length * 2 });
                this.pagingView.on("onPaginar", $.proxy(this.onPaginar, this));

                this.showUsers();

                return this;
            },
            showUsers: function () {
                this.$el.find(".opaque-content:not([data-name='Name'])").removeClass("opaque-content");
            },
            onPaginar: function (page) {
                this.model.url = "/api/Charts/TopUsers{0}/?page={1}&rowCount={2}".format(this.options.type, page, this.model.collection.length);
                this.model.getPage(page);
            },
            onModelChange: function () {
                this.render();
            }
        });

        return ChartsTopUsersList;
    });