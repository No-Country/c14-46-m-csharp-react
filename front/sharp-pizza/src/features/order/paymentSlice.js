import { createSlice } from "@reduxjs/toolkit"

const initialState = {
  number: '',
  expiry: '',
  cvc: '',
  name: '',
}

const paymentSlice = createSlice({
  name: 'payment',
  initialState,
  reducers: {
    updatePayment: (state, action) => {
      state.number = action.payload.number
      state.expiry = action.payload.expiry
      state.cvc = action.payload.cvc
      state.name = action.payload.name
    },
    clearPayment: (state) => {
      state.number = ''
      state.expiry = ''
      state.cvc = ''
      state.name = ''
    }
  }
})

export const { updatePayment, clearPayment } = paymentSlice.actions

export default paymentSlice.reducer