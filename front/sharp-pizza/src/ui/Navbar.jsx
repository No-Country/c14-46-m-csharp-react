import React from 'react';
import { useState } from 'react';
import { FaBars, FaTimes } from 'react-icons/fa';

const Navbar = () => {
  const [nav, setNav] = useState(false);
  const handleClick = () => setNav(!nav);
  return (
    <div className='pl-10 fixed w-full h-[70px] flex justify-between items-center px-4 bg-[#0a192f] text-gray-300'>
      <div>
        <a>
          <h3 className='cursor-pointer font-bold'>Logo</h3>
        </a>
      </div>

      {/* Menu */}
      <ul className='hidden md:flex text-lg'>
        <li className='cursor-pointer mr-4'>
          <a>Inicio</a>
        </li>
        <li className='cursor-pointer mr-4'>
          <a>Nosotros</a>
        </li>
        <li className='cursor-pointer mr-4'>
          <a>Menú</a>
        </li>
        <li className='cursor-pointer mr-4'>
          <a>Localización</a>
        </li>
        <li className='cursor-pointer mr-4'>
          <a>Contacto</a>
        </li>
        <li className='cursor-pointer mr-4'>
          <a>Login</a>
        </li>
      </ul>

      {/* Hamburger */}
      <div onClick={handleClick} className='md:hidden z-10'>
        {!nav ? <FaBars /> : <FaTimes />}
      </div>

      {/* Mobile menu */}
      <ul
        className={!nav ? 'hidden' : 'absolute top-0 left-0 w-full h-screen bg-[#0a192f] flex flex-col justify-center items-center'
        }
      >
        <li className='py-6 text-2xl'>
          <a>Inicio</a>
        </li>
        <li className='py-6 text-2xl'>
          <a>Nosotros</a>
        </li>
        <li className='py-6 text-2xl'>
          <a>Menú</a>
        </li>
        <li className='py-6 text-2xl'>
          <a>Localización</a>
        </li>
        <li className='py-6 text-2xl'>
          <a>Contacto</a>
        </li>
        <li className='py-6 text-2xl'>
          <a>Login</a>
        </li>
      </ul>
    </div>
  );
};

export default Navbar;
