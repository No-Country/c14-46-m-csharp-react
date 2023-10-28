const API_URL = "http://localhost:3000"

export const getMenu = async () => {
  const response = await fetch(`${API_URL}/menu`)

  if (!response.ok) {
    throw new Error("Failed to fetch menu")
  }

  const data = await response.json()
  return data
}

export const getUsers = async () => {
  const response = await fetch(`${API_URL}/users`)

  if (!response.ok) {
    throw new Error("Failed to fetch users")
  }

  const data = await response.json()
  return data
}

export const getOrders = async () => {
  const response = await fetch(`${API_URL}/orders`)

  if (!response.ok) {
    throw new Error("Failed to fetch orders")
  }

  const data = await response.json()
  return data
}