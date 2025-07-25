import React, { useState } from 'react';
import './HomePage.css';
import Sidebar from '../SharedUI/sidebar.jsx';
import SavingsForm from './panelRequirementForm.jsx';
import backgroundImage from '../../Images/HomePageDesignImage.jpg'; 
import TopBar from '../SharedUI/topbar.jsx';
import arrow from '../../Images/curveArrow.png';
import CartBar from '../SharedUI/cartbar.jsx';

function HomePage() {
    return (

        <div className="home-page-wrapper">
            {/* Background Image */}
            <div className="background-wrapper">
                <img src={backgroundImage} alt="bgImage" className="background-image" />
            </div>
            <TopBar >
                <div className="home-topbar-left">
                    <div className="home-scrolling-text">
                        Welcome to SkyMirror - Solar Made Easy.
                    </div>
                </div>
                <div className="home-topbar-right">
                    <p>Toll-Free: <strong>440-110231</strong></p>
                    <p>Email: <strong>skymirrorSolar@gmail.com</strong></p>
                </div>
            </TopBar>
            <CartBar></CartBar>
            <Sidebar />
            <main className="home-page-content">
                <header className="hero">
                    <h1><b>Want to know your requirement of solar panels ?</b></h1>
                    <SavingsForm />
                    <div className="arrow-wrapper">
                        <img src={arrow} alt="arrow" className="arrow" />
                        <div className="arrow-text">
                            <h2>Check here !!!</h2>
                        </div>
                    </div>
                </header>
            </main>
        </div>
    );
}

export default HomePage;