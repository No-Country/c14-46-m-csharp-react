import { Link } from "react-router-dom"

const Home = () => {
  return (
    <div className='w-full h-screen bg-[#0a192f] gif'>
      <div className='max-w-md mx-auto px-8 flex flex-col justify-center items-center h-full'>
        <h2 className='text-8xl sm:text-5xl font-bold text-slate-900 underline tracking-wide hover:text-lime-950 cursor-progress'>
          SHARP PIZZA
        </h2>

        <h1 className='mt-4 text-4xl sm:text-5xl text-center font-bold text-lime-950 tracking-wider hover:text-slate-900'>
          Las mejores pizzas con los mejores ingredientes
        </h1>
        <div className='mt-8'>
          <Link
            to='/menu'
            className='btn btn-accent btn-lg w-52 mt-10'
          >
            VER MENU
          </Link>
        </div>
      </div>
    </div>
  )
}

export default Home