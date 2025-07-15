import React, { useEffect, useState } from 'react';
import axiosInstance from '../../Axios/axiosInstance';
import './ProductsPage.css';
import productBackgroundImage from '../../Images/Solar Panels at Sunset.png';
import Sidebar from '../SharedUI/sidebar.jsx';
import TopBar from '../SharedUI/topbar.jsx';
import monofacialImage from '../../Images/monofacial.jpg';
import bifacialImage from '../../Images/bifacial.jpg';
import topconImage from '../../Images/topcon.jpg';

const getImageForPanel = (panelName, fallbackImage) => {
    if (panelName.toUpperCase().includes('PHOTOVOLTAIC')) return monofacialImage;
    if (panelName.toUpperCase().includes('BIFACIAL')) return bifacialImage;
    if (panelName.toUpperCase().includes('TOPCON')) return topconImage;
    return fallbackImage || 'https://via.placeholder.com/150';
};

function ProductsPage() {
    const [products, setProducts] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState('');

    useEffect(() => {
        const fetchProducts = async () => {
            try {
                const response = await axiosInstance.get('/product', {
                    headers: {
                        Authorization: `Bearer ${localStorage.getItem('accessToken')}`
                    }
                });
                setProducts(response.data);
                setLoading(false);
            } catch (err) {
                setError('Failed to load products. ' + (err.response?.data?.message || err.message));
                setLoading(false);
            }
        };

        fetchProducts();
    }, []);

    if (loading) return <div className="loading">Loading products...</div>;
    if (error) return <div className="error">{error}</div>;

    return (
        <div className="products-page-wrapper">
            {/* Blurred background image */}
            <div
                className="background-blur"
                style={{ backgroundImage: `url(${productBackgroundImage})` }}
            />
            <TopBar>
                <h1 className="topbar-title">Available Panels</h1>
            </TopBar>
            <Sidebar />
            <div className="products-container">
                <div className="products-grid">
                    {products.map(product => (
                        <div className="product-card" key={product.productId}>
                            <img
                                src={getImageForPanel(product.panelName, product.imageUrl)}
                                alt={product.name}
                            />
                            <h3>{product.panelName}</h3>
                            <h4>{product.powerInWatts} Watts</h4>
                            <div className="price">₹ {product.price}</div>
                            <button className="buyButton">Buy now</button>
                        </div>
                    ))}
                </div>
            </div>
        </div>
    );
}

export default ProductsPage;
