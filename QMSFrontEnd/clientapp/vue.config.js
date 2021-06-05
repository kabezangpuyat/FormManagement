module.exports = {
    devServer: {
        port: 44359,
        https: true,
        proxy: {
            '/api': {
                target: 'https://localhost:5011',
                ws: true,
                changeOrigin: true,
                logLevel: 'debug',
            }
        }
    }
}