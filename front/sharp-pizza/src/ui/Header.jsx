import { Link, useNavigate } from 'react-router-dom';
import Username from '../features/user/Username';
import { HiOutlineLogout } from 'react-icons/hi';
import { useDispatch, useSelector } from 'react-redux';
import { logout } from '../features/user/userSlice';
import { clearCart } from '../features/cart/cartSlice';
import { BsFillCartPlusFill } from 'react-icons/bs';
import toast from 'react-hot-toast';

const Header = () => {
  const username = useSelector((state) => state.user.name);
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const handleLogout = () => {
    dispatch(logout());
    dispatch(clearCart());
    navigate('/');
    toast.success('Sesión cerrada! Vuelva pronto.');
  };

  return (
    <header className='flex fixed top-0 mb-10 justify-between items-center bg-[#0a192f] h-20 w-full px-10 z-10 '>
      <Link to={'/'} className='text-3xl font-bold'>
        sharp pizza
      </Link>
      <input
        type='text'
        placeholder='Busca Un Pedido...'
        className='input input-bordered w-full max-w-xs'
      />

      <div className='flex justify-center items-center gap-4'>
        {!username && <Link to={'/login'} className='font-bold' >
          INICIAR SESION
        </Link>}
        <Username />
        {username && (
          <div className='flex justify-center items-center gap-4'>
            <Link to={'/cart'}>
              <BsFillCartPlusFill size={25} />
            </Link>

            <HiOutlineLogout
              size={25}
              onClick={handleLogout}
              className='cursor-pointer'
            />
          </div>
        )}
      </div>
    </header>
  );
};

export default Header;
