import { useSelector } from "react-redux"
import { Link } from "react-router-dom"
import { BsFillCartPlusFill } from "react-icons/bs"
import { getTotalPrice, getTotalQuantity } from "./cartSlice"

const CartOverview = () => {

  const totalQuantity = useSelector(getTotalQuantity)
  const totalPrice = useSelector(getTotalPrice)

  return (
    <div className="flex justify-between px-10 w-full items-center fixed bottom-0 h-20 bg-[#0a192f] font-bold" >
      <p className="flex gap-2">
        <span className="">{totalQuantity} pizzas -</span>
        <span>${totalPrice}</span>
      </p>
      <div className="flex justify-center items-center gap-2"><Link to={'/cart'}>Ir al carrito &rarr; <BsFillCartPlusFill size={25} /></Link></div>
    </div>
  )
}

export default CartOverview