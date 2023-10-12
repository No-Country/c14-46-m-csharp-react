import { useSelector } from "react-redux"
import { Link } from "react-router-dom"
import { BsFillCartPlusFill } from "react-icons/bs"

const CartOverview = () => {

  const products = useSelector(state => state.cart.products)
  const total = useSelector(state => state.cart.total)

  return (
    <div className="flex justify-between px-10 w-full items-center fixed bottom-0 h-20 bg-[#0a192f] font-bold" >
      <p className="flex gap-2">
        <span className="">{products.length} pizzas -</span>
        <span>${total}</span>
      </p>
      <div className="flex justify-center items-center gap-2"><Link to={'/cart'}>Open cart &rarr; <BsFillCartPlusFill size={25} /></Link></div>
    </div>
  )
}

export default CartOverview