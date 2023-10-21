/* eslint-disable react/prop-types */


const OrderItem = ({ quantity, name, totalPrice }) => {
  return (
    <li className="py-3">
      <div className="grid grid-cols-2 text-md gap-10">
        <p>
          <span className="font-bold">{quantity}&times;</span> {name}
        </p>
        <p className="font-bold">${totalPrice}</p>
      </div>
    </li>
  )
}

export default OrderItem