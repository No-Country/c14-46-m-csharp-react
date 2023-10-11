import { Link } from "react-router-dom"

const Home = () => {
  return (
    <div className="flex flex-col justify-center items-center h-screen gap-2">
      <h1 className="text-3xl">Bienvenido a Sharp Pizza</h1>
      <Link to={'/login'} className="btn btn-primary">Iniciar sesion</Link>
      <p className="text-xl font-bold">No tenes cuenta?</p>
      <Link to={'/register'} className="btn btn-secondary">Crear cuenta</Link>

      <p className="text-xl font-bold">o simplemente ...</p>

      <Link to={'/menu'} className="btn btn-secondary">Ver menu</Link>
    </div>
  )
}

export default Home