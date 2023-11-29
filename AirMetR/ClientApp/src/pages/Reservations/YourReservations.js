import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';

const YourReservations = () => {
    const [reservations, setReservations] = useState([]);
    const [customers, setCustomers] = useState([]);
    const [loading, setLoading] = useState(true);
    const [properties, setProperties] = useState([]);

    const getReservations = async () => {
        try {
            const res = await axios.get('http://localhost:47251/api/Reservation/Reservation');
            setReservations(res.data.reservations);
            setCustomers(res.data.customerInfo);

            // Extract unique propertyIds
            const propertyIds = [...new Set(res.data.reservations.map(r => r.propertyId))];
            console.log(propertyIds);


            // Fetch property details for each unique propertyId
            const propertiesPromises = propertyIds.map(id => axios.get(`http://localhost:47251/api/Property/Details/${id}`));
            const propertiesResponses = await Promise.all(propertiesPromises);

            // Map properties to an object for easy access
            const propertiesData = propertiesResponses.reduce((acc, curr) => {
                acc[curr.data.propertyId] = curr.data;
                return acc;
            }, {});

            setProperties(propertiesData);
        } catch (error) {
            console.error('Error fetching reservations:', error);
        } finally {
            setLoading(false);
        }
    };


    useEffect(() => {
        getReservations();
    }, []);

    if (loading) {
        return <div>Loading reservations...</div>;
    }

    if (!reservations || reservations.length === 0) {
        return <div>No reservations available.</div>;
    }
    console.log(reservations);
    return (
        <div>
            <h1>My Reservation</h1>
            <table className="table">
                <thead>
                    <tr>
                        <th>Property</th>
                        <th>Address</th>
                        <th>Start Date</th>
                        <th>End Date</th>
                        <th>Number of Guests</th>
                        <th>Total Days</th>
                        <th>Price per Night</th>
                        <th>Total Price</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {reservations.map((reservation) => {
                        // Find the corresponding property for this reservation
                        const property = properties[reservation.propertyId];

                        return (

                            <tr key={reservation.reservationId}>
                                <td>
                                    <Link to={`/property/${reservation.propertyId}`}>
                                        {property.title || 'Not Available'}
                                    </Link>
                                </td>
                                <td>{property.address || 'Not Available'}</td>
                                <td>{new Date(reservation.startDate).toLocaleDateString()}</td>
                                <td>{new Date(reservation.endDate).toLocaleDateString()}</td>
                                <td>{reservation.numberOfGuests}</td>
                                <td>{reservation.totalDays}</td>
                                <td>{property.price || 'Not Available'}</td>
                                <td>{reservation.totalPrice}</td>
                                <td>
                                    <Link to={`/reservation/update/${reservation.reservationId}`}>Update</Link>
                                    {" | "}
                                    <Link to={`/reservation/delete/${reservation.reservationId}`}>Delete</Link>
                                </td>
                            </tr>
                        );
                    })}
                </tbody>
            </table>
        </div>
    );
};

export default YourReservations;

