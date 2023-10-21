import { useDispatch, useSelector } from "react-redux"
import EmptyCart from "../cart/EmptyCart"
import toast from "react-hot-toast"
import axios from "axios"
import { clearCart, getTotalPrice } from "../cart/cartSlice"
import { useNavigate } from "react-router-dom"
import { ZodType, z } from "zod"
import { useForm } from "react-hook-form"
import { zodResolver } from "@hookform/resolvers/zod"
import React from "react"

type FormData = {
  customer: string;
  phone: string;
  address: string;
  paymentMethod: string;
}

const CreateOrder = () => {

  const client = useSelector(state => state.user)
  const products = useSelector(state => state.cart.products)
  const totalPrice = useSelector(getTotalPrice)
  
  
  const navigate = useNavigate()
  const dispatch = useDispatch()
  
  const schema: ZodType<FormData> = z.object({
    customer: z.string(),
    phone: z.string(),
    address: z.string(),
    paymentMethod: z.string(),
  })
  
  const {register, handleSubmit} = useForm<FormData>({
    resolver: zodResolver(schema),
  })

  const handleOrder = (data: FormData) => {
    toast.promise(axios.post('http://localhost:3001/order', {
      orderId: Math.floor(Math.random() * Date.now()).toString(16),
      customer: data.customer,
      phone: data.phone,
      address: data.address,
      date: new Date().toLocaleString(),
      products,
      paymentMethod: data.paymentMethod,
      orderPrice: totalPrice,
      status: 'preparacion'
    }).then(() => {
      navigate('/order')
      dispatch(clearCart())
    }), {
      loading: 'Enviando...',
      success: 'Gracias por tu compra 🍕',
      error: 'Error en proceso de envío. Por favor intente mas tarde.',
    })
  }

  return (
    <div className="bg-stone-100 p-36 text-slate-900 flex flex-col justify-center items-center">
      <h2 className="mb-8 text-2xl font-semibold">Listo para confirmar tu pedido? Vamos!</h2>

      <form onSubmit={handleSubmit(handleOrder)}>
        <div className="mb-5 flex gap-2 flex-col sm:flex-row sm:items-center">
          <label className="sm:basis-40">Pedido a nombre de:</label>
          <input className="input input-primary bg-slate-300" type="text" defaultValue={client.name} required {...register('customer')} />
        </div>

        <div className="mb-5 flex gap-2 flex-col sm:flex-row sm:items-center">
          <label className="sm:basis-40">Teléfono de contacto:</label>
          <div className="grow">
            <input className="input input-primary bg-slate-300" type="tel" defaultValue={client.phone} required {...register('phone')} />
          </div>
        </div>

        <div className="mb-5 flex gap-2 flex-col sm:flex-row sm:items-center">
          <label className="sm:basis-40">Dirección de envio:</label>
          <div className="grow">
            <input
              className="input input-primary bg-slate-300"
              type="text" defaultValue={client.address} required {...register('address')} />
          </div>
        </div>

        <fieldset className="mb-12 flex items-center gap-5">
          <legend>Seleccionar método de pago:</legend>

          <div>
            <input type="radio" id="cash" {...register('paymentMethod')} value="efectivo" required />
            <label htmlFor="cash">Efectivo (paga al delivery)</label>
          </div>

          <div>
            <input type="radio" id="mp" {...register('paymentMethod')} value="mercado pago" required />
            <label htmlFor="mp">Mercado Pago</label>
          </div>

        </fieldset>

        <div>
          <button className="btn btn-primary btn-sm">Confirmar pedido por ${totalPrice}</button>
        </div>
      </form>
    </div>
  )
}

export default CreateOrder