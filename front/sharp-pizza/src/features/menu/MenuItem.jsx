/* eslint-disable react/prop-types */

const MenuItem = ({ item }) => {
  return (
    <div className="card w-50 bg-base-100 shadow-xl">
      <figure><img src={item.imageUrl} alt={item.name} /></figure>
      <div className="card-body">
        <h2 className="card-title">{item.name}</h2>
        <p className="font-bold">${item.unitPrice}</p>
        {item.ingredients.map(ingredient => (
          <p className="text-sm h-2 py-2 mb-2" key={ingredient}>{ingredient}</p>
        ))}
        <div className="card-actions">
          <button className="btn btn-primary btn-xs">Add to cart</button>
        </div>
      </div>
    </div>
  )
}

export default MenuItem