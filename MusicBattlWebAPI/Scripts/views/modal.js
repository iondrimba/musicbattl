define([], function () {
    var ModalView = Backbone.View.extend({
        el: ".modal",
        events: {
            "click .modal-overlay": "onOverlayClick"
        },
        initialize: function () {
            this.modalContainer = $(".modal-ph");
        },
        render: function () {
        },
        onOverlayClick: function (evt) {
            this.close();
        },
        show: function (html) {
            var height = 0,
                scope = this;
            this.modalContainer.empty().append(html);
            
            $.wait(0, function () {
                scope.$el.show();
                height = scope.modalContainer.outerHeight();
                //scope.modalContainer.css("margin-top", -(height / 2) + "px");
            })
        },
        close: function () {
            this.trigger('modalClose');
            this.$el.hide();            
            master.navigate(master.getPastViewId());
            this.modalContainer.empty();
        }
    });

    return ModalView;
});