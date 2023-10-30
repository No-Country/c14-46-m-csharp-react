import mongoose from "mongoose";

// the schema has to have a name, unitPrice, imageUrl and an array of ingredients
const pizzaSchema = new mongoose.Schema({
  name: {
    type: String,
    required: true
  },
  unitPrice: {
    type: Number,
    required: true
  },
  imageUrl: {
    type: String,
    required: true
  },
  ingredients: {
    type: Array,
    required: true
  }
})

export const Pizza = mongoose.model("Pizza", pizzaSchema);
