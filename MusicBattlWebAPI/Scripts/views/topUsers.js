define([
    "text!../../templates/html/top-users.html",
    "text!../../templates/html/pagination.html",
    "viewModels/topUsersViewModel",
    "views/paging"],
    function (
        html,
        paging,
        ViewModel,
        PagingView) {
        var TopUsers = Backbone.View.extend({
            el: ".home-users",
            initialize: function () {
                this.model = new ViewModel();
                this.model.bind("change", $.proxy(this.onModelChange, this));
                this.render();                
            },
            load: function () {
                this.model.getPage(0);
            },
            dispose: function () {
                this.stopListening();
                this.undelegateEvents();
                $(this.el).removeData().unbind();
            },
            update: function (data) {
                this.model.update(data);
                this.render();
            },
            render: function () {
                var hbrs = Handlebars.compile(html),
                    tplt = hbrs({ data: this.model.collection, title: "TOP USERS" });

                this.$el.find(".ph").html(tplt);
                this.$el.find(".ph").parent().find(".pagination").remove();
                this.$el.find(".ph").parent().append(paging);

                if (this.pagingView) {
                    this.pagingView.dispose();
                }

                this.pagingView = new PagingView({ el: this.$el.find(".pagination").selector, currentPage: this.model.page, total: this.model.total, maxItens: this.model.collection.length * 2 });
                this.pagingView.on("onPaginar", $.proxy(this.onPaginar, this));

                this.showUsers();

                eventHandler.trigger('userloaded');
                return this;
            },
            showUsers: function () {
                var rows = this.$el.find(".mini-image:not([data-name=])");
                rows.each(function (index) {
                    var elmt = $(this);
                    elmt.removeClass("opaque-content");
                });
            },
            events: {
            },
            onPaginar: function (page) {
                this.model.getPage(page);
            },
            onModelChange: function () {
                this.render();
            }
        });

        return TopUsers;
    });