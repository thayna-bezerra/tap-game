//const User = require('../models/User.js');
const User = require('../../models/User')
//const bcrypt = require('bcrypt');

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
            ranking,
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

        //const passwordHash = await bcrypt.hash(password, 10);
        const newUser = new User({
            avatar,
            name,
            nick,
            email,
            password,
            score,
            ranking,
            timeGame
        });

        const userSave = await newUser.save();
        if (userSave) {
            res.json({
                data: {
                    _id: userSave._id,
                    avatar: userSave.avatar,
                    name: userSave.name,
                    nick: userSave.nick,
                    email: userSave.email,
                    score: userSave.score,
                    ranking: userSave.ranking,
                    timeGame: userSave.timeGame
                },
                msg: 'User successfully saved',
                error: ''
            });
        } else {
            res.json({
                data: [],
                error: 'Error saving user'
            });
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
    },

    info: async(req, res) => {
        const nick = req.params.nick;
        const userInfo = await User.findOne({nick})
        .select({nick:1, avatar:1, ranking:1, score:1, _id:0})
        .exec();
        if(!userInfo){
            res.json({
                data: [],
                error: 'User not founded'
            });
            return;
        }
        res.json({
            data: userInfo,
            msg: 'User founded successful',
            error: ''
        });
    },

    update: async(req, res) => {
        let {
            avatar,
            name,
            nick,
            email,
        } = req.body;

        const id = req.params.id;

        const user = await User.findByIdAndUpdate(id, {
            avatar,
            name, 
            nick,
            email
        }).exec();

        if(!user) {
            res.json({
                data: [],
                error: 'Invalid user'
            });
            return;
        }

        res.json({
            data: [],
            msg: 'User alterated successful',
            error: ''
        })
    },

    score: async(req, res) => {
        const nick = req.params.nick;
        const newScore = req.params.score;
        const user = await User.findOne({nick}).exec();
        if(!user) {
            res.json({
                error: "Invalid user"
            });
            return;
        } 

        const id = user._id;
        const scoreAtual = user.score;
        if(newScore > scoreAtual) {
            const userUpdate = await User.findByIdAndUpdate(id, {score: newScore});
            if(!userUpdate) {
                res.json({error: "Error Update"});
            }

            const geraRanking = await User.aggregate([
                {
                    $setWindowFields: {
                        sortBy: {score: -1},
                        output: {
                            ranking: {
                                $rank: {}
                            },
                        },
                    },
                },
            ]).exec();
            geraRanking.map((user) => {
                User.updateOne({_id: user._id}, {ranking: user.ranking}).exec();
            });
            res.json({
                data: [],
                msg: "Score alterado com sucesso"
            })
        } else {
            res.json({
                data: [],
                msg: "Noob"
            });
            return;
        }
    },

    ranking: async(req, res) => {

    }
}