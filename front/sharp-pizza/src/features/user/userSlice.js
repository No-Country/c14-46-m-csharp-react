import { createSlice } from "@reduxjs/toolkit"

const initialState = {
  username: "Nicolas",
}

const userSlice = createSlice({
  name: "user",
  initialState,
  reducers: {
    updateUser: (state, action) => {
      state.username = action.payload
    },
  },
})

export const { updateUser } = userSlice.actions

export default userSlice.reducer