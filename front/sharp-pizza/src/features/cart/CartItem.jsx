/* eslint-disable react/prop-types */

import { useDispatch } from "react-redux"
import { deleteProduct } from "./cartSlice"


const CartItem = ({ product }) => {
  const dispatch = useDispatch()


  return (
    <div className="flex justify-between ml-10 items-center max-w-sm">
      <h2>1 x {product.name}</h2> <span>${product.unitPrice}</span>

      <button className="btn btn-warning w-20" onClick={() => dispatch(deleteProduct(product.id))}>Quitar</button>


    </div>
  )
}

export default CartItem