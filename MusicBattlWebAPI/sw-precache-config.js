module.exports = {
    staticFileGlobs: [
      'Content/build/*.css',
      'Content/fonts/**',
      'templates/**/*.html',
      'Scripts/build/*.js',
      'img/*.{jpg,png}'
    ],
    cacheName:'',
    stripPrefix: '/',
    runtimeCaching: [{
        urlPattern: /\#\/site\/battl-info/,
        handler: 'networkFirst'
    }]
};