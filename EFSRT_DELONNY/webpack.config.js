const path = require('path');

module.exports = {
    entry: './Scripts/App.jsx', // ← tu archivo de entrada React
    output: {
        path: path.resolve(__dirname, 'Scripts'), // ← misma carpeta para salida
        filename: 'bundle.js' // ← el archivo que buscamos
    },
    module: {
        rules: [
            {
                test: /\.(js|jsx)$/,
                exclude: /node_modules/,
                use: 'babel-loader'
            }
        ]
    },
    resolve: {
        extensions: ['.js', '.jsx']
    },
    mode: 'development'
};
