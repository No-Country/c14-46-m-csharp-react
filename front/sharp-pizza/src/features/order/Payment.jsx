import { useState } from "react"
import Cards from 'react-credit-cards-2';
import 'react-credit-cards-2/dist/es/styles-compiled.css';
import toast from "react-hot-toast";
import { useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
import { updatePayment } from "./paymentSlice";

const Payment = () => {
  const dispatch = useDispatch()
  const navigate = useNavigate()
  const [loading, setLoading] = useState(false)
  const [cardData, setCardData] = useState({
    number: '',
    expiry: '',
    cvc: '',
    name: '',
    focus: '',
  })

  const { number, expiry, cvc, name } = cardData

  const handleInputChange = (e) => {
    const { name, value } = e.target
    setCardData({ ...cardData, [name]: value })
  }

  const handleInputFocus = (e) => {
    setCardData({ ...cardData, focus: e.target.name })
  }

  const handleSubmit = (e) => {
    e.preventDefault()
    setLoading(true)
    setTimeout(() => {
      navigate('/order/new')
      toast.success('Datos de tarjeta procesados. Ahora podes confirmar el pedido.')
    }, 3000)
  }

  const handleBuy = () => {
    if (number === '' || name === '' || expiry === '' || cvc === '') {
      toast.error('Por favor completa los datos de la tarjeta')
      return;
    }
    dispatch(updatePayment(cardData))
  }

  return (
    <div className="flex flex-col gap-4 m-32">
      <Cards
        number={number}
        name={name}
        expiry={expiry}
        cvc={cvc}
        focused={cardData.focus}
      />

      <form onSubmit={handleSubmit} className="flex flex-col justify-around items-center gap-4">
        <div className="flex flex-col">
          <label htmlFor="number">Número de tarjeta</label>
          <input type="text" id="number" name="number" value={number} onChange={handleInputChange} onFocus={handleInputFocus} className="input input-success bg-slate-800 input-sm w-full" required />
        </div>

        <div className="flex flex-col">
          <label htmlFor="name">Nombre completo</label>
          <input type="text" name="name" id="name" value={name} onChange={handleInputChange} onFocus={handleInputFocus} className="input input-success bg-slate-800 input-sm w-full" required />
        </div>

        <div className="flex flex-col">
          <label htmlFor="expiry">Fecha de expiración</label>
          <input type="text" name="expiry" id="expiry" value={expiry} onChange={handleInputChange} onFocus={handleInputFocus} className="input input-success bg-slate-800 input-sm w-full" required />
        </div>

        <div className="flex flex-col">
          <label htmlFor="cvc">Código de seguridad</label>
          <input type="text" name="cvc" id="cvc" value={cvc} onChange={handleInputChange} onFocus={handleInputFocus} className="input input-success bg-slate-800 input-sm w-full" required />
        </div>
        {loading ? <button type='submit' className="btn btn-success btn-sm loading loading-spinner text-primary">Loading</button> : <button type='submit' className="btn btn-success btn-sm" onClick={handleBuy}>COMPRAR</button>}
      </form>
    </div>
  )
}

export default Payment