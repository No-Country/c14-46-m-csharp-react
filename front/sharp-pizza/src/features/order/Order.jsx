import { useEffect, useState } from "react";
import { getOrders } from "../../services/apiPizza";
import OrderItem from "./OrderItem";

const Order = () => {
  const [orders, setOrders] = useState([]);

  useEffect(() => {
    getOrders().then(data => {
      setOrders(data)
    })
  }, [])

  const lastOrder = orders[orders.length - 1]

  return (
    <div className="px-4 py-6 space-y-8">
      <div className="flex flex-wrap items-center justify-between gap-2">
        <h2 className="text-xl font-semibold">Order #{lastOrder?.orderId} {lastOrder?.status}</h2>

        <div className="space-x-2">
          <span className="rounded-full bg-green-500 px-3 py-1 text-sm font-semibold uppercase traking-wide text-green-50">Pedido en preparacion</span>
        </div>
      </div>

      <div>
        <p className="text-xs text-stone-500">(Tiempo de entrega estimado: 30 minutos)</p>
      </div>

      <ul className="divide-stone-200 divide-y border-b border-t">
        {lastOrder?.products.map(product => (
          <OrderItem key={product.id} quantity={product.quantity} name={product.name} totalPrice={product.unitPrice * product.quantity} />
        ))}
      </ul>

      <div className="space-y-2 bg-stone-200 px-6 py-5">
        <p className="text-sm font-medium text-stone-600">Precio total: ${lastOrder?.orderPrice}</p>
      </div>
    </div>
  )
}

export default Order