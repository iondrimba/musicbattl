define([ "models/pieChartModel"], function ( Model) {
    'use strict';
    var pieChartCollection = new Backbone.Collection([Model], {
        model: Model,
        url: ""
    });

    return pieChartCollection;
});