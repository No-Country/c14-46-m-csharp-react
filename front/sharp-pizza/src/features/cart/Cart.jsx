import { useDispatch, useSelector } from "react-redux"
import { Link } from "react-router-dom"
import CartItem from "./CartItem"
import { clearCart } from "./cartSlice"
import EmptyCart from "./EmptyCart"

const Cart = () => {
  const username = useSelector(state => state.user.name)
  const products = useSelector(state => state.cart.products)
  const dispatch = useDispatch()

  if (!products.length) return <EmptyCart />

  return (
    <div className="flex flex-col justify-center items-center gap-4 p-24 bg-stone-100 h-screen">
      <Link to={'/menu'}>&larr; Volver al menu</Link>
      <h1 className="text-2xl text-slate-900">Tu pedido, {username}</h1>

      {products.map(product => (
        <CartItem key={product.id} product={product} />
      ))}

      <hr />

      <Link className="btn btn-primary btn-sm w-52 mt-10" to={'/order/new'}>Confirmar compra</Link>
      <button className="btn btn-secondary btn-sm w-52" onClick={() => dispatch(clearCart())}>Limpiar el carrito</button>
    </div>
  )
}

export default Cart