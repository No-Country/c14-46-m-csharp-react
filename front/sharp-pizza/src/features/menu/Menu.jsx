import { useEffect, useState } from "react"
import MenuItem from "./MenuItem"
import { getMenu } from "../../services/apiPizza"

const Menu = () => {

  const [menu, setMenu] = useState([])

  useEffect(() => {
    getMenu().then(data => {
      setMenu(data)
    })
  }, [])

  return (
    <main className="ml-10">
      <div className='flex flex-wrap gap-10'>
        {menu.map(item => (
          <MenuItem key={item.id} item={item} />
        ))}
      </div>
    </main>
  )
}

export default Menu