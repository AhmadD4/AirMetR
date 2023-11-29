﻿import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import Swal from 'sweetalert2';

const PropertyReservation = ({ id }) => {


    let navigate = useNavigate(); // This is for redirecting for the cancel action
    const [startDate, setStartDate] = useState('');
    const [endDate, setEndDate] = useState('');
    const [pricePerNight, setPricePerNight] = useState(0);
    const [totalPrice, setTotalPrice] = useState(0);
    const [numberOfGuests, setNumberOfGuests] = useState(1);
    const [unavailableDates, setUnavailableDates] = useState([]);

    // Function to fetch unavailable dates
    const fetchUnavailableDates = async () => {
        try {
            const response = await axios.get(`http://localhost:47251/api/Reservation/GetUnavailableDates/${id}`);
            setUnavailableDates(response.data.unavailableDates);
            console.log("UnavailableDates: ", unavailableDates);
            console.log("UnavailableDates: ", response.data);
        } catch (error) {
            console.error('Error fetching unavailable dates:', error);
        }
    };

    useEffect(() => {
        axios.get(`http://localhost:47251/api/Property/Details/${id}`)
            .then(response => {
                setPricePerNight(response.data.property.price);
                console.log(response.data.price);
            })
            .catch(error => {
                console.log(pricePerNight);
                console.error('Error fetching data:', error);
            });
    }, []);

    useEffect(() => {
        // Initialize dates to default values
        const today = new Date();
        const threeDaysLater = new Date(today.getTime() + 3 * 24 * 60 * 60 * 1000);
        const tenDaysLater = new Date(today.getTime() + 10 * 24 * 60 * 60 * 1000);
        setStartDate(threeDaysLater.toISOString().split('T')[0]);
        setEndDate(tenDaysLater.toISOString().split('T')[0]);
    }, []);

    useEffect(() => {
        // Calculate total price when dates change
        const start = new Date(startDate);
        const end = new Date(endDate);
        const timeDiff = end - start;
        const days = Math.ceil(timeDiff / (1000 * 3600 * 24));
        if (days > 0) {
            setTotalPrice(days * pricePerNight);
        }

        fetchUnavailableDates();
    }, [startDate, endDate, pricePerNight]);

    const isDateUnavailable = (date) => {
        return unavailableDates.includes(date);
    };

    const isDateRangeUnavailable = (startDate, endDate) => {
        let start = new Date(startDate);
        let end = new Date(endDate);
        for (let dt = new Date(start); dt <= end; dt.setDate(dt.getDate() + 1)) {
            // Format date to 'YYYY-MM-DD'
            let formattedDate = dt.toISOString().split('T')[0];
            console.log(dt);
            if (isDateUnavailable(formattedDate)) {

                console.log(formattedDate);
                return true;
            }
        }
        return false;
    };

    const handleSubmit = (event) => {

        console.log({ id, startDate, endDate, totalPrice });
        event.preventDefault();
        // Check if any date in the selected range is unavailable
        if (isDateRangeUnavailable(startDate, endDate)) {
            Swal.fire({
                icon: "error",
                title: "Oops...",
                text: "One or more selected dates are unavailable. Please choose different dates.",
                footer: "Unavailable dates are: " + unavailableDates.join(', ')
            });
            return;
        }
        const formData = new FormData();
        formData.append('startDate', startDate);
        formData.append('endDate', endDate);
        formData.append('numberOfGuests', numberOfGuests);

        for (let [key, value] of formData.entries()) {
            console.log(key, value);
        }

        axios.post(`http://localhost:47251/api/Reservation/CompleteReservation/${id}`, formData)
            .then(response => {
                // Handle successful submission
                console.log('Success:', response.data);
                Swal.fire({
                    position: "top-end",
                    icon: "success",
                    title: "Your reservation has been approved",
                    showConfirmButton: false,
                    timer: 1500
                });
                navigate('/reservations'); // Redirect to a success page, or home, etc.
            })
            .catch(error => {
                // Handle errors
                console.error('Error submitting form:');
            });
    };

    return (
        <div className="col-md-6">
            <div className="property-description">
                <span className="d-inline-block property-price" id="singleDayPrice">
                    {pricePerNight.toFixed(2)} NOK <span className="text-muted fs-6">night</span>
                </span>

                <form onSubmit={handleSubmit}>
                    <div className="form-group text-left">
                        <label htmlFor="reservationDate">Start Date:</label>
                        <input
                            type="date"
                            className="form-control"
                            id="reservationDate"
                            required
                            min={new Date().toISOString().split('T')[0]}
                            value={startDate}
                            onChange={(e) => setStartDate(e.target.value)}
                        />
                    </div>
                    <div className="form-group text-left">
                        <label htmlFor="endReservationDate">End Date:</label>
                        <input
                            type="date"
                            className="form-control"
                            id="endReservationDate"
                            required
                            min={new Date().toISOString().split('T')[0]}
                            value={endDate}
                            onChange={(e) => setEndDate(e.target.value)}
                        />
                    </div>
                    <div className="form-group text-left">
                        <label htmlFor="numberOfGuests">Number of Guests:</label>
                        <input type="number" className="form-control number-resize" min="1" id="numberOfGuests"
                            value={numberOfGuests}
                            onChange={(e) => setNumberOfGuests(e.target.value)}
                            required />
                    </div>
                    <button type="submit" id="Reserve" className="btn btn-danger">Reserve</button>
                </form>

                {totalPrice > 0 && (
                    <dl className="row mx-auto text-left" id="totalPrice">
                        <dt className="col-sm-7 fw-lighter">{pricePerNight.toFixed(2)} NOK x {((new Date(endDate) - new Date(startDate)) / (1000 * 3600 * 24)).toFixed(0)} nights</dt>
                        <dd className="col-sm-5 fw-bold">{totalPrice.toFixed(2)} NOK</dd>
                    </dl>
                )}
            </div>
        </div>
    );
};
export default PropertyReservation;

