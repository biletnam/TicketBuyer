var webpack = require('webpack');
var ExtractTextPlugin = require('extract-text-webpack-plugin');
var path = require('path');

var src = path.join(__dirname, 'ClientApp/src');
var dest = path.join(__dirname, 'wwwroot');

module.exports = {
  entry: {
    'polyfills': path.join(src, 'polyfills.ts'),
    'vendor': path.join(src, 'vendor.ts'),
    'app': path.join(src, 'main.ts')
  },
  output: {
    path: dest,
    filename: 'js/[name].js'
  },
  resolve: {
    extensions: ['.ts', '.js']
  },
  module: {
    rules: [
      {
        test: /\.ts$/,
        use: ['awesome-typescript-loader', 'angular2-template-loader']
      },
      {
        test: /\.html$/,
        loader: 'html-loader'
      },
      {
        test: /\.(png|woff|woff2|eot|ttf|svg)$/,
        loader: 'url-loader'
      },
      {
        test: /\.(css|scss)$/,
        exclude: path.join(src, 'app/components'),
        loader: ExtractTextPlugin.extract({ fallback: 'style-loader', use: ['css-loader', 'sass-loader'] })
      },
      {
        test: /\.scss$/,
        include: path.join(src, 'app/components'),
        use: ['raw-loader', 'sass-loader']
      }
    ]
  },
  plugins: [
    new ExtractTextPlugin('css/[name].css'),

    new webpack.ProvidePlugin({
      $: "jquery",
      jquery: "jquery",
      jQuery: "jquery",
      "windows.jQuery": "jquery"
    }),
  ]
}
