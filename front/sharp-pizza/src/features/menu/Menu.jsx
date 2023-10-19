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
    <main className='mx-10'>
      <h1 className='text-3xl text-center py-7'>Nuestro Menú</h1>
      <div className='grid sm:grid-cols-1 2xl:px-4 sm:justify-center md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-3 justify-between gap-8'>
        {menu.map((item) => (
          <MenuItem key={item.id} item={item} />
        ))}
      </div>
    </main>
  );
};

export default Menu;
