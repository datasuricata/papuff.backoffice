var gulp = require('gulp');
var concat = require('gulp-concat');
var cssmin = require('gulp-cssmin');
var uncss = require('gulp-uncss');
var browserSync = require('browser-sync').create;
//var ngAnnotate = require('gulp-ng-annotate');
//var jsuglify = require('gulp-uglify');

//var obfuscate = require('gulp-js-obfuscator');

gulp.task('browser-sync', function () {
    browserSync.init({
        proxy: 'localhost:5000'
    });

    gulp.watch('./assets/css/*.css', ['css']);
    gulp.watch('./assets/js/*.js', ['js']);
});

gulp.task('js', function () {
    return gulp.src([
        './node_modules/bootstrap/dist/js/bootstrap.min.js',
        './node_modules/jquery/dist/jquery.min.js',
        './node_modules/popper.js/dist/popper.min.js',
        './node_modules/tooltip.js/dist/tooltip.min.js',
        './node_modules/nicescroll/dist/jquery.nicescroll.min.js',
        './node_modules/moment/min/moment.min.js',
        './node_modules/sweetalert/dist/sweetalert.min.js',
        './node_modules/jquery-validation/dist/jquery.validate.min.js',
        './node_modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js',
        './node_modules/jquery-ajax-unobtrusive/dist/jquery.unobtrusive-ajax.min.js',
        './assets/js/stisla.js',
        './assets/js/scripts.js',
        './assets/js/custom.js',
    ])
        //    .pipe(ngAnnotate())
        //    .pipe(jsuglify())
        //      .pipe(jsuglify())
        .pipe(gulp.dest('wwwroot/js'));
    // .pipe(browserSync.stream());
});

gulp.task('build-assets-js', function () {
    return gulp.src('assets/*/.js')
        // .pipe(obfuscate())
        .pipe(gulp.dest('dist/assets'));
});

gulp.task('css', function () {
    return gulp.src([
        './assets/css/components.css',
        './assets/css/custom.css',
        './assets/css/reverse.css',
        './assets/css/style.css',
        './assets/css/rtl.css',
    ])
        .pipe(concat('site.min.css'))
        .pipe(cssmin())
        .pipe(uncss({ html: ['Views/**/*.cshtml'] }))
        .pipe(gulp.dest('wwwroot/css'));
    //.pipe(browserSync.stream());
});