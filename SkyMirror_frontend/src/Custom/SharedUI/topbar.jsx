import React from 'react';
import './TopBar.css';

function TopBar({ children }) {
    return (
        <div className="top-bar">
            {children}
        </div>
    );
}

export default TopBar;
