const path = require('path');
const webpack = require('webpack');
const UglifyJsPlugin = require('uglifyjs-webpack-plugin');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const optimizeCSSAssetsPlugin = require('optimize-css-assets-webpack-plugin');
const ImageminPlugin = require('imagemin-webpack-plugin').default;
const CleanWebpackPlugin = require('clean-webpack-plugin');
// const BundleAnalyzerPlugin = require('webpack-bundle-analyzer').BundleAnalyzerPlugin; // >_ Analise grafica do tamhanho do bundle...

let plugins = [];  

let isModeDev = process.env.NODE_ENV !== 'production'; // >_ '!==' retorna true caso os valores NÃO sejam iguais ou NÃO tenham o mesmo tipo.

plugins.push(
    new MiniCssExtractPlugin({ // >_ Extraindo css do default e salvando...
        filename: isModeDev ? "css/style.css" : 'css/style.min.css'
    }),
    new webpack.ProvidePlugin({ // > _ Definindo escopo global no webpack...
        $: 'jquery/dist/jquery.js',
        jQuery: 'jquery/dist/jquery.js'
    }),
    new CleanWebpackPlugin(), // >_ Limpar builds anteriores...
    // new BundleAnalyzerPlugin() //>_ Analisando graficamente bundle...
);


if (!isModeDev) // >_ Plugins ativos somente em build de produção...
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
    plugins.push(
        new ImageminPlugin() // >_ optimizando imagens (png|svg|jpg|gif)
    );
}

module.exports = {
    // >_ Ambiente: development (build-deafult) | production
    mode: isModeDev ? 'development' : 'production',
    target: 'web',
    entry: {
        App: './Scripts/SRC/app.tsx'
    },
    output: {
        path: path.resolve(__dirname, './wwwroot/dist'),
        filename: isModeDev ? 'js/bundle.js' : 'js/bundle.min.js',
        publicPath: 'dist/'
    },
    resolve: {
        extensions: ['.ts', '.tsx', '.jsx', '.js'] // > _ Extenções tratadas pelo Webpack...
    },
    optimization: {
        minimizer: [
            new UglifyJsPlugin({
                uglifyOptions: {
                    output: {
                        comments: false
                    }
                }
            })
        ],
        namedChunks: true, // >_ persistir nome dos bunbles...
        splitChunks: {
            cacheGroups: {
                commons: {
                    test: /[\\/]node_modules[\\/]/,
                    name: "vendor",
                    chunks: "initial"
                }
                // >_ Extrair para somente um bunble do jquery, por exemplo...
                //jquery: {
                //    test: new RegExp('node_modules' + '\\' + path.sep + 'jquery.*'),
                //    chunks: "initial",
                //    name: "jquery",
                //    enforce: true
                //},
            }
        }
    },
    module: {
        rules: [
            {
                test: /\.(ts|tsx)$/,
                loader: 'ts-loader',
                include: path.resolve(__dirname, './Scripts/src'),
                options: { configFile: 'tsconfig.json' }
            },
            {
                test: /\.(js|jsx)$/,
                include: path.resolve(__dirname, './Scripts/dist'),
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
                use: [
                    {
                        loader: 'file-loader',
                        options: {
                            outputPath: 'images'
                        }
                    }
                ]
            }
        ]
    },
    plugins: plugins,

    stats: {
        children: false // >_ logs das taks runnres
    }

};