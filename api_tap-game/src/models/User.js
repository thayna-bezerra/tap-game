const mongoose = require('mongoose');
const modelSchema = new mongoose.Schema({
    avatar: String,
    name: String,
    nick: String,
    email: String,
    passwordHash: String,
    score: Number,
    ranking: Number,
    timeGame: String
});

const modelName = 'Users';

if(mongoose.connection && mongoose.connection.models[modelName]) {
    module.exports = mongoose.connection.models[modelName];
} else {
    module.exports = mongoose.model(modelName, modelSchema)
}
