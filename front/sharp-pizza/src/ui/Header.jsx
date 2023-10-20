import { Link, useNavigate } from "react-router-dom"
import Username from "../features/user/Username"
import { HiOutlineLogout } from "react-icons/hi"
import { useDispatch, useSelector } from "react-redux"
import { logout } from "../features/user/userSlice"
import { clearCart } from "../features/cart/cartSlice"
import { useState } from "react"
import { BiLogIn } from 'react-icons/bi';
import { BsCart } from 'react-icons/bs';
import { FiSearch } from 'react-icons/fi';
import { FaBars, FaTimes } from 'react-icons/fa';

const Header = () => {
  const username = useSelector(state => state.user.name)
  const dispatch = useDispatch()
  const navigate = useNavigate()

  const [nav, setNav] = useState(false);
  const handleClick = () => setNav(!nav);

  const [searchOpen, setSearchOpen] = useState(false);
  const toggleSearch = () => {
    setSearchOpen(!searchOpen);
  };

  const handleInputClick = (e) => {
    e.stopPropagation(); // Evita que se propague el evento de click al contenedor
  };

  const handleLogout = () => {
    dispatch(logout())
    dispatch(clearCart())
    navigate('/login')
  }

  return (
    <div className='flex fixed top-0 pl-10 w-full h-[80px] justify-between items-center px-6 bg-[#0a192f] text-gray-300'>
      <div>
        <a href='#' className='cursor-pointer'>
          <Link to='/' className='text-2xl'>Sharp Pizza</Link>
        </a>
      </div>

      <ul className='hidden md:flex space-x-6 items-center'>
        <li>
          <a href='#' onClick={toggleSearch} className='flex items-center'>
            <FiSearch
              className={`ml-2 hover:text-blue-500 ${searchOpen ? 'w-12' : 'w-6'
                } transition-all duration-3000 ease-in-out`}
              size={22}
            />
            {searchOpen && (
              <input
                type='text'
                placeholder='Busca Tu Pizza...'
                className='input input-bordered input-sm w-full max-w-xs ml-2'
                onClick={handleInputClick}
              />
            )}
          </a>
        </li>
        <li>
          <Link to='/cart' href='#' className='hover:text-blue-500 flex items-center'>
            <BsCart className='ml-2' size={22} />
          </Link>
        </li>
        <li>
          {username ? <div className='flex items-center'><Username /><BiLogIn className='ml-2' size={30} onClick={handleLogout} /></div> : <Link to='/login' className='hover:text-blue-500 flex items-center'>
            Iniciar Sesión
          </Link>}
        </li>
      </ul>

      {/* Hamburger */}
      <div onClick={handleClick} className='md:hidden z-10'>
        {!nav ? <FaBars /> : <FaTimes />}
        <header className="flex fixed top-0 mb-10 justify-between items-center bg-[#0a192f] h-20 w-full px-10 z-10">
          <Link to={'/'} className="text-3xl font-bold">Sharp Pizza</Link>
          <input type="text" placeholder="Buscar pedido #" className="input input-bordered w-full max-w-xs" />

          <div className="flex justify-center items-center gap-2">
            <Username />
            {username && <HiOutlineLogout size={25} onClick={handleLogout} />}
          </div>

        </header>
      </div>
    </div>
  )
}

export default Header