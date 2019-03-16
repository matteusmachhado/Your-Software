const path = require('path');

let plugins = [];

// >_ Ambiente: development | production |
let modeEnvironment = 'development';

if (process.env.NODE_ENV == 'production')
{
    modeEnvironment = 'production';
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
    module: {
        rules: [
            {
                test: /\.(ts|tsx)$/,
                loader: 'ts-loader',
                exclude: /node_modules/,
                options: { configFile: 'tsconfig.json' }
            },
            {
                test: /\.(js|jsx)/,
                exclude: /node_modules/,
                use: {
                    loader: 'babel-loader',
                    options: {
                        "presets": ["@babel/preset-env", "@babel/preset-react"]
                    }
                }
            }
        ]
    },
    plugins: plugins

};