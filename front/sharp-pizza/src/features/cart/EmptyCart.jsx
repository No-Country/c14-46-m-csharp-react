import { Link } from "react-router-dom"


const EmptyCart = () => {
  return (
    <div className='bg-stone-100 p-32 h-screen'>
      <Link to="/menu">&larr; Volver al menu</Link>

      <p className='font-semibold mt-7 text-slate-900'>Tu carrito esta vacio. Empeza a agregar pizzas! 😃️</p>
    </div>
  )
}

export default EmptyCart