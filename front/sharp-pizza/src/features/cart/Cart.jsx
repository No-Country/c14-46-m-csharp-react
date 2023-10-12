import { useSelector } from "react-redux"
import { Link } from "react-router-dom"
import CartItem from "./CartItem"

const Cart = () => {
  const username = useSelector(state => state.user.name)
  const products = useSelector(state => state.cart.products)

  return (
    <div className="flex flex-col justify-center items-left gap-2 pt-12">
      <Link to={'/menu'}>&larr; back to menu</Link>
      <h1 className="text-2xl">Tu pedido, {username}</h1>

      {products.map(product => (
        <CartItem key={product.id} product={product} />
      ))}

      <hr />

      <Link className="btn btn-primary w-52 mt-10" to={'/order/new'}>Confirmar compra</Link>
      <button className="btn btn-secondary w-52">Limpiar el carrito</button>


    </div>
  )
}

export default Cart