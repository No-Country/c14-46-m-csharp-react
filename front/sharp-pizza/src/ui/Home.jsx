import { Link } from 'react-router-dom';

const Home = () => {
  return (
    <div className='w-full h-screen bg-[#0a192f]'>
      {/* Container */}
      <div className='max-w-[1000px] mx-auto px-8 flex flex-col justify-center h-full'>
        <h2 className='text-4xl sm:text-5xl text-left font-bold text-[#f77f00]'>
          Sharp Pizza
        </h2>
        <h1 className='mt-4 text-4xl sm:text-5xl text-left font-bold text-[#bfdbfe]'>
          Las Mejores Pizzas Con Los Mejores Ingredientes
        </h1>
        <div className='mt-8'>
          <Link
            to='/menu'
            className='text-white border-2 px-4 py-2 my-2 items-center rounded-lg mt-6'
          >
            Mirar El Menú
          </Link>
        </div>
      </div>
    </div>
  );
};

export default Home;
