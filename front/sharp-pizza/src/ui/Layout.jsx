import { Outlet } from 'react-router-dom';
import CartOverview from '../features/cart/CartOverview';
import Header from './Header';
import Navbar from './Navbar';

const Layout = () => {
  return (
    <>
      <Navbar />
      <Header />
      <main>
        <Outlet />
      </main>
      <CartOverview />
    </>
  );
};

export default Layout;
