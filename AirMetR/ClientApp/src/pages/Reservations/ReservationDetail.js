import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams, useNavigate, Link } from 'react-router-dom';
import { getReservationDetails } from '../../API/ReservationApi';

function ReservationDetail() {
    let { id } = useParams();

    let navigate = useNavigate();

    const [reservation, setReservation] = useState();
    const [customer, setCustomer] = useState();
    const [error, setError] = useState(null);

    useEffect(() => {

        const fetchData = async () => {
            try {
                const data = await getReservationDetails(id);
                setReservation(data.reservation);
                setCustomer(data.customer);
            } catch (err) {
                console.error('Error fetching data:', err);
                setError(err);
            }
        };

        fetchData();
    }, []);



    if (!reservation) {
        return <div>Loading...</div>; // Or any other loading state
    }
    return (
        <div>
            <dl className="row">
                <dt className="col-sm-2">The property:</dt>
                <dd className="col-sm-10">
                    <Link to={`/property/${reservation.propertyId}`}>
                        The Property Details
                    </Link>
                </dd>

                {/* Render other details similarly */}
                <dt className="col-sm-2">Customer Name:</dt>
                <dd className="col-sm-10">{reservation.customer.name || 'Not Available'}</dd>

                <dt className="col-sm-2">Customer Age:</dt>
                <dd className="col-sm-10">{reservation.customer.age || 'Not Available'}</dd>

                <dt className="col-sm-2">Customer Address:</dt>
                <dd className="col-sm-10">{reservation.customer.address || 'Not Available'}</dd>

                <dt className="col-sm-2">Customer Phone:</dt>
                <dd className="col-sm-10">{reservation.customer.phoneNumber || 'Not Available'}</dd>

                <dt className="col-sm-2">Customer Email:</dt>
                <dd className="col-sm-10">{reservation.customer.email || 'Not Available'}</dd>

                <dt className="col-sm-2">Start Date:</dt>
                <dd className="col-sm-10">{new Date(reservation.startDate).toLocaleDateString()}</dd>

                <dt className="col-sm-2">End Date:</dt>
                <dd className="col-sm-10">{new Date(reservation.endDate).toLocaleDateString()}</dd>

                <dt className="col-sm-2">Number of Guests:</dt>
                <dd className="col-sm-10">{reservation.numberOfGuests}</dd>
            </dl>
            <div>
                <button onClick={() => navigate(`/reservations/list/${reservation.propertyId}`)} className="btn btn-secondary">Back</button>
            </div>
        </div>
    );
};

export default ReservationDetail;
