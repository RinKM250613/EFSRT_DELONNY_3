import React from 'react';

const Header = () => {
    return (
        <header className="bg-primary text-white py-3 mb-4 shadow">
            <div className="container d-flex justify-content-between align-items-center">
                <h3 className="mb-0">Delonny's</h3>
                <div>
                    <button
                        className="btn btn-light me-2"
                        onClick={() => window.location.href = "/Producto/Tienda"}
                    >
                        <i className="bi bi-house-door-fill me-1"></i> Inicio
                    </button>
                    <button
                        className="btn btn-light me-2"
                        onClick={() => window.location.href = "/Home/About"}
                    >
                        <i className="bi bi-info-circle-fill me-1"></i> Acerca de
                    </button>
                    <button
                        className="btn btn-light"
                        onClick={() => window.location.href = "/Home/Contact"}
                    >
                        <i className="bi bi-envelope-fill me-1"></i> Contacto
                    </button>
                </div>
            </div>
        </header>
    );
};

export default Header;