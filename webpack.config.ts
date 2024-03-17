import * as webpack from "webpack";
const CopyWebpackOutputPlugin = require("copy-webpack-output-plugin")

let config: webpack.Configuration = {
    mode: "development",
    entry: {
        m42_module: './Module/module.ts'
    },  
    module: {
        rules: [
            {
                test: /\.ts$/,
                loader: "ts-loader"
            },
            {
                test: /\.css$/i,
                use: ['style-loader', 'css-loader'],
            },
            {
                test: /\.(png|svg|jpg|jpeg|gif)$/i,
                type: 'asset/resource',
            },
            {
                test: /\.(woff|woff2|eot|ttf|otf)$/i,
                type: 'asset/resource',
            }
        ],
    },
    resolve: {
        extensions: ['.ts', '.js']
    },
    externals: {
        "lodash": '_',
        "jquery": '$',
        "angular": "angular",
        "angular-material": "angular",
        "@labtagon/matrix42-workspace-management-types": "mx"
    },
    output: {
        filename: 'module.js',
        path: __dirname + '/dist',
    },
    plugins: []
};

config.devtool = 'inline-source-map';

if (process.env.USERNAME == 'sven.mawby') {
    config.plugins.push( 
        new CopyWebpackOutputPlugin([{
            src: "dist\\module.js",
            dest: "Y:\\CentralAdministration\\module.js"
        }])
    );
}


export default config;