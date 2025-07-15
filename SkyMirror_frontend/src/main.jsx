import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import { BrowserRouter, Routes, Route} from 'react-router-dom';

import LoginRegister from './Custom/LoginRegister/LoginRegister.jsx';
import ProductPage from './Custom/Products/ProductsPage.jsx';
import HomePage from './Custom/Home/HomePage.jsx';

ReactDOM.createRoot(document.getElementById('root')).render(
    <React.StrictMode>
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<LoginRegister />} />
                <Route path="/products" element={<ProductPage />} />
                <Route path="/home" element={<HomePage />} />
            </Routes>
        </BrowserRouter>
    </React.StrictMode>
);
