const express = require('express');
const apicontroller = require('../Controller/controllers/apicontroller');
const router = express.Router();

/*router.get('/ping', (req, res) => {
    res.json({pong: true})
})*/

router.get('/ping', apicontroller.ping);
router.post('/signup', apicontroller.signup)

module.exports = router;