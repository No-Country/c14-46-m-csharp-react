import { useSelector } from "react-redux"


const Username = () => {
  const username = useSelector(state => state.user.name)

  if (!username) return null

  return (
    <h1 className="text-xl">{username}</h1>
  )
}

export default Username
