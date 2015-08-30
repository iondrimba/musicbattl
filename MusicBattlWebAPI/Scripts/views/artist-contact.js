define([
    "text!../../templates/html/artist-contact-details.html",
    "viewModels/artistContactViewModel"],
    function (
        html,
        ViewModel) {
        var ArtistContact = Backbone.View.extend({
            el: ".artist-contact",
            initialize: function (options) {
                this.options = options;
                this.model = new ViewModel({ artistId: this.options.id });
                this.model.bind("change", $.proxy(this.onModelChange, this));                
                this.model.fetch();
            },
            render: function () {
                var hbrs = Handlebars.compile(html),
                    tplt;
                tplt = hbrs({ data: this.model.collection[0]});
                this.$el.find(".ph").html(tplt);
            },
            events: {
            },
            onModelChange: function () {
                this.render();
            }
        });

        return ArtistContact;
    });