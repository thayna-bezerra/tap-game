const express = require('express');
const apicontroller = require('../Controller/controllers/apicontroller');
const router = express.Router();

/*router.get('/ping', (req, res) => {
    res.json({pong: true})
})*/

router.get('/ping', apicontroller.ping);
router.post('/signup', apicontroller.signup);
router.post('/signin', apicontroller.signin);
//router.get('/info/:nick', apicontroller.info);
router.get('/user/:nick', apicontroller.info);
router.put('/update/:id', apicontroller.update);
router.put('/user/:nick/score/:score', apicontroller.score);
router.get('/ranking/:qtd', apicontroller.ranking);
router.get('/highscore', apicontroller.highscore);

module.exports = router;