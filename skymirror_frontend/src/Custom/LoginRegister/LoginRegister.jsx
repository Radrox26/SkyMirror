import React, { useState } from 'react';
import './LoginRegister.css';
import { MdEmail } from "react-icons/md";
import { FaLock, FaUser } from "react-icons/fa";
import { RiLockPasswordFill } from "react-icons/ri";



function Login() {

    const [action, setAction] = useState('');
    const [fullName, setFullName] = useState('');
    const [registerEmail, setRegisterEmail] = useState('');
    const [registerPassword, setRegisterPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const [loginEmail, setLoginEmail] = useState('');
    const [loginPassword, setLoginPassword] = useState('');

    const registerLink = () => {
        setAction(' active');
    }

    const loginLink = () => {
        setAction('');
    }

    const handleLogin = async (e) => {
        e.preventDefault();

        const payload = {

        }
    }

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
            const response = await fetch("https://localhost:7290/api/user", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(payload),
            });

            if (response.ok) {
                alert("User registered successfully!");
                // Optionally, switch back to login
                setAction('');
            } else {
                const error = await response.json();
                alert("Registration failed: " + (error.message || response.statusText));
            }
        } catch (err) {
            alert("Something went wrong during registration.");
            console.error(err);
        }
    };


    return (
        <div className={`wrapper${action}`}>
            <div className="form-box login">
                <form action="">
                    <h1>Login</h1>

                    <div className="input-box">
                        <input type="text" placeholder="Email Id" required />
                        <MdEmail className='icon'/>
                    </div>
                    <div className="input-box">
                        <input type="password" placeholder="Password" required />
                        <FaLock className='icon'/>
                    </div>

                    <button type="submit">Login</button>
                    <div className="register-link">
                        <p>New to Sky Mirror? <a href="#" onClick={registerLink}>Register</a></p>
                    </div>
                </form>
            </div>

            <div className="form-box register">
                <form onSubmit={handleRegister}>
                    <h1>Registration</h1>

                    <div className="input-box">
                        <input type="text" placeholder="Full Name" required value={fullName} onChange={(e) => setFullName(e.target.value)} />
                        <FaUser className='icon' />
                    </div>
                    <div className="input-box">
                        <input type="text" placeholder="Email Id" required value={registerEmail} onChange={(e) => setRegisterEmail(e.target.value)} />
                        <MdEmail className='icon' />
                    </div>
                    <div className="input-box">
                        <input type="password" placeholder="Password" required value={registerPassword} onChange={(e) => setRegisterPassword(e.target.value)} />
                        <FaLock className='icon' />
                    </div>
                    <div className="input-box">
                        <input type="password" placeholder="Confirm Password" required value={confirmPassword} onChange={(e) => setConfirmPassword(e.target.value)}/>
                        <RiLockPasswordFill className='icon' />
                    </div>


                    <button type="submit">Register</button>
                    <div className="register-link">
                        <p>Already using Sky Mirror? <a href="#" onClick={loginLink}>Login</a></p>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default Login;