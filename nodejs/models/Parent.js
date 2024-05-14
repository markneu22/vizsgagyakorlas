const mongoose = require('mongoose')

const parentSchema = new mongoose.Schema({
	name: {
		type: String,
		required: [true, 'You have to add a name!'],
		unique: true,
		trim: true,
		lowercase: true,
		maxlength: [50, 'The name cannot be longer than 30 characters!']
	},
	numberDefault: {
		type: Number,
		default: 0
	},
	default: {
		type: String,
		default: "something"
	},
	child: {
		type: Number,
		ref: 'Child'
	}
})

module.exports = mongoose.model('Parent', parentSchema, 'parents')