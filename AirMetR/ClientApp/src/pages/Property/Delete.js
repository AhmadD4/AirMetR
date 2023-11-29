import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams, useNavigate } from 'react-router-dom';
import { Carousel } from '../../components/Carousel';
import Swal from 'sweetalert2';
import { deleteProperty } from '../../API/Services';
import { getPropertyDetails } from '../../API/Services';
import AmenitiesList from '../../components/AmenitiesList';

function DeleteProperty() {
    let navigate = useNavigate();
    let { id } = useParams();
    const [property, setProperty] = useState(null);
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const data = await getPropertyDetails(id);
                setProperty(data.property);
            } catch (err) {
                setError(err.message);
            }
        };
        fetchData();
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
                    await deleteProperty(id);
                    Swal.fire({
                        title: "Deleted!",
                        text: "Your file has been deleted.",
                        icon: "success"
                    });
                    navigate('/properties/2');
                } catch (error) {
                    setError(error.message);
                }
            }
        });
        
    };

    //if (isLoading) return <div>Loading...</div>;
    if (error) return <div>Error: {error}</div>;
    if (!property) return <div>Property not found.</div>;

    return (
        <div className="container">
            <h2>Delete</h2>
            <h3>Are you sure you want to delete this item?</h3>
            <div>
                <dl className="row">
                    <dt className="col-sm-2">Title</dt>
                    <dd className="col-sm-10">{property.title}</dd>

                    <dt className="col-sm-2">Address</dt>
                    <dd className="col-sm-10">{property.address}</dd>

                    <dt className="col-sm-2">Type</dt>
                    <dd className="col-sm-10">{property.pType && property.pType.pTypeName}</dd>

                    <dt className="col-sm-2">Guest</dt>
                    <dd className="col-sm-10">{property.guest}</dd>

                    <dt className="col-sm-2">Bed</dt>
                    <dd className="col-sm-10">{property.bed}</dd>

                    <dt className="col-sm-2">Bedrooms</dt>
                    <dd className="col-sm-10">{property.bedRooms}</dd>

                    <dt className="col-sm-2">Bathrooms</dt>
                    <dd className="col-sm-10">{property.bathRooms}</dd>

                    {property.propertyAmenities && (
                        <div>
                            <dt className="col-sm-2">Amenities</dt>
                            <dd className="col-sm-10">
                                <div className="grid grid--cols2to3">
                                    <AmenitiesList propertyAmenities={property.propertyAmenities}></AmenitiesList>
                                </div>
                            </dd>
                        </div>
                    )}

                    <dt className="col-sm-2">Price</dt>
                    <dd className="col-sm-10">{property.price}</dd>

                    <dt className="col-sm-2">Images</dt>
                    <dd className="col-sm-10">
                        <Carousel property={property}></Carousel>
                    </dd>

                    <dt className="col-sm-2">Description</dt>
                    <dd className="col-sm-10">{property.description}</dd>
                </dl>


                <div>
                    <button onClick={handleDelete} className="btn btn-danger">Delete</button>
                    <button onClick={() => navigate('/properties/2')} className="btn btn-secondary">Cancel</button>
                </div>
            </div>
        </div>
    );
}

export default DeleteProperty;

