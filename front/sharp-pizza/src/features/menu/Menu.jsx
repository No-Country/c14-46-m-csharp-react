import { useEffect, useState } from 'react';
import MenuItem from './MenuItem';
import { getMenu } from '../../services/apiPizza';

const Menu = () => {
  const [menu, setMenu] = useState([]);

  useEffect(() => {
    getMenu().then((data) => {
      setMenu(data);
    });
  }, []);

  return (
    <div className='grid sm:grid-cols-1 md:grid-cols-2 lg:grid-cols-2 xl:grid-cols-3 gap-8 md:gap-10 px-4 py-20'>
      {menu.map((item) => (
        <MenuItem key={item._id} item={item} />
      ))}
    </div>
  );
};

export default Menu;
