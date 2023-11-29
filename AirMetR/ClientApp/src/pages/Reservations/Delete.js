import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams, useNavigate } from 'react-router-dom';
import { Link } from 'react-router-dom';
import Swal from 'sweetalert2';

function DeleteReservation() {
    let navigate = useNavigate();
    let { id } = useParams();
    const [reservation, setReservation] = useState(null);
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        axios.get(`http://localhost:47251/api/Reservation/Details/${id}`)
            .then(response => {
                setReservation(response.data.reservation);
                console.log(response.data);
                console.log(reservation);
                setIsLoading(false);
            })
            .catch(err => {
                setError(err.message);
                setIsLoading(false);
            });
    }, [id]);

    const handleDelete = () => {
        Swal.fire({
            title: "Are you sure?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Yes, delete it!"
        }).then((result) => {
            if (result.isConfirmed) {
                axios.delete(`http://localhost:47251/api/Reservation/DeleteReservation/${id}`)
                    .then(() => {
                        Swal.fire({
                            title: "Deleted!",
                            text: "Your file has been deleted.",
                            icon: "success"
                        });
                        navigate('/reservations');
                    })
                    .catch(err => {
                        setError(err.message);
                    });
            }
        });

    };

    if (isLoading) return <div>Loading...</div>;
    if (error) return <div>Error: {error}</div>;
    if (!reservation) return <div>Property not found.</div>;

    return (
        <div className="container">
            <h2>Delete</h2>
            <h3>Are you sure you want to delete this item?</h3>
            <div>
                <dl className="row">
                    <dt className="col-sm-2">The Property</dt>
                    <dd className="col-sm-10"><Link to={`/property/${reservation.propertyId}`}>
                        Details
                    </Link></dd>

                    <dt className="col-sm-2">Start Date:</dt>
                    <dd className="col-sm-10">{reservation.startDate}</dd>

                    <dt className="col-sm-2">End Date:</dt>
                    <dd className="col-sm-10">{reservation.endDate}</dd>

                    <dt className="col-sm-2">Number of Guests:</dt>
                    <dd className="col-sm-10">{reservation.numberOfGuests}</dd>
                </dl>


                <div>
                    <button onClick={handleDelete} className="btn btn-danger">Delete</button>
                    <button onClick={() => navigate('/reservations')} className="btn btn-secondary">Cancel</button>
                </div>
            </div>
        </div>
    );
}

export default DeleteReservation;

