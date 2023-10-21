import { Outlet } from 'react-router-dom';
import CartOverview from '../features/cart/CartOverview';
import Header from './Header';
import { useSelector } from 'react-redux';
import { Toaster } from 'react-hot-toast';


const Layout = () => {

  const products = useSelector(state => state.cart.products);
  return (
    <>
      <Header />
      <Toaster toastOptions={{ duration: 3000 }} />

      <main>
        <Outlet />
      </main>
      {products.length > 0 && <CartOverview />}
    </>
  );
};

export default Layout;
