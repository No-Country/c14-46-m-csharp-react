import { FaBars, FaTimes } from 'react-icons/fa';
import { useState } from 'react';
import { BiLogIn } from 'react-icons/bi';
import { BsCart } from 'react-icons/bs';
import { FiSearch } from 'react-icons/fi';
import { Link } from 'react-router-dom';

const Navbar = () => {
  const [nav, setNav] = useState(false);
  const handleClick = () => setNav(!nav);

  const [searchOpen, setSearchOpen] = useState(false);
  const toggleSearch = () => {
    setSearchOpen(!searchOpen);
  };

  const handleInputClick = (e) => {
    e.stopPropagation(); // Evita que se propague el evento de click al contenedor
  };

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
              className={`ml-2 hover:text-blue-500 ${
                searchOpen ? 'w-12' : 'w-6'
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
          <Link to='/login' className='hover:text-blue-500 flex items-center'>
            Iniciar Sesión
            <BiLogIn className='ml-2' size={20} />
          </Link>
        </li>
      </ul>

      {/* Hamburger */}
      <div onClick={handleClick} className='md:hidden z-10'>
        {!nav ? <FaBars /> : <FaTimes />}
      </div>

      {/* Mobile menu */}
      <ul
        className={
          !nav
            ? 'hidden'
            : 'absolute top-0 left-0 w-full h-screen bg-[#0a192f] flex flex-col justify-center items-center'
        }
      >
        <li className='py-6 text-4xl'>
          <a href='#' className='hover:text-blue-500'>
            Home
          </a>
        </li>

        <li className='py-6 text-4xl'>
          <a href='#' className='hover:text-blue-500'>
            Login
          </a>
        </li>
      </ul>
    </div>
  );
};

export default Navbar;
