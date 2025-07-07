import React, { useState } from 'react';
import './HomePage.css';
import Sidebar from './sidebar.jsx';
import SavingsForm from './savingsform.jsx';
import backgroundImage from '../../Images/home page background.jpg'; 

function HomePage() {
    return (

        <div className="home-page-wrapper">
            <div
                className="background"
                style={{ backgroundImage: `url(${backgroundImage})` }}
            />
            <Sidebar />
            <main className="home-page-content">
                <header className="hero">
                    <h1>See How Much You Can Save in Your City</h1>
                    <p>Enter your city or ZIP code to get a free solar savings report.</p>
                    <SavingsForm />
                </header>
            </main>
        </div>
    );
}

export default HomePage;