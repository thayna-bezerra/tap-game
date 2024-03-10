const User = require('../models/User');

module.exports = {
    ping: async(req, res) => {
        res.json({pong: true});
    },
    signup: async(req, res) => {

    }
}