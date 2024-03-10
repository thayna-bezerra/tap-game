require('dotenv').config() //import and configurate library
const express = require('express'); //import the framework express
const ApiRoute = require('./src/routes/routes')
const server = express(); //initialize express
const mongodb = require('./src/database/mongodb')

mongodb();

server.use(express.json());

server.use(express.urlencoded({extended:true}))

//function for read route
server.use("/", ApiRoute);

//server listening requisitions
server.listen(process.env.PORT, () => {
    console.log("Server running in port address: " + process.env.BASE);
});