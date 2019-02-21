const path = require('path');

module.exports = {
  entry: path.resolve(__dirname, 'wwwroot/src/ts/app.ts'),
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
    filename: 'bundle.js',
    path: path.resolve(__dirname, 'wwwroot/dist')
  }
};	