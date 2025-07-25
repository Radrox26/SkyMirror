import React, { useEffect, useState } from 'react';
import axiosInstance from '../../Axios/axiosInstance';
import './ProductsPage.css';
import productBackgroundImage from '../../Images/Solar Panels at Sunset.png';
import Sidebar from '../SharedUI/sidebar.jsx';
import TopBar from '../SharedUI/topbar.jsx';
import monofacialImage from '../../Images/ProductImages/Monofacial/monofacial.jpg';
import bifacialImage from '../../Images/ProductImages/Bifacial/bifacial.jpg';
import topconImage from '../../Images/ProductImages/Topcon/topcon.jpg';
import { useNavigate } from 'react-router-dom';

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
    const navigate = useNavigate();

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
            <CartBar></CartBar>
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
                            <button
                                className="seeDetails"
                                onClick={() => navigate(`/products/${product.productId}`)}>
                                See Details
                            </button>
                        </div>
                    ))}
                </div>
            </div>
        </div>
    );
}

export default ProductsPage;
