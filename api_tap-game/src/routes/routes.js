const express = require('express');
const apicontroller = require('../Controller/controllers/apicontroller');
const router = express.Router();

/*router.get('/ping', (req, res) => {
    res.json({pong: true})
})*/

router.get('/ping', apicontroller.ping)

module.exports = router;