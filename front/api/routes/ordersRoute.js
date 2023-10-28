import express from "express";
import { Order } from "../models/orderModel.js";

const router = express.Router();

// route for add a new order
router.post("/", async (req, res) => {
  const { customer, phone, address, date, products, paymentMethod, orderPrice } = req.body;
  try {
    if (!customer || !phone || !address || !date || !products || !paymentMethod || !orderPrice) {
      return res.status(400).send("Please provide all the fields");
    }

    const order = {
      customer,
      phone,
      address,
      date,
      products,
      paymentMethod,
      orderPrice
    }

    const result = await Order.create(order);

    return res.status(201).send(result);
  } catch (error) {
    console.error(error);
    res.status(500).send("Internal server error");
  }
})

// route for get an order by id
router.get("/:id", async (req, res) => {
  try {
    const result = await Order.findById(req.params.id);
    return res.status(200).send(result);
  } catch (error) {
    console.error(error);
    res.status(500).send("Internal server error");
  }
})

// route for get all orders from the database
router.get("/", async (req, res) => {
  try {
    const result = await Order.find();
    return res.status(200).send(result);
  } catch (error) {
    console.error(error);
    res.status(500).send("Internal server error");
  }
})

export default router;