import express from "express";
import { Pizza } from "../models/pizzaModel.js";

const router = express.Router();

// route for add a new pizza
router.post("/", async (req, res) => {
  const { name, unitPrice, imageUrl, ingredients } = req.body;
  try {
    if (!name || !unitPrice || !imageUrl || !ingredients) {
      return res.status(400).send("Please provide all the fields");
    }

    const pizza = {
      name,
      unitPrice,
      imageUrl,
      ingredients
    }

    const result = await Pizza.create(pizza);

    return res.status(201).send(result);

  } catch (error) {
    console.error(error);
    res.status(500).send("Internal server error");
  }
})

// route for get all pizzas from the database
router.get("/", async (req, res) => {
  try {
    const result = await Pizza.find();
    return res.status(200).send(result);
  } catch (error) {
    console.error(error);
    res.status(500).send("Internal server error");
  }
})

export default router