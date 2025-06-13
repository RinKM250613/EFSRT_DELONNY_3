import React, { useEffect, useState } from "react";
import ReactDOM from "react-dom/client";
import ProductoLista from "./components/ProductoLista";
import 'bootstrap/dist/css/bootstrap.min.css';
import Header from "./components/Header";

const App = () => {
    const [productos, setProductos] = useState([]);

    useEffect(() => {
        fetch("/Producto/ObtenerProductosGeneral")
            .then((res) => res.json())
            .then((data) => setProductos(data))
            .catch((err) => console.error("Error cargando productos:", err));
    }, []);

    return (
        <div>
            <Header />
            <div className="container">
                <ProductoLista productos={productos} />
            </div>
        </div>
    );
};

const root = ReactDOM.createRoot(document.getElementById("react-root"));
root.render(<App />);
