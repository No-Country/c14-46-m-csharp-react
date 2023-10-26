/* eslint-disable react/prop-types */

import { useDispatch, useSelector } from 'react-redux';
import {
  addProduct,
  deleteProduct,
  getCurrentQuantityById,
} from '../cart/cartSlice';
import UpdateItems from '../cart/UpdateItems';
import toast from 'react-hot-toast';
import { useNavigate } from 'react-router-dom';

const MenuItem = ({ item }) => {
  const navigate = useNavigate();
  const dispatch = useDispatch();

  const currentQuantity = useSelector(getCurrentQuantityById(item.id));
  const currentUser = useSelector((state) => state.user);

  const newItem = {
    id: item.id,
    name: item.name,
    quantity: 1,
    unitPrice: item.unitPrice,
  };

  const handleAddToCart = () => {
    if (currentUser.name) {
      dispatch(addProduct(newItem));
    } else {
      toast.error('Debes iniciar sesión para agregar pizzas al carrito');
      navigate('/login');
    }
  };

  return (
    <div className='card w-full sm:w-96 shadow-xl bg-blue-100 rounded-3xl mb-3 gap-4 mx-auto'>
      <figure>
        <img src={item.imageUrl} alt={item.name} className='w-full' />
      </figure>
      <div className='card-body text-slate-900'>
        <h2 className='card-title text-2xl sm:text-3xl font-bold'>
          {item.name}
        </h2>
        <p className='font-bold text-xl sm:text-2xl'>${item.unitPrice}</p>
        {item.ingredients.map((ingredient) => (
          <p
            className='text-sm sm:text-base py-2 mb-2 font-bold'
            key={ingredient}
          >
            {ingredient.charAt(0).toUpperCase() + ingredient.slice(1)}
          </p>
        ))}
        <div className='card-actions'>
          {!currentQuantity && (
            <button
              className='block px-4 py-3 mt-3 font-bold text-center text-white transition-colors duration 300 bg-teal-800 rounded-xl hover:bg-slate-900'
              onClick={handleAddToCart}
            >
              Agregar al carrito
            </button>
          )}

          {currentQuantity > 0 && (
            <div className='flex items-center justify-center gap-2'>
              <UpdateItems id={item.id} quantity={currentQuantity} />
              <button
                className='btn btn-warning btn-xs sm:btn-sm'
                onClick={() => dispatch(deleteProduct(item.id))}
              >
                Quitar
              </button>
            </div>
          )}
        </div>
      </div>
    </div>
  );
};

export default MenuItem;
