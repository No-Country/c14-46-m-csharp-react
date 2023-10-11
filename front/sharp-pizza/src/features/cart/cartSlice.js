import { createSlice } from "@reduxjs/toolkit"

const initialState = {
  products: [],
  total: 0
}

const cartSlice = createSlice({
  name: 'cart',
  initialState,
  reducers: {
    addProduct: (state, action) => {
      state.products.push(action.payload)
      state.total += action.payload.unitPrice
    }
  }
})

export const { addProduct } = cartSlice.actions
export default cartSlice.reducer