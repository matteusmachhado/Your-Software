const path = require('path');

module.exports = {
  entry: './3-SRC/4-Apps/YS.CMS.Apps.WebApp/wwwroot/ts/app.ts',
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
    path: path.resolve(__dirname, '3-SRC/4-Apps/YS.CMS.Apps.WebApp/wwwroot/dist')
  }
};	