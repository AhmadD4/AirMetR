import React, { useState, useEffect } from 'react';
import { Link, useParams, useNavigate } from 'react-router-dom';
import { getPropertyDetails } from '../../API/Services';
import { getAllResByPropertyId } from '../../API/ReservationApi';

const ReservationsList = () => {
    let { id } = useParams();

    let navigate = useNavigate(); // This is for redirecting for the cancel action

    const [reservations, setReservations] = useState([]);
    const [properties, setProperties] = useState([]);
    const [loading, setLoading] = useState(true);

    const getReservations = async () => {
        try {
            const data = await getAllResByPropertyId(id);
            setReservations(data.reservations);

            // Extract unique propertyIds
            const propertyIds = [...new Set(data.reservations.map(r => r.propertyId))];
            // Fetch property details for each unique propertyId
            const propertiesPromises = propertyIds.map(id => getPropertyDetails(id));
            const propertiesResponses = await Promise.all(propertiesPromises);
            // Extract property information from each response
            const propertiesData = propertiesResponses.reduce((acc, curr, index) => {
                const propertyInfo = curr.property; // Assuming property information is in curr.property

                if (propertyInfo) {
                    const propertyId = propertyIds[index];
                    acc[propertyId] = propertyInfo;
                }

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
        // If reservations is null or empty, display a message
        return <div>No reservations available.</div>;
    }
    else {
        return (
            <div>
                <h1>The Reservations</h1>
                <table className="table">
                    <thead>
                        <tr>
                            <th>Property</th>
                            <th>Address</th>
                            <th>Customer Name</th>
                            <th>Start Date</th>
                            <th>End Date</th>
                            <th>Number of Guests</th>
                            <th>Total Days</th>
                            <th>Price per Night</th>
                            <th>Total Price</th>
                            <th>Details</th>
                        </tr>
                    </thead>
                    <tbody>
                        {reservations.map(reservation => {

                            // Find the corresponding property for this reservation
                            const property = properties[reservation.propertyId];
                            // Convert the start and end dates from string to Date objects
                            const startDate = new Date(reservation.startDate);
                            const endDate = new Date(reservation.endDate);

                            // Calculate the total days
                            const timeDiff = endDate - startDate; // Difference in milliseconds
                            const totalDays = Math.ceil(timeDiff / (1000 * 60 * 60 * 24)); // Convert milliseconds to days

                            // Calculate the total price
                            const totalPrice = property.price * totalDays;


                            return (
                                <tr key={reservation.reservationId}>
                                    <td>
                                        <Link to={`/property/${reservation.propertyId}`}>
                                            {property.title}
                                        </Link>
                                    </td>
                                    <td>{property.address}</td>
                                    <td>{reservation.customer.name}</td>
                                    <td>{new Date(reservation.startDate).toLocaleDateString()}</td>
                                    <td>{new Date(reservation.endDate).toLocaleDateString()}</td>
                                    <td>{reservation.numberOfGuests}</td>
                                    <td>{totalDays}</td>
                                    <td>{property.price}</td>
                                    <td>{totalPrice}</td>
                                    <td>
                                        <Link to={`/reservation/detail/${reservation.reservationId}`}>Details</Link>
                                    </td>
                                </tr>
                            );
                        })}
                            
                    </tbody>
                </table>
                <div>
                    <button onClick={() => navigate('/properties/2')} className="btn btn-secondary">Back</button>
                </div>
            </div>
        );
    }
    
}

export default ReservationsList;
