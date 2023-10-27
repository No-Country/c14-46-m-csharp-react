import { useEffect, useState } from "react";
import { getOrders } from "../../services/apiPizza";
import OrderItem from "./OrderItem";
import { useParams } from "react-router";

const Order = () => {
  const [orders, setOrders] = useState([]);
  const { id } = useParams()

  useEffect(() => {
    getOrders().then(data => {
      setOrders(data)
    })
  }, [])

  const searchedOrder = orders.find(order => order.orderId === id)
  const lastOrder = orders[orders.length - 1]
  const order = id ? searchedOrder : lastOrder

  const getStatus = (date1, date2) => {
    const differenceInMinutes = Math.abs(date2 - date1) / (1000 * 60);
    if (differenceInMinutes < 15) {
      return 'en preparacion'
    } else if (differenceInMinutes < 30) {
      return 'en delivery'
    } else {
      return 'entregado'
    }
  };

  const orderDate = searchedOrder ? searchedOrder?.date : lastOrder?.date
  const currentDate = new Date()

  const status = getStatus(Date.parse(orderDate), Date.parse(currentDate))

  return (
    <div className="p-44 bg-stone-100 rounded-lg space-y-8 h-screen text-slate-900">
      <div className="flex flex-wrap items-center justify-between gap-2">
        <h2 className="text-xl font-semibold ">Pedido #{order?.orderId}</h2>

        <div className="space-x-2">
          <span className={`rounded-full ${status !== 'entregado' ? 'bg-red-500' : 'bg-green-500'} px-3 py-1 text-sm font-semibold uppercase traking-wide text-green-50`}>Pedido: {status}</span>
        </div>
      </div>

      <div>
        <p className="text-sm text-stone-500">👉️ Fecha y hora del pedido: {orderDate}</p>
        <p className="text-sm text-stone-500">👉️ Pedido a nombre de: {order?.customer.toUpperCase()}</p>
        <p className="text-sm text-stone-500">👉️ Medio de pago: {order?.paymentMethod.toUpperCase()}</p>
      </div>

      <ul className="divide-stone-200 divide-y border-b border-t">
        {order?.products.map(product => (
          <OrderItem key={product.id} quantity={product.quantity} name={product.name} totalPrice={product.unitPrice * product.quantity} />
        ))}
      </ul>

      <div className="space-y-2 bg-stone-200 px-6 py-5">
        <p className="text-md font-bold text-stone-950">Precio total: ${order?.orderPrice}</p>
      </div>
    </div>
  )
}

export default Order