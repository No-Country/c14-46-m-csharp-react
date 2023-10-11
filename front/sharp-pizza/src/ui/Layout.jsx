import { Outlet } from 'react-router-dom';
import CartOverview from '../features/cart/CartOverview';
import Header from './Header';

const Layout = () => {
  return (
    <>
      <Header />
      <main className='m-20'>
        <Outlet />
      </main>
      <CartOverview />
    </>
  );
};

export default Layout;
