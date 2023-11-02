import { configureStore } from "@reduxjs/toolkit";
import userSlice from "./features/user/userSlice";
import cartSlice from "./features/cart/cartSlice";
import paymentSlice from "./features/order/paymentSlice";

const store = configureStore({
  reducer: {
    user: userSlice,
    cart: cartSlice,
    payment: paymentSlice
  },
})

export default store