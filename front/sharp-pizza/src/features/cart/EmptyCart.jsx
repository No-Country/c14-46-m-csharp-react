import { Link } from "react-router-dom"


const EmptyCart = () => {
  return (
    <div className='px-4 py-3'>
      <Link to="/menu">&larr; Volver al menu</Link>

      <p className='font-semibold mt-7'>Tu carrito esta vacio. Empeza a agregar pizzas! 😃️</p>
    </div>
  )
}

export default EmptyCart