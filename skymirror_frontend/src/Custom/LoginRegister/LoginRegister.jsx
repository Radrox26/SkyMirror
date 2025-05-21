import React, { useState } from 'react';
import './LoginRegister.css';
import { MdEmail } from "react-icons/md";
import { FaLock, FaUser } from "react-icons/fa";
import { RiLockPasswordFill } from "react-icons/ri";
import axiosInstance from '../../Axios/axiosInstance';
import { useNavigate } from 'react-router-dom';
import loginBackground from '../../Images/loginBackground.png'

function LoginRegister() {
    const [action, setAction] = useState('');
    const [fullName, setFullName] = useState('');
    const [registerEmail, setRegisterEmail] = useState('');
    const [registerPassword, setRegisterPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const [loginEmail, setLoginEmail] = useState('');
    const [loginPassword, setLoginPassword] = useState('');

    const navigate = useNavigate();

    const registerLink = () => setAction(' active');
    const loginLink = () => setAction('');

    const handleLogin = async (e) => {
        e.preventDefault();

        const payload = {
            email: loginEmail,
            password: loginPassword,
        };

        try {
            const response = await axiosInstance.post('/auth/login', payload, {
                withCredentials: true
            });

            if (response.status === 200) {
                const { accessToken } = response.data;
                localStorage.setItem('accessToken', accessToken);
                alert("Login successful!");
                navigate('/products');
            }
        } catch (error) {
            alert("Login failed: " + (error.response?.data?.message || error.message));
            console.error(error);
        }
    };

    const handleRegister = async (e) => {
        e.preventDefault();

        if (registerPassword !== confirmPassword) {
            alert("Passwords do not match!");
            return;
        }

        const payload = {
            FullName: fullName,
            Email: registerEmail,
            Password: registerPassword,
        };

        try {
            const response = await axiosInstance.post('/user', payload);

            if (response.status === 201) {
                alert("User registered successfully!");
                setAction('');
            } else {
                alert("Registration failed: " + (response.data.message || response.statusText));
            }
        } catch (error) {
            alert("Something went wrong during registration.");
            console.error(error);
        }
    };

    return (
        <div>
        <div
                className="background-blur"
                style={{ backgroundImage: `url(${loginBackground})` }}
        />

        <div className={`wrapper${action}`}>
            {/* Login Form */}

            <div className="form-box login">
                <form onSubmit={handleLogin}>
                    <h1>Login</h1>

                    <div className="input-box">
                        <input
                            type="text"
                            placeholder="Email Id"
                            required
                            value={loginEmail}
                            onChange={(e) => setLoginEmail(e.target.value)}
                        />
                        <MdEmail className="icon" />
                    </div>

                    <div className="input-box">
                        <input
                            type="password"
                            placeholder="Password"
                            required
                            value={loginPassword}
                            onChange={(e) => setLoginPassword(e.target.value)}
                        />
                        <FaLock className="icon" />
                    </div>

                    <button type="submit">Login</button>

                    <div className="register-link">
                        <p>New to Sky Mirror? <a href="#" onClick={registerLink}>Register</a></p>
                    </div>
                </form>
            </div>

            {/* Register Form */}
            <div className="form-box register">
                <form onSubmit={handleRegister}>
                    <h1>Registration</h1>

                    <div className="input-box">
                        <input
                            type="text"
                            placeholder="Full Name"
                            required
                            value={fullName}
                            onChange={(e) => setFullName(e.target.value)}
                        />
                        <FaUser className="icon" />
                    </div>

                    <div className="input-box">
                        <input
                            type="text"
                            placeholder="Email Id"
                            required
                            value={registerEmail}
                            onChange={(e) => setRegisterEmail(e.target.value)}
                        />
                        <MdEmail className="icon" />
                    </div>

                    <div className="input-box">
                        <input
                            type="password"
                            placeholder="Password"
                            required
                            value={registerPassword}
                            onChange={(e) => setRegisterPassword(e.target.value)}
                        />
                        <FaLock className="icon" />
                    </div>

                    <div className="input-box">
                        <input
                            type="password"
                            placeholder="Confirm Password"
                            required
                            value={confirmPassword}
                            onChange={(e) => setConfirmPassword(e.target.value)}
                        />
                        <RiLockPasswordFill className="icon" />
                    </div>

                    <button type="submit">Register</button>

                    <div className="register-link">
                        <p>Already using Sky Mirror? <a href="#" onClick={loginLink}>Login</a></p>
                    </div>
                </form>
            </div>
            </div>
        </div>
    );
}

export default LoginRegister;
