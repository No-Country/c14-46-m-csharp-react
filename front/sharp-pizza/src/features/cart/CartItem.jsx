/* eslint-disable react/prop-types */


const CartItem = ({ product }) => {
  return (
    <div key={product.id} className="flex justify-between ml-10 items-center max-w-sm">
      <h2>{product.name}</h2> <span>${product.unitPrice}</span>

    </div>
  )
}

export default CartItem