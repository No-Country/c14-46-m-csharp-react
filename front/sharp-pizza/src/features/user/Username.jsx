import { useSelector } from "react-redux"


const Username = () => {
  const username = useSelector(state => state.user.name)

  if (!username) return null

  return (
    <h1 className="sm:text-xl font-bold text-xs">{username.toUpperCase()}</h1>
  )
}

export default Username
