import express from "express";
import { PORT, mongoURL } from "./config.js";
import mongoose from "mongoose";
import menuRoute from "./routes/menuRoute.js";
import usersRoute from "./routes/usersRoute.js";
import orderRoute from "./routes/ordersRoute.js";
import cors from "cors";

const app = express();

// middleware for parsing JSON
app.use(express.json());

// middleware for handling CORS
app.use(cors());

app.get("/", (req, res) => {
  res.send("Hello World!");
})

app.use("/menu", menuRoute);
app.use("/users", usersRoute);
app.use("/orders", orderRoute);


mongoose.connect(mongoURL).then(() => {
  console.log("Connected to MongoDB");
  app.listen(PORT, () => {
    console.log(`Server running on port ${PORT}`);
  })
}).catch((error) => {
  console.error("Error connecting to MongoDB:", error);
});
