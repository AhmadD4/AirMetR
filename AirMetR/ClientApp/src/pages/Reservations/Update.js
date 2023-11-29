import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useNavigate, useParams } from 'react-router-dom'; // Import useParams
import Swal from 'sweetalert2';
import { getReservationDetails, getUnavailableDates, putInReservation } from '../../API/ReservationApi';
import { getPropertyDetails } from '../../API/Services';

const UpdateReservation = () => {
    let { id } = useParams(); // Extract the reservation ID from the URL

    let navigate = useNavigate();
    const [reservation, setReservation] = useState();
    const [startDate, setStartDate] = useState('');
    const [endDate, setEndDate] = useState('');
    const [pricePerNight, setPricePerNight] = useState(0);
    const [totalPrice, setTotalPrice] = useState(0);
    const [totalDays, setTotalDays] = useState(0);
    const [numberOfGuests, setNumberOfGuests] = useState(1);
    const [unavailableDates, setUnavailableDates] = useState([]);
    const [formError, setFormError] = useState(""); // State to store the error message

    // Function to fetch unavailable dates
    const fetchUnavailableDates = async () => {
        try {
            const data = await getUnavailableDates(id);
            setUnavailableDates(data.unavailableDates);
        } catch (error) {
            console.error('Error fetching unavailable dates:', error);
        }
    };

    // Fetch the existing reservation details
    useEffect(() => {
        const fetchData = async () => {
            try {
                const data = await getReservationDetails(id);
                setReservation(data.reservation);
            } catch (error) {
                console.error('Error fetching data:', error);
                setFormError(error);
            }
        };
        fetchData();
    }, []);

    useEffect(() => {
        const fetchPropertyData = async () => {
            try {
                const data = await getPropertyDetails(id);
                setPricePerNight(data.property.price);
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        }
        fetchPropertyData();
        // Calculate total price when dates change
        const start = new Date(startDate);
        const end = new Date(endDate);
        const timeDiff = end - start;
        const days = Math.ceil(timeDiff / (1000 * 3600 * 24));
        if (days > 0) {
            setTotalPrice(days * pricePerNight);
        }
        setTotalDays(days);
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
    console.log()
    const handleSubmit = async (event) => {
        event.preventDefault();
        setFormError(""); // Reset any existing errors
        if (isDateRangeUnavailable(startDate, endDate)) {
            setFormError("Unavailable dates. Please try again.");
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
        formData.append('propertyId', reservation.propertyId);
        formData.append('totalPrice', totalPrice);
        formData.append('totalDays', totalDays);

        try {
            await putInReservation(id, formData);
            Swal.fire({
                position: "top-end",
                icon: "success",
                title: "Your reservation has been updated",
                showConfirmButton: false,
                timer: 1500
            });
            navigate('/reservations');
        } catch (error) {
            console.error('Error updating reservation:', error);
            if (error) {
                setFormError(error.message || "An error occurred. Please try again.");
            }
        }
        
    };
    const handleCancel = () => {
        navigate('/reservations'); // Redirect to reservations page
    };

    return (
        <div>
            <h2>Update</h2>
            <form onSubmit={handleSubmit}>
                {formError && <div className="alert alert-danger" role="alert">{formError}</div>}
                <div className="form-group">
                    <label htmlFor="startDate">Start Date:</label>
                    <input
                        type="date"
                        className="form-control"
                        id="startDate"
                        value={startDate}
                        onChange={(e) => setStartDate(e.target.value)}
                        required />
                </div>

                <div className="form-group">
                    <label htmlFor="endDate">End Date:</label>
                    <input
                        type="date"
                        className="form-control"
                        id="endDate"
                        value={endDate}
                        onChange={(e) => setEndDate(e.target.value)}
                        required />
                </div>

                <div className="form-group">
                    <label htmlFor="numberOfGuests">Number of Guests:</label>
                    <input
                        type="number"
                        className="form-control"
                        id="numberOfGuests"
                        value={numberOfGuests}
                        onChange={(e) => setEndDate(e.target.value)}
                        required />
                </div>

                <button type="submit" className="btn btn-primary">Save Changes</button>
                <button type="button" className="btn btn-secondary" onClick={handleCancel}>Cancel</button>
                {totalPrice > 0 && (
                    <dl className="row mx-auto text-left" id="totalPrice">
                        <dt className="col-sm-7 fw-lighter">{pricePerNight.toFixed(2)} NOK x {((new Date(endDate) - new Date(startDate)) / (1000 * 3600 * 24)).toFixed(0)} nights</dt>
                        <dd className="col-sm-5 fw-bold">{totalPrice.toFixed(2)} NOK</dd>
                    </dl>
                )}
            </form>
        </div>
        
            
    );
};

export default UpdateReservation;

