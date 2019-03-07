const path = require('path');

module.exports = {
    entry: { 'main': './wwwroot/src/ts/app.ts' },
  module: {
    rules: [
      {
        test: /\.tsx?$/,
        use: 'ts-loader',
        exclude: /node_modules/
      }
    ]
  },
  resolve: {
    extensions: [ '.tsx', '.ts', '.js' ]
  },
    output: {
    path: path.resolve(__dirname, 'wwwroot/dist'),
    filename: 'bundle.js',
    publicPath: 'dist/'
  }
};	