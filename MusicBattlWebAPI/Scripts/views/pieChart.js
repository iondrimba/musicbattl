define([
    "text!../../templates/html/pie-chart.html",
    "collections/pieChartCollection"],
    function (
        html,
        Collection,
        Charts) {
        var GraphTop = Backbone.View.extend({
            el: ".pie-graph-item",
            initialize: function (options) {
                this.options = options;
                this.model = Collection;
                this.model.url = "/api/Charts/PieChart{0}".format(this.options.type);
                this.model.bind("change", this.onModelChange);
            },
            update: function(data) {                
                this.render(data);
            },
            render: function (data) {
                var hbrs = Handlebars.compile(html),
                    data = data || this.model.toJSON(),
                    tplt,
                    pieData,
                    scope = this;

                this.pieDefaults = {
                    //Boolean - Whether we should show a stroke on each segment
                    segmentShowStroke: false,
                    animationEasing: "easeOutBack",
                    animateRotate: true
                };

                pieData = _.map(data, function (obj, index) {
                    return {
                        value: obj.Value,
                        color: scope.options.colors[index],
                        legend: obj.Legend
                    };
                });
                tplt = hbrs({ data: pieData, title: this.options.title, type: this.options.type });
                this.$el.html(tplt);

                this.chart = new Chart(document.getElementById("canvas-{0}".format(this.options.type)).getContext("2d")).Pie(pieData, this.pieDefaults);

                return this;
            },
            events: {
            },
            onModelChange: function () {
                this.render();
            }
        });

        return GraphTop;
    });