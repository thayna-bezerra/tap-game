const User = require('../models/User');
const bcrypt = require('bcrypt');

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
            password,
            score,
            hanking,
            timeGame
        } = req.body;

        const userExist = await User.findOne({ email });
        if (userExist) {
            res.json({
                data: [],
                error: 'Invalid User'
            })
            return;
        }

        const passwordHash = await bcrypt.hash(password, 10);
        const newUser = new User({
            avatar,
            name,
            nick,
            email,
            password,
            score,
            hanking,
            timeGame
        });

        const userSave = await newUser.save();
        if(userSave) {
            res.json({
                data: userSave,
                msg: 'User successfull save',
                error: ''
            });
            return;
        } else {
            res.json({
                data: [],
                error: 'Error save user'
            });
            return;
        }
    },
    
    signin: async(req, res) => {
        let {
            email,
            password
        } = req.body;
        const userExist = await User.findOne({email});
        if(!userExist) {
            res.json ({
                data: [],
                error: 'User Invalid'
            })
            return;
        }
        const match = await bcrypt.compare(password, userExist.passwordHash);
        if(!match) {
            res.json({
                data:[],
                error: 'Invalid credentials'
            });
            return;
        }
        res.json({
            data: userExist,
            msg: 'Login successful',
            error: ''
        })
    }
}