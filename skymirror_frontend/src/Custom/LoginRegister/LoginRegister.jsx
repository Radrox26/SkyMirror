import React, { useState } from 'react';
import './LoginRegister.css';
import { MdEmail } from "react-icons/md";
import { FaLock, FaUser } from "react-icons/fa";
import { RiLockPasswordFill } from "react-icons/ri";



function Login() {

    const [action, setAction] = useState('');

    const registerLink = () => {
        setAction(' active');
    }

    const loginLink = () => {
        setAction('');
    }

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
                <form action="">
                    <h1>Registration</h1>

                    <div className="input-box">
                        <input type="text" placeholder="Full Name" required />
                        <FaUser className='icon' />
                    </div>
                    <div className="input-box">
                        <input type="text" placeholder="Email Id" required />
                        <MdEmail className='icon' />
                    </div>
                    <div className="input-box">
                        <input type="password" placeholder="Password" required />
                        <FaLock className='icon' />
                    </div>
                    <div className="input-box">
                        <input type="password" placeholder="Confirm Password" required />
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