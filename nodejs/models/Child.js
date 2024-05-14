const mongoose = require('mongoose')

const childSchema = new mongoose.Schema({
  _id: {
    type: Number,
    required: true
  },
  name: {
    type: String,
    required: true,
    unique: true,
    maxlength: [30, 'Name cannot be longer than 30 characters!'],
  },
})

module.exports = mongoose.model('Child', childSchema, 'children')
