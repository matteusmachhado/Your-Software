const path = require('path');
const UglifyJsPlugin = require('uglifyjs-webpack-plugin');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const optimizeCSSAssetsPlugin = require('optimize-css-assets-webpack-plugin');

let plugins = [];  

plugins.push(new MiniCssExtractPlugin({
    filename: "style.css" 
}));

// >_ Ambiente: development (build-deafult) | production
let modeEnvironment = 'development';

if (process.env.NODE_ENV == 'production')
{
    modeEnvironment = 'production';

    plugins.push(new optimizeCSSAssetsPlugin({
        cssProcessor: require('cssnano'),
        cssProcessorOptions: {
            discardComments: {
                removeAll: false
            }
        },
        canPrint: true
    }));   
}

module.exports = {
    mode: modeEnvironment,
    target: 'web',
    entry: { main: './Scripts/src/app.tsx' },
    output: {
        path: path.resolve(__dirname, './wwwroot/dist'),
        filename: 'bundle.js',
        publicPath: 'dist/'
    },
    resolve: {
        extensions: ['.ts', '.tsx', '.jsx', '.js']
    },
    optimization: {
        minimizer: [
            new UglifyJsPlugin({
                test: /\.js(\?.*)?$/i,
                uglifyOptions: {
                    output: {
                        comments: false,
                    },
                },
            }),
        ],
    },
    module: {
        rules: [
            {
                test: /\.(ts|tsx)$/,
                loader: 'ts-loader',
                exclude: /node_modules/,
                options: { configFile: 'tsconfig.json' }
            },
            {
                test: /\.(js|jsx)$/,
                exclude: /node_modules/,
                use: {
                    loader: 'babel-loader',
                    options: {
                        "presets": ["@babel/preset-env", "@babel/preset-react"]
                    }
                }
            },
            {
                test: /\.css$/,
                use: [
                    'css-hot-loader',
                     MiniCssExtractPlugin.loader,
                    'css-loader'
                ]
            }
        ]
    },
    plugins: plugins

};