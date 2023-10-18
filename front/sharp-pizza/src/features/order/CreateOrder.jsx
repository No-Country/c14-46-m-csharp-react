import { useSelector } from "react-redux"
import EmptyCart from "../cart/EmptyCart"

const CreateOrder = () => {

  const client = useSelector(state => state.user)
  const products = useSelector(state => state.cart.products)

  if (!products.length) return <EmptyCart />

  return (
    <div className="px-4 py-6">
      <h2 className="mb-8 text-xl font-semibold">Listo para confirmar tu pedido? Vamos!</h2>

      <form>
        <div className="mb-5 flex gap-2 flex-col sm:flex-row sm:items-center">
          <label className="sm:basis-40">Pedido a nombre de:</label>
          <input className="input grow" type="text" name="customer" defaultValue={client.name} required />
        </div>

        <div className="mb-5 flex gap-2 flex-col sm:flex-row sm:items-center">
          <label className="sm:basis-40">Teléfono de contacto:</label>
          <div className="grow">
            <input className="input w-full" type="tel" name="phone" defaultValue={client.phone} required />
          </div>
        </div>

        <div className="mb-5 flex gap-2 flex-col sm:flex-row sm:items-center">
          <label className="sm:basis-40">Dirección de envio:</label>
          <div className="grow">
            <input
              className="input w-full"
              type="text" name="address" defaultValue={client.address} required />
          </div>
        </div>

        <fieldset className="mb-12 flex items-center gap-5">
          <legend>Seleccionar método de pago:</legend>

          <div>
            <input type="radio" id="cash" name="drone" value="cash" />
            <label htmlFor="cash">Efectivo (paga al delivery)</label>
          </div>

          <div>
            <input type="radio" id="mp" name="drone" value="mp" />
            <label htmlFor="mp">Mercado Pago</label>
          </div>

        </fieldset>

        <div>
          <button className="btn btn-primary">Confirmar pedido</button>
        </div>
      </form>
    </div>
  )
}

export default CreateOrder