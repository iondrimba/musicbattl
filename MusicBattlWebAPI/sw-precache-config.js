module.exports = {
    staticFileGlobs: [
      'Content/build/*.css',
      'Content/fonts/**',
      'templates/**/*.html',
      'Scripts/build/*.js',
      'img/*.{jpg,png}'
    ],
    cacheId: '',
    directoryIndex :'/',
    stripPrefix: '/',
    runtimeCaching: [{
        urlPattern: /api\/PastBattls\/.+/,
        handler: 'networkFirst'
    }]
};