import mongoose from "mongoose";

// the schema has to have a customer, phone, address, date, an array of products, paymentMethod and orderPrice
const orderSchema = new mongoose.Schema({
  customer: {
    type: String,
    required: true
  },
  phone: {
    type: String,
    required: true
  },
  address: {
    type: String,
    required: true
  },
  date: {
    type: Date,
    required: true
  },
  products: {
    type: Array,
    required: true
  },
  paymentMethod: {
    type: String,
    required: true
  },
  orderPrice: {
    type: Number,
    required: true
  }
})

export const Order = mongoose.model("Order", orderSchema);