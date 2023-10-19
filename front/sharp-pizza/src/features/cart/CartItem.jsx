/* eslint-disable react/prop-types */

import { useDispatch } from "react-redux"
import { deleteProduct } from "./cartSlice"
import UpdateItems from "./UpdateItems"


const CartItem = ({ product }) => {
  const dispatch = useDispatch()


  return (
    <div className="flex justify-around ml-4 gap-12 items-center max-w-sm">
      <h2>{product.quantity} x {product.name}</h2> <span>${product.unitPrice * product.quantity}</span>
      <UpdateItems id={product.id} quantity={product.quantity} />

      <button className="btn btn-warning w-20 btn-sm" onClick={() => dispatch(deleteProduct(product.id))}>Quitar</button>


    </div>
  )
}

export default CartItem