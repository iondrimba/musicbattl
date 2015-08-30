/*!
 * VERSION: 1.11.5
 * DATE: 2014-02-20
 * UPDATES AND DOCS AT: http://www.greensock.com
 *
 * @license Copyright (c) 2008-2014, GreenSock. All rights reserved.
 * This work is subject to the terms at http://www.greensock.com/terms_of_use.html or for
 * Club GreenSock members, the software agreement that was issued with your membership.
 * 
 * @author: Jack Doyle, jack@greensock.com
 */
(window._gsQueue || (window._gsQueue = [])).push(function () {
    "use strict"; window._gsDefine("TimelineLite", ["core.Animation", "core.SimpleTimeline", "TweenLite"], function (t, e, i) {
        var s = function (t) {
            e.call(this, t),
            this._labels = {},
            this.autoRemoveChildren = this.vars.autoRemoveChildren === !0, this.smoothChildTiming = this.vars.smoothChildTiming === !0, this._sortChildren = !0, this._onUpdate = this.vars.onUpdate; var i, s, r = this.vars; for (s in r) i = r[s], a(i) && -1 !== i.join("").indexOf("{self}") && (r[s] = this._swapSelfInParams(i));
            a(r.tweens) && this.add(r.tweens, 0, r.align, r.stagger)
        },
        r = 1e-10, n = i._internals.isSelector, a = i._internals.isArray, o = [], h = function (t) {
            var e, i = {};
            for (e in t) i[e] = t[e]; return i
        },
        l = function (t, e, i, s) {
            t._timeline.pause(t._startTime),
            e && e.apply(s || t._timeline, i || o)
        },
        _ = o.slice, u = s.prototype = new e; return s.version = "1.11.5", u.constructor = s, u.kill()._gc = !1, u.to = function (t, e, s, r) {
            return e ? this.add(new i(t, e, s),
            r) : this.set(t, s, r)
        },
        u.from = function (t, e, s, r) {
            return this.add(i.from(t, e, s),
            r)
        },
        u.fromTo = function (t, e, s, r, n) {
            return e ? this.add(i.fromTo(t, e, s, r),
            n) : this.set(t, r, n)
        },
        u.staggerTo = function (t, e, r, a, o, l, u, p) {
            var f, c = new s({ onComplete: l, onCompleteParams: u, onCompleteScope: p, smoothChildTiming: this.smoothChildTiming });
            for ("string" == typeof t && (t = i.selector(t) || t),
            n(t) && (t = _.call(t, 0)),
            a = a || 0, f = 0; t.length > f; f++) r.startAt && (r.startAt = h(r.startAt)),
            c.to(t[f], e, h(r),
            f * a);
            return this.add(c, o)
        },
        u.staggerFrom = function (t, e, i, s, r, n, a, o) { return i.immediateRender = 0 != i.immediateRender, i.runBackwards = !0, this.staggerTo(t, e, i, s, r, n, a, o) },
        u.staggerFromTo = function (t, e, i, s, r, n, a, o, h) { return s.startAt = i, s.immediateRender = 0 != s.immediateRender && 0 != i.immediateRender, this.staggerTo(t, e, s, r, n, a, o, h) },
        u.call = function (t, e, s, r) {
            return this.add(i.delayedCall(0, t, e, s),
            r)
        },
        u.set = function (t, e, s) {
            return s = this._parseTimeOrLabel(s, 0, !0),
            null == e.immediateRender && (e.immediateRender = s === this._time && !this._paused),
            this.add(new i(t, 0, e),
            s)
        },
        s.exportRoot = function (t, e) {
            t = t || {},
            null == t.smoothChildTiming && (t.smoothChildTiming = !0);
            var r, n, a = new s(t),
            o = a._timeline; for (null == e && (e = !0),
            o._remove(a, !0),
            a._startTime = 0, a._rawPrevTime = a._time = a._totalTime = o._time, r = o._first; r;) n = r._next, e && r instanceof i && r.target === r.vars.onComplete || a.add(r, r._startTime - r._delay),
            r = n; return o.add(a, 0),
            a
        },
        u.add = function (r, n, o, h) {
            var l, _, u, p, f, c;
            if ("number" != typeof n && (n = this._parseTimeOrLabel(n, 0, !0, r)),
            !(r instanceof t)) {
                if (r instanceof Array || r && r.push && a(r)) {
                    for (o = o || "normal", h = h || 0, l = n, _ = r.length, u = 0; _ > u; u++) a(p = r[u]) && (p = new s({ tweens: p })),
                    this.add(p, l),
                    "string" != typeof p && "function" != typeof p && ("sequence" === o ? l = p._startTime + p.totalDuration() / p._timeScale : "start" === o && (p._startTime -= p.delay())),
                    l += h; return this._uncache(!0)
                }

                if ("string" == typeof r) return this.addLabel(r, n);

                if ("function" != typeof r) throw "Cannot add " + r + " into the timeline; it is not a tween, timeline, function, or string."; r = i.delayedCall(0, r)
            }

            if (e.prototype.add.call(this, r, n),
            (this._gc || this._time === this._duration) && !this._paused && this._duration < this.duration()) for (f = this, c = f.rawTime() > r._startTime; f._timeline;) c && f._timeline.smoothChildTiming ? f.totalTime(f._totalTime, !0) : f._gc && f._enabled(!0, !1),
            f = f._timeline; return this
        },
        u.remove = function (e) {
            if (e instanceof t) return this._remove(e, !1);

            if (e instanceof Array || e && e.push && a(e)) {
                for (var i = e.length; --i > -1;) this.remove(e[i]);
                return this
            }
            return "string" == typeof e ? this.removeLabel(e) : this.kill(null, e)
        },
        u._remove = function (t, i) {
            e.prototype._remove.call(this, t, i);
            var s = this._last; return s ? this._time > s._startTime + s._totalDuration / s._timeScale && (this._time = this.duration(),
            this._totalTime = this._totalDuration) : this._time = this._totalTime = this._duration = this._totalDuration = 0, this
        },
        u.append = function (t, e) { return this.add(t, this._parseTimeOrLabel(null, e, !0, t)) },
        u.insert = u.insertMultiple = function (t, e, i, s) { return this.add(t, e || 0, i, s) },
        u.appendMultiple = function (t, e, i, s) {
            return this.add(t, this._parseTimeOrLabel(null, e, !0, t),
            i, s)
        },
        u.addLabel = function (t, e) {
            return this._labels[t] = this._parseTimeOrLabel(e),
            this
        },
        u.addPause = function (t, e, i, s) { return this.call(l, ["{self}", e, i, s], this, t) },
        u.removeLabel = function (t) { return delete this._labels[t], this },
        u.getLabelTime = function (t) { return null != this._labels[t] ? this._labels[t] : -1 },
        u._parseTimeOrLabel = function (e, i, s, r) {
            var n;
            if (r instanceof t && r.timeline === this) this.remove(r);
            else
                if (r && (r instanceof Array || r.push && a(r))) for (n = r.length; --n > -1;) r[n] instanceof t && r[n].timeline === this && this.remove(r[n]);

            if ("string" == typeof i) return this._parseTimeOrLabel(i, s && "number" == typeof e && null == this._labels[i] ? e - this.duration() : 0, s);

            if (i = i || 0, "string" != typeof e || !isNaN(e) && null == this._labels[e]) null == e && (e = this.duration());
            else {
                if (n = e.indexOf("="),
                -1 === n) return null == this._labels[e] ? s ? this._labels[e] = this.duration() + i : i : this._labels[e] + i; i = parseInt(e.charAt(n - 1) + "1", 10) * Number(e.substr(n + 1)),
                e = n > 1 ? this._parseTimeOrLabel(e.substr(0, n - 1),
                0, s) : this.duration()
            }
            return Number(e) + i
        },
        u.seek = function (t, e) {
            return this.totalTime("number" == typeof t ? t : this._parseTimeOrLabel(t),
            e !== !1)
        },
        u.stop = function () { return this.paused(!0) },
        u.gotoAndPlay = function (t, e) { return this.play(t, e) },
        u.gotoAndStop = function (t, e) { return this.pause(t, e) },
        u.render = function (t, e, i) {
            this._gc && this._enabled(!0, !1);
            var s, n, a, h, l, _ = this._dirty ? this.totalDuration() : this._totalDuration, u = this._time, p = this._startTime, f = this._timeScale, c = this._paused;
            if (t >= _ ? (this._totalTime = this._time = _, this._reversed || this._hasPausedChild() || (n = !0, h = "onComplete", 0 === this._duration && (0 === t || 0 > this._rawPrevTime || this._rawPrevTime === r) && this._rawPrevTime !== t && this._first && (l = !0, this._rawPrevTime > r && (h = "onReverseComplete"))),
            this._rawPrevTime = this._duration || !e || t || 0 === this._rawPrevTime ? t : r, t = _ + 1e-4) : 1e-7 > t ? (this._totalTime = this._time = 0, (0 !== u || 0 === this._duration && (this._rawPrevTime > r || 0 > t && this._rawPrevTime >= 0)) && (h = "onReverseComplete", n = this._reversed),
            0 > t ? (this._active = !1, 0 === this._duration && this._rawPrevTime >= 0 && this._first && (l = !0),
            this._rawPrevTime = t) : (this._rawPrevTime = this._duration || !e || t || 0 === this._rawPrevTime ? t : r, t = 0, this._initted || (l = !0))) : this._totalTime = this._time = this._rawPrevTime = t, this._time !== u && this._first || i || l) {
                if (this._initted || (this._initted = !0),
                this._active || !this._paused && this._time !== u && t > 0 && (this._active = !0),
                0 === u && this.vars.onStart && 0 !== this._time && (e || this.vars.onStart.apply(this.vars.onStartScope || this, this.vars.onStartParams || o)),
                this._time >= u) for (s = this._first; s && (a = s._next, !this._paused || c) ;
                ) (s._active || s._startTime <= this._time && !s._paused && !s._gc) && (s._reversed ? s.render((s._dirty ? s.totalDuration() : s._totalDuration) - (t - s._startTime) * s._timeScale, e, i) : s.render((t - s._startTime) * s._timeScale, e, i)),
                s = a; else for (s = this._last; s && (a = s._prev, !this._paused || c) ;
                ) (s._active || u >= s._startTime && !s._paused && !s._gc) && (s._reversed ? s.render((s._dirty ? s.totalDuration() : s._totalDuration) - (t - s._startTime) * s._timeScale, e, i) : s.render((t - s._startTime) * s._timeScale, e, i)),
                s = a; this._onUpdate && (e || this._onUpdate.apply(this.vars.onUpdateScope || this, this.vars.onUpdateParams || o)),
                h && (this._gc || (p === this._startTime || f !== this._timeScale) && (0 === this._time || _ >= this.totalDuration()) && (n && (this._timeline.autoRemoveChildren && this._enabled(!1, !1),
                this._active = !1),
                !e && this.vars[h] && this.vars[h].apply(this.vars[h + "Scope"] || this, this.vars[h + "Params"] || o)))
            }
        },
        u._hasPausedChild = function () {
            for (var t = this._first; t;) {
                if (t._paused || t instanceof s && t._hasPausedChild()) return !0; t = t._next
            }
            return !1
        },
        u.getChildren = function (t, e, s, r) {
            r = r || -9999999999; for (var n = [], a = this._first, o = 0; a;) r > a._startTime || (a instanceof i ? e !== !1 && (n[o++] = a) : (s !== !1 && (n[o++] = a),
            t !== !1 && (n = n.concat(a.getChildren(!0, e, s)),
            o = n.length))),
            a = a._next; return n
        },
        u.getTweensOf = function (t, e) {
            for (var s = i.getTweensOf(t),
            r = s.length, n = [], a = 0; --r > -1;) (s[r].timeline === this || e && this._contains(s[r])) && (n[a++] = s[r]);
            return n
        },
        u._contains = function (t) {
            for (var e = t.timeline; e;) {
                if (e === this) return !0; e = e.timeline
            }
            return !1
        },
        u.shiftChildren = function (t, e, i) {
            i = i || 0; for (var s, r = this._first, n = this._labels; r;) r._startTime >= i && (r._startTime += t),
            r = r._next;
            if (e) for (s in n) n[s] >= i && (n[s] += t);
            return this._uncache(!0)
        },
        u._kill = function (t, e) {
            if (!t && !e) return this._enabled(!1, !1);
            for (var i = e ? this.getTweensOf(e) : this.getChildren(!0, !0, !1),
            s = i.length, r = !1; --s > -1;) i[s]._kill(t, e) && (r = !0);
            return r
        },
        u.clear = function (t) {
            var e = this.getChildren(!1, !0, !0),
            i = e.length; for (this._time = this._totalTime = 0; --i > -1;) e[i]._enabled(!1, !1);
            return t !== !1 && (this._labels = {}),
            this._uncache(!0)
        },
        u.invalidate = function () {
            for (var t = this._first; t;) t.invalidate(),
            t = t._next; return this
        },
        u._enabled = function (t, i) {
            if (t === this._gc) for (var s = this._first; s;) s._enabled(t, !0),
            s = s._next; return e.prototype._enabled.call(this, t, i)
        },
        u.duration = function (t) {
            return arguments.length ? (0 !== this.duration() && 0 !== t && this.timeScale(this._duration / t),
            this) : (this._dirty && this.totalDuration(),
            this._duration)
        },
        u.totalDuration = function (t) {
            if (!arguments.length) {
                if (this._dirty) {
                    for (var e, i, s = 0, r = this._last, n = 999999999999; r;) e = r._prev, r._dirty && r.totalDuration(),
                    r._startTime > n && this._sortChildren && !r._paused ? this.add(r, r._startTime - r._delay) : n = r._startTime, 0 > r._startTime && !r._paused && (s -= r._startTime, this._timeline.smoothChildTiming && (this._startTime += r._startTime / this._timeScale),
                    this.shiftChildren(-r._startTime, !1, -9999999999),
                    n = 0),
                    i = r._startTime + r._totalDuration / r._timeScale, i > s && (s = i),
                    r = e; this._duration = this._totalDuration = s, this._dirty = !1
                }
                return this._totalDuration
            }
            return 0 !== this.totalDuration() && 0 !== t && this.timeScale(this._totalDuration / t),
            this
        },
        u.usesFrames = function () { for (var e = this._timeline; e._timeline;) e = e._timeline; return e === t._rootFramesTimeline },
        u.rawTime = function () { return this._paused ? this._totalTime : (this._timeline.rawTime() - this._startTime) * this._timeScale },
        s
    },
    !0)
}),
window._gsDefine && window._gsQueue.pop()();
