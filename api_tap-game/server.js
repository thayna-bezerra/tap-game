require('dotenv').config() //import and configurate library
const express = require('express'); //import the framework express

const server = express(); //initialize express

//function for read route
server.use("/ping", (req, res) => {{
    res.send("pong");
}});

//server listening requisitions
server.listen(process.env.PORT, () => {
    console.log("Server running in port address: " + process.env.BASE);
});