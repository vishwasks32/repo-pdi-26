const mongoose = require('mongoose');

const listingSchema = new mongoose.Schema({
    name:{
        type: String,
        required: true
    },
    location:{
        type: String,
        required: false
    },
    price:{
        type: Number,
        required: false
    }
});

module.exports = mongoose.model('Listing', listingSchema);