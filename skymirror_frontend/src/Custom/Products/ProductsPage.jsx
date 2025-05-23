import React, { useEffect, useState } from 'react';
import axiosInstance from '../../Axios/axiosInstance';
import './ProductsPage.css';
import productBackgroundImage from '../../Images/Solar Panels at Sunset.png';

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

            <div className="products-container">
                <h1>Available Products</h1>
                <div className="products-grid">
                    {products.map(product => (
                        <div className="product-card" key={product.id}>
                            <img
                                src={product.imageUrl || 'https://via.placeholder.com/150'}
                                alt={product.name}
                            />
                            <h3>{product.panelName}</h3>
                            <div className="price">₹ {product.price}</div>
                        </div>
                    ))}
                </div>
            </div>
        </div>
    );
}

export default ProductsPage;
