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
                dest: 'wwwroot/lib/Destination/minified.min.js'
            }
        },
        watch: {
            files: ["wwwroot/js/*.js"],
            tasks: ["all"]
        }
    });

    grunt.loadNpmTasks('grunt-contrib-jshint');
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-watch');

    grunt.registerTask("all", ['jshint', 'uglify']);
};