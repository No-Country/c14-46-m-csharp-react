import { useEffect, useState } from 'react';
import MenuItem from './MenuItem';
import { getMenu } from '../../services/apiPizza';

const Menu = () => {
  const [menu, setMenu] = useState([]);

  useEffect(() => {
    getMenu().then(data => {
      setMenu(data)
    })
  }, [])

  return (
    <main className='bg-stone-100'>
      {/* <h1 className='text-5xl text-center pt-24 text-stone-900 font-bold tracking-widest underline'>NUESTRO MENU</h1> */}
      <div className='grid sm:grid-cols-1 2xl:px-4 sm:justify-center md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-3 gap-10 p-12 m-12'>
        {menu.map((item) => (
          <MenuItem key={item.id} item={item} />
        ))}
      </div>
    </main>
  );
};

export default Menu;
