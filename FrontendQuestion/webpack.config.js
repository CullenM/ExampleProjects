var config = {
   entry: 'C:/Users/Cullen/Desktop/FrontendQuestion/main.js',

   output: {
      path: __dirname + "/dist/js", // or path: path.join(__dirname, "dist/js"),
      filename: "index.js",
   },

   devServer: {
      inline: true,
      port: 8080
   },

   module: {
      loaders: [
         {
            test: /\.jsx?$/,
            exclude: /node_modules/,
            loader: 'babel-loader',

            query: {
               cacheDirectory: true,
               presets: ['es2015', 'react']
            }
         }
      ]
   }
}

module.exports = config;
