import { createSlice } from "@reduxjs/toolkit"

const initialState = {
  products: [],
}

const cartSlice = createSlice({
  name: 'cart',
  initialState,
  reducers: {
    addProduct: (state, action) => {
      state.products.push(action.payload)
    },
    deleteProduct: (state, action) => {
      state.products = state.products.filter(product => product.id !== action.payload)
    },
    increaseQuantity: (state, action) => {
      const product = state.products.find(product => product.id === action.payload)
      product.quantity++
    },
    decreaseQuantity: (state, action) => {
      const product = state.products.find(product => product.id === action.payload)
      product.quantity--
    },
    clearCart: (state) => {
      state.products = []
    }
  }
})

export const { addProduct, deleteProduct, increaseQuantity, decreaseQuantity, clearCart } = cartSlice.actions
export default cartSlice.reducer

export const getTotalQuantity = (state) => {
  return state.cart.products.reduce((acc, product) => acc + product.quantity, 0)
}

export const getTotalPrice = (state) => {
  return state.cart.products.reduce((acc, product) => acc + product.totalPrice, 0)
}