import { Link } from "react-router-dom"
import Username from "../features/user/Username"

const Header = () => {
  return (
    <header className="flex fixed top-0 mb-10 justify-between items-center bg-[#0a192f] h-20 w-full px-10 z-10">
      <Link to={'/'} className="text-3xl font-bold">Sharp Pizza</Link>
      <input type="text" placeholder="Buscar pedido #" className="input input-bordered w-full max-w-xs" />

      <Username />

    </header>
  )
}

export default Header