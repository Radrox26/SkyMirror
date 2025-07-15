import React, { useState } from 'react';
import './panelRequirementForm.css'; // External CSS file
import { PiMaskSadLight } from "react-icons/pi";
import { PiMaskHappy } from "react-icons/pi";
import { FaAngry } from "react-icons/fa";



function panelRequirementForm() {
    const [zipCode, setZipCode] = useState('');
    const [selectedOption, setSelectedOption] = useState('');
    const [inputValue, setInputValue] = useState('');
    const [availabilityMessage, setAvailabilityMessage] = useState(null);
    const [isAvailable, setIsAvailable] = useState(null); 


    const handleAvailability = () => {

        if (zipCode == '' || zipCode == null) {
            setAvailabilityMessage(
                <span className="not-available">
                    Please enter the valid zip code. <FaAngry className="icon"/>
                </span>
            );
            setIsAvailable(false);
            return;
        }

        if (zipCode !== '440025') {
            setAvailabilityMessage(
                <span className="not-available">
                    Sorry, we are not available at this location at the moment. <PiMaskSadLight className="icon"/>
                </span>
            );
            setIsAvailable(false);
            return;
        }

        setAvailabilityMessage(
            <span className="available">
                Cudos! We are available at your location. Please check the panel requirement below. <PiMaskHappy className="icon" />
            </span>
        );
        setIsAvailable(true);
    };


    const handleNumberOfPanelsRequired = () => {
        let numberOfPanelsRequired = 0;
        const numericValue = parseFloat(inputValue);

        if (isNaN(numericValue)) {
            alert("Please enter a valid number.");
            return;
        }

        switch (selectedOption) {
            case 'units':
                let unitsPerDay = numericValue / 30;
                numberOfPanelsRequired = (unitsPerDay / 4) * 2;
                break;
            case 'bill':
                let units = estimateUnitsFromBill(numericValue);
                let unitPerDay = numericValue / 30;
                numberOfPanelsRequired = (unitPerDay / 4) * 2;
                break;
            case 'area':
                numberOfPanelsRequired = numericValue / 32;
                break;
            default:
                alert("Please select a method to calculate savings.");
                return;
        }

        alert(`Estimated number of Solar Panels required = ${Math.ceil(numberOfPanelsRequired)}`)
    };

    const estimateUnitsFromBill = (billAmount) => {
        const slabs = [
            { maxUnits: 100, rate: 4.96 },
            { maxUnits: 200, rate: 10.69 },
            { maxUnits: 200, rate: 16.10 },
            { maxUnits: Infinity, rate: 17.24 }
        ];

        let remainingBill = billAmount;
        let units = 0;
        let slabIndex = 0;

        while (remainingBill > 0 && slabIndex < slabs.length) {
            const slab = slabs[slabIndex];
            const maxAffordableUnits = remainingBill / slab.rate;
            const unitsInThisSlab = Math.min(slab.maxUnits, maxAffordableUnits);

            const roundedUnits = Math.floor(unitsInThisSlab);
            units += roundedUnits;
            remainingBill -= roundedUnits * slab.rate;

            slabIndex++;
        }

        return units;
    };

    const getInputLabel = () => {
        switch (selectedOption) {
            case 'units':
                return 'Enter Average Number of units per month';
            case 'bill':
                return 'Enter Average Bill Generated per month';
            case 'area':
                return 'Enter Total area available for Panels';
            default:
                return 'Enter appropriate value.';
        }
    };

    return (
        <div className="form-wrapper">
            <h3>Please enter your city name or Zip Code.</h3>
            <input
                type="text"
                placeholder="Enter your zip code here"
                value={zipCode}
                onChange={e => setZipCode(e.target.value)}
                className="input-field"
            />
            <button onClick={handleAvailability} className="green-button">
                Check availability
            </button>

            {availabilityMessage && (
                <div className="availability-message">
                    {availabilityMessage}
                </div>
            )}


            <h3>How do you want to calculate your savings?</h3>
            <div className="radio-group">
                <label>
                    <input
                        type="radio"
                        name="method"
                        value="units"
                        checked={selectedOption === 'units'}
                        onChange={() => setSelectedOption('units')}
                    />
                    Average number of units per month
                </label>
                <label>
                    <input
                        type="radio"
                        name="method"
                        value="bill"
                        checked={selectedOption === 'bill'}
                        onChange={() => setSelectedOption('bill')}
                    />
                    Average bill generated per month
                </label>
                <label>
                    <input
                        type="radio"
                        name="method"
                        value="area"
                        checked={selectedOption === 'area'}
                        onChange={() => setSelectedOption('area')}
                    />
                    Total area available for panels
                </label>
            </div>

            <h3>{getInputLabel()}</h3>
            <input
                type="text"
                placeholder="Enter your details here"
                value={inputValue}
                onChange={e => setInputValue(e.target.value)}
                className="input-field"
            />
            <button
                onClick={handleNumberOfPanelsRequired}
                className="green-button"
                disabled={zipCode !== '440025'}
                style={{
                    opacity: zipCode !== '440025' ? 0.5 : 1,
                    cursor: zipCode !== '440025' ? 'not-allowed' : 'pointer'
                }}
            >
                Check requirement
            </button>
        </div>
    );
}

export default panelRequirementForm;
