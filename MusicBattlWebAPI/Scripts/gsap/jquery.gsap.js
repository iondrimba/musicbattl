/*!
 * VERSION: 0.1.6
 * DATE: 2013-02-13
 * UPDATES AND DOCS AT: http://www.greensock.com/jquery-gsap-plugin/
 *
 * Requires TweenLite version 1.8.0 or higher and CSSPlugin.
 *
 * @license Copyright (c) 2014, GreenSock. All rights reserved.
 * This work is subject to the terms at http://www.greensock.com/terms_of_use.html or for
 * Club GreenSock members, the software agreement that was issued with your membership.
 *
 * @author: Jack Doyle, jack@greensock.com
 */
(function (t) {
    "use strict";
    var e, i, s, r = t.fn.animate,
        n = t.fn.stop,
        a = !0,
        o = function (t, e) {
            "function" == typeof t && this.each(t), e()
        }, h = function (t, e, i, s, r) {
            r = "function" == typeof r ? r : null, e = "function" == typeof e ? e : null, (e || r) && (s[t] = r ? o : i.each, s[t + "Scope"] = i, s[t + "Params"] = r ? [e, r] : [e])
        }, l = {
            overwrite: 1,
            delay: 1,
            useFrames: 1,
            runBackwards: 1,
            easeParams: 1,
            yoyo: 1,
            immediateRender: 1,
            repeat: 1,
            repeatDelay: 1,
            autoCSS: 1
        }, _ = function (t, e) {
            for (var i in l) l[i] && void 0 !== t[i] && (e[i] = t[i])
        }, u = function (t) {
            return function (e) {
                return t.getRatio(e)
            }
        }, c = {}, f = function () {
            var r, n, a, o = window.GreenSockGlobals || window;
            if (e = o.TweenMax || o.TweenLite, e && (r = (e.version + ".0.0").split("."), n = !(Number(r[0]) > 0 && Number(r[1]) > 7), o = o.com.greensock, i = o.plugins.CSSPlugin, c = o.easing.Ease.map || {}), !e || !i || n) return e = null, !s && window.console && (window.console.log("The jquery.gsap.js plugin requires the TweenMax (or at least TweenLite and CSSPlugin) JavaScript file(s)." + (n ? " Version " + r.join(".") + " is too old." : "")), s = !0), void 0;
            if (t.easing) {
                for (a in c) t.easing[a] = u(c[a]);
                f = !1
            }
        };
    t.fn.animate = function (s, n, o, l) {
        if (s = s || {}, f && (f(), !e || !i)) return r.call(this, s, n, o, l);
        if (!a || s.skipGSAP === !0 || "object" == typeof n && "function" == typeof n.step || null != s.scrollTop || null != s.scrollLeft) return r.call(this, s, n, o, l);
        var u, p, m, d, g = t.speed(n, o, l),
            v = {
                ease: c[g.easing] || (g.easing === !1 ? c.linear : c.swing)
            }, T = this,
            y = "object" == typeof n ? n.specialEasing : null;
        for (p in s) {
            if (u = s[p], u instanceof Array && c[u[1]] && (y = y || {}, y[p] = u[1], u = u[0]), "toggle" === u || "hide" === u || "show" === u) return r.call(this, s, n, o, l);
            v[-1 === p.indexOf("-") ? p : t.camelCase(p)] = u
        }
        if (y) {
            d = [];
            for (p in y) u = d[d.length] = {}, _(v, u), u.ease = c[y[p]] || v.ease, -1 !== p.indexOf("-") && (p = t.camelCase(p)), u[p] = v[p];
            0 === d.length && (d = null)
        }
        return m = function (i) {
            if (d)
                for (var s = d.length; --s > -1;) e.to(T, t.fx.off ? 0 : g.duration / 1e3, d[s]);
            h("onComplete", g.old, T, v, i), e.to(T, t.fx.off ? 0 : g.duration / 1e3, v)
        }, g.queue !== !1 ? T.queue(g.queue, m) : m(), T
    }, t.fn.stop = function (t, i) {
        if (n.call(this, t, i), e) {
            if (i)
                for (var s, r = e.getTweensOf(this), a = r.length; --a > -1;) s = r[a].totalTime() / r[a].totalDuration(), s > 0 && 1 > s && r[a].seek(r[a].totalDuration());
            e.killTweensOf(this)
        }
        return this
    }, t.gsap = {
        enabled: function (t) {
            a = t
        },
        version: "0.1.6"
    }
})(jQuery);
