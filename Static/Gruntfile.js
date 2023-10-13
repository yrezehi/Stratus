module.exports = function (grunt) {
    grunt.initConfig({
        jshint: {
            files: ['wwwroot/js/*.js'],
            options: {
                '-W069': false,
            }
        },
        uglify: {
            all: {
                src: ['wwwroot/js/*.js'],
                dest: 'wwwroot/lib/minified.min.js'
            }
        },
    });

    grunt.loadNpmTasks('grunt-contrib-jshint');
    grunt.loadNpmTasks('grunt-contrib-uglify');

    grunt.registerTask("all", ['jshint', 'uglify']);
};