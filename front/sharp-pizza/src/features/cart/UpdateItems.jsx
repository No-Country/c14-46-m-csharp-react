/* eslint-disable react/prop-types */
import { useDispatch } from "react-redux"
import { decreaseQuantity, increaseQuantity } from "./cartSlice"


const UpdateItems = ({ id, quantity }) => {
  const dispatch = useDispatch()
  return (
    <div className="flex justify-center items-center gap-2">
      <button className="btn btn-circle btn-outline btn-primary btn-sm" onClick={() => dispatch(decreaseQuantity(id))} >
        -
      </button>

      <span className="font-bold">{quantity}</span>

      <button className="btn btn-circle btn-outline btn-primary btn-sm" onClick={() => dispatch(increaseQuantity(id))}>
        +
      </button>
    </div>
  )
}

export default UpdateItems