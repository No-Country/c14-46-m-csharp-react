import express from "express";
import { User } from "../models/userModel.js";

const router = express.Router();

// route for add a new user
router.post("/", async (req, res) => {
  const { name, password, phone, email, address } = req.body;
  try {
    if (!name || !password || !phone || !email || !address) {
      return res.status(400).send("Please provide all the fields");
    }

    const user = {
      name,
      password,
      phone,
      email,
      address
    }

    const result = await User.create(user);

    return res.status(201).send(result);

  } catch (error) {
    console.error(error);
    res.status(500).send("Internal server error");
  }
})

// route for get all users from the database
router.get("/", async (req, res) => {
  try {
    const result = await User.find();
    return res.status(200).send(result);
  } catch (error) {
    console.error(error);
    res.status(500).send("Internal server error");
  }
})

export default router