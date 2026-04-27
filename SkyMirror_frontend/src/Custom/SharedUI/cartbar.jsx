import React, { useEffect, useState } from 'react';
import axiosInstance from '../../Axios/axiosInstance';
import { FaOpencart } from "react-icons/fa6";
import './CartBar.css';

const CartBar = () => {
    const [isCartBarOpen, setisCartBarOpen] = useState(false);
    const [loading, setLoading] = useState(true);
    const [cartProducts, setCartProducts] = useState([]);
    const [error, setError] = useState('');

    useEffect(() => {
        const fetchCartProducts = async () => {
            try {
                const response = await axiosInstance.get('Cart/GetCartProducts/3', {
                    headers: {
                        Authorization: `Bearer ${localStorage.getItem('accessToken')}`
                    }
                });
                setCartProducts(response.data);
                setLoading(!loading);
            } catch (err) {
                setError('Failed to load cart products. ' + (err.response?.data?.messgae || err.message));
                setLoading(false);
            }
        };

        fetchCartProducts();
    }, []);

    const toggleCartBar = () => {
        setisCartBarOpen(!isCartBarOpen)
    }

    return (
        <div className={`cartbar ${isCartBarOpen ? 'open' : 'closed'}`}>
            <button className="cart-toggle-button" onClick={toggleCartBar}>
                <FaOpencart className="cart-icon"/>
            </button>
            <div className="cart-products">
            {(() => {
                while (loading) {
                return <p>Loading...</p>;
                }
                if (error) {
                return <p className="error-message">{error}</p>;
                }
                else if (cartProducts.length === 0) {
                return <p>Your cart is empty.</p>;
                }
                else {
                    return cartProducts.map((product, index) => (
                    <div key={index} className="cart-product-item">
                    <p><strong>{product.panelName}</strong></p>
                    <p>Quantity: {product.Quantity}</p>
                    <p>Price Per Panel: Rs {product.panelPrice}</p>
                    </div>
                    ));
                }
            })()}
            </div>
        </div>
    );
}

export default CartBar;