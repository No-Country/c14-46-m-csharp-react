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
    <div className='grid sm:grid-cols-1 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-3 gap-4 px-4'>
      {menu.map((item) => (
        <MenuItem key={item.id} item={item} />
      ))}
    </div>
  );
};

export default Menu;
