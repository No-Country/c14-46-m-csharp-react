import { useDispatch } from 'react-redux';
import toast from 'react-hot-toast';

import { addProduct } from '../cart/cartSlice';

const MenuItem = ({ item }) => {
  const dispatch = useDispatch();

  const newItem = {
    id: item.id,
    name: item.name,
    quantity: 1,
    unitPrice: item.unitPrice,
    totalPrice: item.unitPrice * 1,
  };

  const addToCart = () => {
    dispatch(addProduct(newItem));
    toast.success('Producto agregado!');
  };

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
        <div className='card-actions justify-start'>
          <button
            className='btn btn-active btn-neutral my-4'
            onClick={addToCart}
          >
            Agregar al carrito
          </button>
        </div>
      </div>
    </div>
  );
};

export default MenuItem;
