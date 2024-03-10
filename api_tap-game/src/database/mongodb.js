const mongoose = require('mongoose')
require('dotenv').config();

const connectdb = async () => {
    try {
        console.log("Connecting MongoDB...");
        await mongoose.connect(process.env.MONGOURL);
        console.log("MongoDB connected successfull");
    } catch(error) {
        console.log("Error connection MongoDB: " + error);
    }
}

module.exports = connectdb;