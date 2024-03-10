const User = require('../models/User');

module.exports = {
    ping: async(req, res) => {
        res.json({pong: true});
    },
    signup: async(req, res) => {
        let {
            avatar,
            name,
            nick,
            email,
            passwordHash,
            score,
            hanking,
            timeGame
        } = req.body;

        const userExist = await User.find({ email });
        if (userExist) {
            res.json({
                data: [],
                error: 'Invalid User'
            })
            return;
        }
    }
}