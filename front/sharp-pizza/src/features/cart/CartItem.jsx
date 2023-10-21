/* eslint-disable react/prop-types */

import { useDispatch } from "react-redux"
import { deleteProduct } from "./cartSlice"
import UpdateItems from "./UpdateItems"


const CartItem = ({ product }) => {
  const dispatch = useDispatch()


  return (
    <div className="grid grid-cols-4 gap-8 max-w-sm items-center text-slate-900">
      <h2>{product.quantity} x {product.name}</h2><p>${product.unitPrice * product.quantity}</p>
      <UpdateItems id={product.id} quantity={product.quantity} />

      <button className="btn btn-warning w-20 btn-xs" onClick={() => dispatch(deleteProduct(product.id))}>Quitar</button>


    </div>
  )
}

export default CartItem