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
                const response = await axiosInstance.get('/getCartProducts', {
                    headers: {
                        Authorization: `Bearer ${localStorage.getItem('accessToken')}`
                    }
                });
                setCartProducts(response.data);
            } catch (error) {
                setError('Failed to load cart products. ' + (err.response?.data?.messgae || err.message));
                setLoading(false);
            }
        };

        fetchCartProducts();
    });

    const toggleCartBar = () => {
        setisCartBarOpen(!isCartBarOpen)
    }

    return (
        <div className={`cartbar ${isCartBarOpen ? 'open' : 'closed'}`}>
            <button className="cart-toggle-button" onClick={toggleCartBar}>
                <FaOpencart className="cart-icon"/>
            </button>
        </div>
    );
}

export default CartBar;