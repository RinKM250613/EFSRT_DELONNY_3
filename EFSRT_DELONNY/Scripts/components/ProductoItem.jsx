import React from "react";

const ProductoItem = ({ producto }) => {
    return (
        <div className="col-md-4 mb-4">
            <div className="card h-100 shadow-sm">
                <img
                    src={producto.foto}
                    alt={producto.nombre}
                    className="card-img-top mx-auto d-block"
                    style={{ width: "150px", height: "150px", objectFit: "cover", marginTop: "10px" }}
                />
                <div className="card-body">
                    <h5 className="card-title">{producto.nombre}</h5>
                    <h6 className="card-subtitle mb-2 text-muted">{producto.nomCategoria}</h6>
                    <p className="card-text">{producto.descripcion}</p>
                    <p className="card-text">
                        <strong>Precio:</strong> S/ {producto.precio}
                    </p>
                    <p className="card-text">
                        <strong>Disponible:</strong> {producto.stock}
                    </p>
                </div>
            </div>
        </div>
    );
};



export default ProductoItem;