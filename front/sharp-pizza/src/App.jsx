import { RouterProvider, createBrowserRouter } from 'react-router-dom';
import Home from './ui/Home';
import Menu from './features/menu/Menu';
import Cart from './features/cart/Cart';
import CreateOrder from './features/order/CreateOrder';
import Order from './features/order/Order';
import Layout from './ui/Layout';
import Login from './features/login/Login';
import Register from './features/register/Register';
import Error from './ui/Error';
import Payment from './features/order/Payment';

const router = createBrowserRouter([
  {
    element: <Layout />,
    errorElement: <Error />,
    children: [
      {
        path: '/menu',
        element: <Menu />,
      },
      {
        path: '/cart',
        element: <Cart />,
      },
      {
        path: '/order/new',
        element: <CreateOrder />,
      },
      {
        path: '/order/:id',
        element: <Order />,
      },
      {
        path: '/order',
        element: <Order />,
      },
      {
        path: '/order/payment',
        element: <Payment />,
      },
    ],
  },
  {
    path: '/',
    element: <Home />,
  },
  {
    path: '/login',
    element: <Login />,
  },
  {
    path: '/register',
    element: <Register />,
  },
]);
function App() {
  return <RouterProvider router={router} />;
}

export default App;
