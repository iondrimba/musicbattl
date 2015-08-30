define([
    "text!../../templates/html/twitter-widget.html"
], function (html) {
    var TwitterWidget = Backbone.View.extend({
        el: ".twitter-widget",
        initialize: function () {
            this.render();
        },
        dispose: function () {
            this.stopListening();
            this.undelegateEvents();
            $(this.el).removeData().unbind();
        },
        render: function () {
            this.$el.append(html);
            return this;
        },
        events: {
        }
    });

    return TwitterWidget;
});