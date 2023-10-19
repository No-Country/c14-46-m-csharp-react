import { useSelector } from "react-redux"


const Username = () => {
  const username = useSelector(state => state.user.name)

  if (!username) return null

  return (
    <h1 className="text-xl">{username.toUpperCase()}</h1>
  )
}

export default Username
