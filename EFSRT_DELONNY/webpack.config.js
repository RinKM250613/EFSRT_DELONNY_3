const path = require('path');

module.exports = {
    entry: './Scripts/App.jsx',
    output: {
        path: path.resolve(__dirname, 'Scripts'),
        filename: 'bundle.js'
    },
    module: {
        rules: [
            {
                test: /\.(js|jsx)$/,
                exclude: /node_modules/,
                use: 'babel-loader'
            },
            {
                test: /\.css$/i, // ← esto es lo nuevo
                use: ['style-loader', 'css-loader']
            }
        ]
    },
    resolve: {
        extensions: ['.js', '.jsx']
    },
    mode: 'development'
};
