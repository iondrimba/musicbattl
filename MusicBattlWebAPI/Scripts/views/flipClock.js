Countdown = function () {
    _(this).bindAll('update', 'executeAnimation', 'finishAnimation');
    this.setVars.apply(this, arguments);
    this.update();

    return this;
};

Countdown.prototype = {
    duration: 1000,
    setVars: function (time, el, template) {
        if (template) {
            this.max = time;
            this.time = time;
            this.nextTime = 0;
            this.el = el;
            this.template = _(template.innerHTML).template();
            this.delta = +1;
        }
    },
    dispose: function () {
    },
    update: function (time) {
        this.time = time;
        if (isNaN(this.time)) {
            this.time = 0;
            this.setSizes();
            this.setupAnimation();
            this.toggleDirection('up', 'down');
        } else {
            this.checkTime();
            this.toggleDirection('up', 'down');
            this.setSizes();
            this.setupAnimation();
            if (this.time >= 0) {
                _(this.executeAnimation).delay(20);
                _(this.finishAnimation).delay(this.duration * 0.9);
            }
        }
    },
    updateWithoutAnimation: function (time) {
        this.time = time;
        this.setSizes();
        this.setupAnimation();
        this.toggleDirection('up', 'down');
    },
    checkTime: function () {
        this.time += this.delta;
        
        if (this.time >= 60) {
            this.time = 0;
        }
        this.nextTime = this.time - this.delta;
        
        if (this.time == 0 && this.nextTime < 0) {
            this.nextTime = 59;
        }
        if (this.nextTime < 0) {
            this.nextTime = 0;
        }
    },
    toggleDirection: function (add, remove) {
        if (this.el) {
            this.el.classList.add(add);
            this.el.classList.remove(remove);
        }
    },
    setSizes: function () {
        this.currentSize = this.getSize(this.time);
        this.nextSize = this.getSize(this.nextTime);
    },
    getSize: function (time) {
        return time > 9 ? 'small' : '';
    },
    setupAnimation: function () {
        if (this.template) {
            this.el.innerHTML = this.template(this);
            this.el.classList.remove('changed');
        }
    },
    executeAnimation: function () {
        this.el.classList.add('changing');
    },
    finishAnimation: function () {
        this.el.classList.add('changed');
        this.el.classList.remove('changing');
    }
};

define([],
    function () {
        var FlipClock = Backbone.View.extend({
            el: ".clock",
            initialize: function () {
                this.minutes = 0;
                this.pastMinute = undefined;
                this.seconds = 0;
                this.clockLeft = {};
                this.clockRight = {};
                this.fisrtTime = true;
                this.render();
            },
            dispose: function () {
                this.clockLeft = null;
                this.clockRight = null;
            },
            render: function () {
                this.clockLeft = new Countdown(
                    this.minutes,
                    document.querySelector('.count-left'),
                    document.querySelector('#count-template')
                );
                this.clockRight = new Countdown(
                    this.seconds,
                    document.querySelector('.count-right'),
                    document.querySelector('#count-template')
                );
            },
            updateMinClock: function (minutes) {
                this.minutes = minutes;

                if (this.minutes !== this.pastMinute) {
                    this.pastMinute = this.minutes;

                    if (window.typeos !== "windows" || window.typeos === "mac" || window.userBrowser === "safari") {
                        this.clockLeft.updateWithoutAnimation(minutes);
                    } else {
                        this.clockLeft.update(minutes);
                    }
                    this.fisrtTime = false;
                }
            },
            reset: function () {
                this.clockLeft.updateWithoutAnimation(0);
                if (window.typeos !== "windows" || window.typeos === "mac" || window.userBrowser === "safari") {
                    this.clockRight.updateWithoutAnimation(0);
                } else {
                    this.clockRight.update(0);
                }
            },
            updateMinClockWithoutAnimation: function (minutes) {
                this.minutes = minutes;
                this.pastMinute = minutes;
                this.clockLeft.updateWithoutAnimation(minutes);
            },
            updateSecClock: function (seconds) {
                this.seconds = seconds;
                if (window.typeos !== "windows" || window.typeos === "mac" || window.userBrowser === "safari") {
                    this.clockRight.updateWithoutAnimation(seconds);
                } else {                    
                    this.clockRight.update(seconds);
                }
            }
        });

        return FlipClock;
    });