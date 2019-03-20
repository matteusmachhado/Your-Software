const path = require('path');
const webpack = require('webpack');
const UglifyJsPlugin = require('uglifyjs-webpack-plugin');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const optimizeCSSAssetsPlugin = require('optimize-css-assets-webpack-plugin');
var ImageminPlugin = require('imagemin-webpack-plugin').default;


// Analise grafica do tamhanho do bundle
// const BundleAnalyzerPlugin = require('webpack-bundle-analyzer').BundleAnalyzerPlugin;

let plugins = [];  

let isModeDev = process.env.NODE_ENV !== 'production';

plugins.push(
    new MiniCssExtractPlugin({
        filename: isModeDev ? "style.css" : 'style.min.css'
    })
);

// >_ Definindo escopo global no webpack...
plugins.push(
    new webpack.ProvidePlugin({
        $: 'jquery/dist/jquery.js',
        jQuery: 'jquery/dist/jquery.js'
    })
);

// >_ Analisando graficamente bundle 
// plugins.push(
   // new BundleAnalyzerPlugin()
// );

if (!isModeDev)
{
    plugins.push(
        new optimizeCSSAssetsPlugin({
            cssProcessor: require('cssnano'),
            cssProcessorOptions: {
                discardComments: {
                    removeAll: true
                }
            },
        canPrint: true
        })
    );
    // >_ optimizando imagens (png|svg|jpg|gif)
    plugins.push(
        new ImageminPlugin()
    );
}

module.exports = {
    // >_ Ambiente: development (build-deafult) | production
    mode: isModeDev ? 'development' : 'production',
    target: 'web',
    entry: {
        main: './Scripts/src/app.tsx'
    },
    output: {
        path: path.resolve(__dirname, './wwwroot/dist'),
        filename: isModeDev ? 'bundle.js' : 'bundle.min.js',
        publicPath: 'dist/'
    },
    resolve: {
        extensions: ['.ts', '.tsx', '.jsx', '.js']
    },
    optimization: {
        minimizer: [
            new UglifyJsPlugin({
                uglifyOptions: {
                    output: {
                        comments: false,
                    },
                },
            }),
        ],
        namedChunks: true, // >_ persistir nome dos bunbles
        splitChunks: {
            cacheGroups: {
                commons: {
                    test: /[\\/]node_modules[\\/]/,
                    name: "vendor",
                    chunks: "initial",
                }
                // >_ Extrair para somente um bunble do jquery, por exemplo.
                //jquery: {
                //    test: new RegExp('node_modules' + '\\' + path.sep + 'jquery.*'),
                //    chunks: "initial",
                //    name: "jquery",
                //    enforce: true
                //},
            },
        }
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
            },
            {
                test: /\.(png|svg|jpg|gif)$/,
                loader: 'file-loader'
            }
        ]
    },
    plugins: plugins,

    stats: {
        children: false
    }

};