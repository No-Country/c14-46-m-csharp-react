import { createSlice } from "@reduxjs/toolkit"

const initialState = {
  name: "",
  password: "",
  role: "",
  phone: "",
  email: "",
  address: "",
}

const userSlice = createSlice({
  name: "user",
  initialState,
  reducers: {
    updateUser: (state, action) => {
      state.name = action.payload.name
      state.password = action.payload.password
      state.role = action.payload.role
      state.phone = action.payload.phone
      state.email = action.payload.email
      state.address = action.payload.address
    },
    logout: (state) => {
      state.name = ""
      state.password = ""
      state.role = ""
      state.phone = ""
      state.email = ""
      state.address = ""
    }
  },
})

export const { updateUser, logout } = userSlice.actions

export default userSlice.reducer