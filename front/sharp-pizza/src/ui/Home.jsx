import { Link } from 'react-router-dom';

const Home = () => {
  return (
    <div name='home' className='w-full h-screen bg-[#0a192f] gif'>
      {/* Container */}
      <div className='max-w-[1000px] mx-auto px-8 flex flex-col justify-center h-full'>
        <p className='text-stone-500 text-4xl'>Bienvenidos A</p>
        <h1 className='text-4xl sm:text-7xl font-bold text-stone-400'>
          Sharp Pizza
        </h1>
        <h2 className='text-4xl sm:text-7xl font-bold text-stone-400'>
          Las Mejores Pizzas Con Los Mejores Ingredientes
        </h2>

        <Link to='/menu'>
          <button className='rounded-md text-center text-white group border-2 px-6 py-3 my-2 mt-4 flex items-center hover:bg-blue-600 hover:border-blue-600'>
            Nuestro Menú
            <span className='group-hover:rotate-90 duration-300'></span>
          </button>
        </Link>
      </div>
    </div>
  );
};

export default Home;
