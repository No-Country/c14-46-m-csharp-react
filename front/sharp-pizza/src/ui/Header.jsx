import { Link } from "react-router-dom"

const Header = () => {
  return (
    <header>
      <Link to={"/"}>
        <h1>Sharp Pizza</h1>
        <p>The best pizza in the world</p>
      </Link>
    </header>
  )
}

export default Header