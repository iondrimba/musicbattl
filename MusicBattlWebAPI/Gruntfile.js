module.exports = function (grunt) {
    var globalConfig = {
        utilidadesSrc: 'utilidades',        
        viewModelsSrc: 'viewModels',
        modelsSrc: 'models',
        viewsSrc: 'views',
        vendorsSrc: 'vendors',        
        pluginsSrc: 'plugins',        
        routersSrc: 'routers'
    };

    var paths = {
        jquery: 'empty:',
        backbone: 'empty:',
        underscore: 'empty:',

        cookie: '<%= globalConfig.pluginsSrc %>/dough',
        iframeTransport: '<%= globalConfig.vendorsSrc %>/jquery.iframe-transport',
        moment: '<%= globalConfig.vendorsSrc %>/moment',        
        views: '<%= globalConfig.viewsSrc %>',
        viewModels: "<%= globalConfig.viewModelsSrc %>",
        vendors: '<%= globalConfig.vendorsSrc %>',
        routers: "<%= globalConfig.routersSrc %>",
        text:'text',
        models: "<%= globalConfig.modelsSrc %>",        
    };

    var uglifyfiles = {
        'scripts/build/bundle.js': ['scripts/build/bundle.js'],        
        'scripts/build/require.js': ['scripts/vendors/require.js']
    };

    grunt.initConfig({
        globalConfig: globalConfig,
        paths: paths,        
        sass: {
            options: {
                style: 'expanded',
                sourcemap: 'none'
            },
            dist: {
                files: {
                    'Content/build/site.css': 'Content/site.scss',
                    'Content/build/mobile.css': 'Content/mobile.scss'
                }
            }
        },
        concat: {
            options: {
                separator: ';',
            },
            dist: {
                src: [
                    'Scripts/vendors/jquery-1.9.1.js',
                    'Scripts/vendors/browserDetection.js',                                        
                    'Scripts/vendors/Chart.js',
                    'Scripts/vendors/handlebars.js',
                    'Scripts/vendors/sha1.js',
                    'Scripts/vendors/codebird.js',                                        
                    'Scripts/vendors/toastr.js',
                    'Scripts/vendors/sdk.js',                               
                    'Scripts/vendors/moment.js',

                    'node_modules/underscore/underscore.js',
                    'node_modules/backbone/backbone.js',
                    
                    'Scripts/gsap/plugins/CSSPlugin.js',
                    'Scripts/gsap/easing/EasePack.js',
                    'Scripts/gsap/TweenLite.js',
                    'Scripts/gsap/jquery.gsap.js',

                    'Scripts/plugins/jquery.validate.js',
                    'Scripts/plugins/validationHelper.js',
                    'Scripts/plugins/jquery.ui.widget.js',
                    'Scripts/plugins/jquery.fileupload.js',
                    'Scripts/plugins/jquery.mask.js',                                                            
                    'Scripts/plugins/dough.js',                                            
                    'Scripts/jquery.signalR-2.2.0.js'
                ],
                dest: 'Scripts/build/bundle.js',
            }
        },
        watch: {
            css: {
                files: '**/*.css',
                tasks: ['cssmin']
            },
            scss: {
                files: '**/*.scss',
                tasks: ['sass']
            },
            scripts: {
                files: ['Scripts/*.js', 'Scripts/**/*.js'],
                tasks: ['requirejs:dev'],
                options: {
                    livereload: false
                }
            },
            options: {
                livereload: false,
                reload: false,
                nospawn: true
            }
        },
        cssmin: {
            options: {
                shorthandCompacting: false,
                roundingPrecision: -1,
                sourceMap:false
            },
            target: {
                files: {
                    'Content/build/site.css': ['Content/build/site.css'],
                    'Content/build/mobile.css': ['Content/build/mobile.css']
                }
            }
        },
        uglify: {
            prod: {
                options: {
                    sourceMap: false,
                    beautify: false,
                    compress: {
                        drop_console: true
                    }
                },
                files: uglifyfiles
            },
            dev: {
                options: {
                    sourceMap: false,
                    beautify: true,
                    compress: {
                        drop_console: false
                    }
                },
                files: uglifyfiles
            }
        },
        requirejs: {
            prod: {
                options: {
                    name: "main",
                    out: "Scripts/build/main.js",
                    baseUrl: 'Scripts/',
                    optimizeAllPluginResources: false,
                    noGlobal: true,
                    optimize: "uglify",
                    mainConfigFile: 'Scripts/main.js',
                    allowSourceOverwrites: false,
                    paths: paths
                }
            },
            dev: {
                options: {
                    name: "main",
                    out: "Scripts/build/main.js",
                    baseUrl: 'Scripts/',
                    optimizeAllPluginResources: false,
                    noGlobal: true,
                    optimize: "none",
                    mainConfigFile: 'Scripts/main.js',
                    allowSourceOverwrites: false,
                    paths: paths
                }
            }
        },
        minifyHtml: {
            options: {
                cdata: true
            },
            dist: {
                files: {
                    'scripts/build/templates/home.html': 'scripts/templates/home.html'
                }
            }
        }
        //uncss: {
        //    dist: {
        //        files: {
        //            'Content/build/home.css': ['home.html']
        //        }
        //    }
        //}
            
    });

    grunt.loadNpmTasks('grunt-contrib-watch');

    grunt.loadNpmTasks('grunt-contrib-sass');

    grunt.loadNpmTasks('grunt-contrib-cssmin');

    grunt.loadNpmTasks('grunt-contrib-concat');

    grunt.loadNpmTasks('grunt-contrib-uglify');

    grunt.loadNpmTasks('grunt-contrib-requirejs');
    
    //grunt.loadNpmTasks('grunt-uncss');

    grunt.registerTask('default', ['dev']);

    grunt.registerTask('prod', function () {        
        grunt.task.run(['sass', 'cssmin', 'concat', 'uglify:prod',  'requirejs:prod']);
    });

    grunt.registerTask('dev', function () {        
        grunt.task.run(['sass', 'concat', 'uglify:dev', 'requirejs:dev']);
    });
};
