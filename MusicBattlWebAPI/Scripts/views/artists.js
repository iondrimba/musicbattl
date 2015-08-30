define([
    "text!../../templates/html/pagination.html",
    "text!../../templates/html/artists-list.html",
    "viewModels/artistsViewModel",
    "views/paging"],
    function (
        paging,
        html,
        ViewModel,
        PagingView) {
        var Artist = Backbone.View.extend({
            el: ".artists",
            initialize: function () {
                this.model = new ViewModel();
                this.model.bind("change", $.proxy(this.onModelChange, this));
                this.render();                
                this.model.fetch();
            },
            render: function () {
                var hbrs = Handlebars.compile(html),
                    tplt;

                tplt = hbrs({ data: this.model.collection });

                this.$el.find(".ph").html(tplt);
            },
            showArtistProfile: function (id, title) {
                var url = "#/site/artist-contact/{0}/{1}".format(id, title.replace(/\W/g, "-"));
                master.navigateDetails(url.toLowerCase());
            },
            events: {
                "click .artist-list>li": "onArtistClick"
            },
            onArtistClick: function (evt) {
                var item = $(evt.currentTarget),
                    artistid = 0,
                    name = "";
                artistid = parseInt(item.data("id"), 10);
                name = item.data("name");

                this.showArtistProfile(artistid, name);
            },
            onModelChange: function () {
                this.render();
            },
            onPaginar: function (page) {
                this.model.getPage(page);
            }
        });

        return Artist;
    });