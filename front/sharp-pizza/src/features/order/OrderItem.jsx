/* eslint-disable react/prop-types */


const OrderItem = ({ quantity, name, totalPrice }) => {
  return (
    <li className="py-3">
      <div className="flex items-center justify-between gap-4 text-sm">
        <p>
          <span className="font-bold">{quantity}&times;</span> {name}
        </p>
        <p className="font-bold">${totalPrice}</p>
      </div>
    </li>
  )
}

export default OrderItem