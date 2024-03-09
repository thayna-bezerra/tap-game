const express = require('express');

const server = express();

server.use("/ping", (req, res) => {{
    res.send("pong");
}});

server.listen(3001, () => {
    console.log("Server running in port 3001");
});