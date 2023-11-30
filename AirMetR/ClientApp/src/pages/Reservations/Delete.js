import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { Link } from 'react-router-dom';
import Swal from 'sweetalert2';
import { deleteReservation, getReservationDetails } from '../../API/ReservationApi';

function DeleteReservation() {
    let navigate = useNavigate();
    let { id } = useParams();

    const [reservation, setReservation] = useState(null);
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const data = await getReservationDetails(id);
                setReservation(data.reservation);
            } catch (error) {
                console.error('Error fetching data:', error);
                setError(error);
            }
        };
        fetchData();
        setIsLoading(false);
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
        }).then(async (result) => {
            if (result.isConfirmed) {
                try {
                    await deleteReservation(id);
                    Swal.fire({
                        title: "Deleted!",
                        text: "Your file has been deleted.",
                        icon: "success"
                    });
                    navigate('/reservations');
                } catch (error) {
                    setError(error.message);
                }
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

