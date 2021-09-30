const path = require('path');
const HtmlWebpackPlugin = require('html-webpack-plugin')

module.exports = {
    entry: path.join(__dirname, "src", "index.js"),
    output: {
        path: path.resolve(__dirname, 'dist'),
        filename: 'index.bundle.js',
        publicPath: '/'
    },
    mode: 'development',
    devServer: {
        port: 3000,
        historyApiFallback: true
    },
    module: {
        rules: [
            {
                include: [
                    path.resolve(__dirname, "src"),
                    path.resolve(__dirname, "src/components")],
                test: /\.m?js$/,
                exclude: /node_modules/,
                use: {
                    loader: "babel-loader",
                    options: {
                        presets: ["@babel/preset-react"]
                    }
                }
            },
            {
                test: /\.(sass|css|scss)$/,
                use: [
                    'style-loader',
                    'css-loader',
                    {
                        loader: "postcss-loader",
                        options: {
                            plugins: () => [
                                require("autoprefixer")()
                            ],
                        },
                    },
                    'sass-loader',
                ]
            },

        ]
    },
    plugins: [
        new HtmlWebpackPlugin({
            template: path.join(__dirname, "public", "index.html"),
        }),
    ],
}