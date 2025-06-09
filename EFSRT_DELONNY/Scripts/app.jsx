import React from 'react';
import { createRoot } from 'react-dom/client';

const App = () => {
    return <h2>Hola desde React dentro de ASP.NET MVC</h2>;
};

const container = document.getElementById("react-root");
const root = createRoot(container);
root.render(<App />);