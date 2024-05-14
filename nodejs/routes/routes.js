const express = require('express');
const Child = require('../models/Child');
const Parent = require('../models/Parent');

const router = express.Router()

//Post Method
router.post('/', async (req, res) => {
    const newParent = new Parent({
        name: req.body.name,
        numberDefault: req.body.numberDefault
    })

    try{
        const newParentSave = await newParent.save();
        res.status(201).json({"_id": newParent._id})
    }
    catch(error){
        res.status(400).json({message: error.message})
    }
})

//Get all Method
router.get('/getSomething', async (req, res) => {
    try{
        const data = await Parent.find();
        res.json(data)
    }
    catch(error){
        res.status(500).json({message: error.message})
    }
})

router.get('/getParents', async (req, res) => {
    try{
        const data = await Parent.find().populate('child', '-_id');
        res.json(data)
    }
    catch(error){
        res.status(500).json({message: error.message})
    }
})

//Get by ID Method
router.get('/:Id', async (req, res) => {
    try{
        const data = await Parent.find({"Parent": req.params.Id})
        .populate('location', '-_id')
        if (data.length !== 0) {
            res.json(data)
        } else {
            res.status(404).json({message: 'No parent found'})
        }
    }
    catch(error){
        res.status(500).json({message: error.message})
    }
})

//Update by ID Method
router.patch('/:id', async (req, res) => {
    try {
        const id = req.params.id;
        const updatedData = req.body;
        const options = { new: true, runValidators: true }; 
        // hogy a frissítés utáni dokumentumot kapjuk vissza
        const result = await Parent.findByIdAndUpdate(
            id, updatedData, options
        )
        if (result) {
            res.send(result)
        } else {
            res.status(400).json({ message: `${id} parent does not exist!`  })
        }
    }
    catch (error) {
        res.status(400).json({ message: error.message })
    }
})

//Delete by ID Method
router.delete('/delete/:id', async (req, res) => {
    try {
        const id = req.params.id;
        const data = await Parent.findByIdAndDelete(id)
        res.send(`A ${data.name} named parent does not exist`)
    }
    catch (error) {
        res.status(400).json({ message: error.message })
    }
})

module.exports = router;