const API_URL = "http://localhost:3001"

export const getMenu = async () => {
  const response = await fetch(`${API_URL}/menu`)

  if (!response.ok) {
    throw new Error("Failed to fetch menu")
  }

  const data = await response.json()
  return data
}

export const getUsers = async () => {
  const response = await fetch(`${API_URL}/user`)

  if (!response.ok) {
    throw new Error("Failed to fetch users")
  }

  const data = await response.json()
  return data
}