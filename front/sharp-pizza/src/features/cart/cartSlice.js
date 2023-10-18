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

      if (product.quantity === 0) cartSlice.caseReducers.deleteProduct(state, action)
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
  return state.cart.products.reduce((acc, product) => acc + product.unitPrice * product.quantity, 0)
}

export const getCurrentQuantityById = (id) => (state) =>
  state.cart.products.find((product) => product.id === id)?.quantity ?? 0;

export const getProducts = (state) => state.cart.products
