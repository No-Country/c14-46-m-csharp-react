
import { Link, useNavigate, useRouteError } from 'react-router-dom'

const Error = () => {
  const error = useRouteError()
  const navigate = useNavigate()
  return (
    <div>
      <h1>Something went wrong 😢</h1>
      <p>{error.data || error.message}</p>

      <Link onClick={() => navigate(-1)}>&larr; Go back</Link>
    </div>
  )
}

export default Error