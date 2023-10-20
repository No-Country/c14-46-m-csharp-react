/* eslint-disable react/prop-types */
import toast from 'react-hot-toast';
import { useDispatch, useSelector } from 'react-redux';
import {
  addProduct,
  deleteProduct,
  getCurrentQuantityById,
} from '../cart/cartSlice';
import UpdateItems from '../cart/UpdateItems';
import { useNavigate } from "react-router-dom"

const MenuItem = ({ item }) => {
  const navigate = useNavigate()
  const dispatch = useDispatch();

  const currentQuantity = useSelector(getCurrentQuantityById(item.id));
  const currentUser = useSelector(state => state.user)

  const newItem = {
    id: item.id,
    name: item.name,
    quantity: 1,
    unitPrice: item.unitPrice
  }

  const handleAddToCart = () => {
    if (currentUser.name) {
      dispatch(addProduct(newItem))
    } else {
      toast.error('Debe iniciar sesión para agregar al carrito')
      navigate('/login')
    }
  }

  return (
    <div className='card w-50 bg-base-100 shadow-xl'>
      <figure>
        <img src={item.imageUrl} alt={item.name} className=' rounded-md' />
      </figure>
      <div className='card-body'>
        <h2 className='card-title text-2xl font-bold'>{item.name}</h2>
        <p className='font-bold text-xl'>${item.unitPrice}</p>
        {item.ingredients.map((ingredient) => (
          <p className='text-sm h-2 py-2 mb-2' key={ingredient}>
            {ingredient.charAt(0).toUpperCase() + ingredient.slice(1)}
          </p>
        ))}
        <div className="card-actions">
          {!currentQuantity && <button className="btn btn-primary btn-xs" onClick={handleAddToCart}>Agregar al carrito</button>}

          {currentQuantity > 0 && (
            <div className='flex items-center justify-center gap-2'>
              <UpdateItems id={item.id} quantity={currentQuantity} />
              <button
                className='btn btn-warning btn-xs'
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
