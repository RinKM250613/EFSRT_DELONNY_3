import React from "react";
import ProductoItem from "./ProductoItem";

const ProductoLista = ({ productos }) => {
    return (
        <div className="container">
            <div className="row">
                {productos.map((p) => (
                    <ProductoItem key={p.codigo} producto={p} />
                ))}
            </div>
        </div>
    );
};

export default ProductoLista;
