import React, { useState } from 'react';
import './Sidebar.css';
import { FaArrowAltCircleLeft } from "react-icons/fa";
import { FaArrowAltCircleRight } from "react-icons/fa";
import logo from '../../Images/Sky Mirror Logo.png'; 
import { ImProfile } from "react-icons/im";
import { CgBrowse } from "react-icons/cg";
import { GoHistory } from "react-icons/go";
import { FaRegNewspaper } from "react-icons/fa";
import { BsCashCoin } from "react-icons/bs";
import { RiSettingsLine } from "react-icons/ri";
import { TbHelpSquareRounded } from "react-icons/tb";
import { AiOutlineLogout } from "react-icons/ai";
import { RiHome9Line } from "react-icons/ri";
import { Link } from 'react-router-dom';


const Sidebar = () => {
    const [isOpen, setIsOpen] = useState(true);

    const toggleSidebar = () => {
        setIsOpen(!isOpen);
    };

    return (
        <div className={`sidebar ${isOpen ? 'open' : 'closed'}`}>
            <button className="toggle-btn" onClick={toggleSidebar}>
                <img src={logo} alt="Logo" className="toggle-logo" />
                <br></br>
                {isOpen ?
                    <FaArrowAltCircleLeft /> : <FaArrowAltCircleRight />}
            </button>
            <nav className="nav">
                <ul>
                    <li>
                        <Link to="/home">
                            <RiHome9Line className="icons"/> <b>Home</b>
                        </Link>
                    </li>
                    <li><a href="#"><ImProfile className="icons"/> <b>Profile</b></a></li>
                    <li>
                        <Link to="/products">
                            <CgBrowse className="icons" /> <b>Browse Panels</b>
                        </Link>
                    </li>
                    <li><a href="#"><GoHistory className="icons"/> <b>Orders</b></a></li>
                    <li><a href="#"><FaRegNewspaper className="icons"/> <b>Quotations</b></a></li>
                    <li><a href="#"><BsCashCoin className="icons"/> <b>Payment History</b></a></li>
                </ul>

                <ul className="logout-section">
                    <li><a href="#"><RiSettingsLine className="icons"/> <b>Settings</b></a></li>
                    <li><a href="#"><TbHelpSquareRounded className="icons"/> <b>Help</b></a></li>
                    <li><a href="#"><AiOutlineLogout className="icons"/> <b>Logout</b></a></li>
                </ul>
            </nav>
        </div>
    );
};

export default Sidebar;
