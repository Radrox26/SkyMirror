import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import { BrowserRouter, Routes, Route} from 'react-router-dom';

import LoginRegister from './Custom/LoginRegister/LoginRegister.jsx';
import HomePage from './Custom/Home/HomePage.jsx';
import ProductsPage from './Custom/Products/ProductsPage.jsx';
import ProductDetailsPage from './Custom/Products/ProductDetailsPage.jsx';

ReactDOM.createRoot(document.getElementById('root')).render(
    <React.StrictMode>
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<LoginRegister />} />
                <Route path="/home" element={<HomePage />} />
                <Route path="/products" element={<ProductsPage />} />
                <Route path="/products/:productId" element={<ProductDetailsPage />} />
            </Routes>
        </BrowserRouter>
    </React.StrictMode>
);
