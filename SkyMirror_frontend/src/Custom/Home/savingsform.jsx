import React, { useState } from 'react';

const SavingsForm = () => {
    const [location, setLocation] = useState('');
    const [savings, setSavings] = useState(null);
    const [formData, setFormData] = useState({ name: '', email: '' });

    const calculateSavings = () => {
        if (!location.trim()) {
            alert('Please enter a city or ZIP code');
            return;
        }

        const base = 1500;
        const randomFactor = Math.random() * 0.5 + 0.75;
        const monthly = Math.round(base * randomFactor);
        const yearly = monthly * 12;

        setSavings({ monthly, yearly });
    };

    const handleLeadSubmit = (e) => {
        e.preventDefault();
        if (!formData.name || !formData.email) {
            alert('Please fill out your name and email.');
            return;
        }

        // Here you can POST the formData to your backend API
        console.log('Lead Submitted:', formData);
        alert('Thank you! Your savings report will be emailed soon.');
    };

    return (
        <div className="form-wrapper">
            <div className="input-group">
                <input
                    type="text"
                    placeholder="Enter City or ZIP Code"
                    value={location}
                    onChange={(e) => setLocation(e.target.value)}
                />
                <button onClick={calculateSavings}>Check Savings</button>
            </div>

            {savings && (
                <div className="savings-output">
                    <h2>Estimated Savings</h2>
                    <p>Monthly Savings: ?{savings.monthly}</p>
                    <p>Yearly Savings: ?{savings.yearly}</p>
                </div>
            )}

            <form onSubmit={handleLeadSubmit} className="lead-form">
                <h3>Get Detailed Report on Email</h3>
                <input
                    type="text"
                    placeholder="Your Name"
                    value={formData.name}
                    onChange={(e) => setFormData({ ...formData, name: e.target.value })}
                    required
                />
                <input
                    type="email"
                    placeholder="Your Email"
                    value={formData.email}
                    onChange={(e) => setFormData({ ...formData, email: e.target.value })}
                    required
                />
                <button type="submit">Get Free Savings Report</button>
            </form>
        </div>
    );
};

export default SavingsForm;
