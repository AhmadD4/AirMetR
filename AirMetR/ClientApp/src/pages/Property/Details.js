import React, { useState, useEffect } from 'react';
import { useParams, Link } from 'react-router-dom';
import AmenitiesList from '../../components/AmenitiesList';
import { Carousel, ThumbNail } from '../../components/Carousel';
import PropertyReservation from '../Reservations/ReservationBox';
import { getPropertyDetails } from '../../API/Services';


function PropertyDetail() {
    let { id } = useParams();

    const [property, setProperty] = useState();
    const [customer, setCustomer] = useState();
    const [error, setError] = useState(null);


    useEffect(() => {
        const fetchData = async () => {
            try {
                const data = await getPropertyDetails(id);
                setProperty(data.property);
                setCustomer(data.customerInfo);
            } catch (err) {
                setError(err.message);
            }
        };
        fetchData();

    }, []);


    if (!property) {
        return <div>Loading...</div>; // Or any other loading state
    }
    return (
        <div className="property-details-container row">
            <h3 className="col-12 fs-2">{property.title}</h3>
            <h6 className="property-address col-12 fs-5">{property.address}</h6>
            <div className="col-12 mb-3 mt-4">
                <Carousel property={property}></Carousel>
                <div className="row mt-4">
                    <ThumbNail property={property}></ThumbNail>
                </div>
            </div>
            <div className="col-md-6">
                <div className="property-additional-info">
                    <div className="border-bottom border-2 mb-4 mt-3">
                        <h3>{property.pType.pTypeName} hosted by {customer.name}</h3>
                        <span className="property-info-item">Guests: {property.guest}</span>
                        <span className="property-info-item">Bed: {property.bed}</span>
                        <span className="property-info-item">Bedrooms: {property.bedRooms}</span>
                        <span className="property-info-item">Bathrooms: {property.bathRooms}</span>
                    </div>
                        <p className="fs-5 border-bottom border-2 mb-4 space">{property.description}</p>

                    <div className="border-bottom border-2 mb-4">
                        <h4>What this place offers</h4>
                        <AmenitiesList propertyAmenities={property.propertyAmenities}></AmenitiesList>
                    </div>
                </div>
            </div>

            {/* Conditional rendering based on the customer's name */}
            {customer.customerId === "2" ? (
                <div className="col-md-6">
                    <div className="property-description">
                        <span className="d-inline-block property-price" id="singleDayPrice">{property.price} <span className="text-muted fs-6">night</span></span>
                        <div className="row row-cols-2">
                            <div className="d-block mb-3">
                                <Link to={`/property/update/${property.propertyId}`} className="btn btn-primary" role="button">
                                    Update
                                </Link>
                            </div>
                            <div className="d-block mb-3">
                                <Link to={`/property/delete/${property.propertyId}`} role="button" className="btn btn-danger">Delete</Link>
                            </div>
                            <div className="d-block mb-3">
                                <Link to={`/reservations/list/${property.propertyId}`} role="button" className="btn btn-success">Reservations</Link>
                            </div>
                        </div>
                    </div>
                </div>
            ) : (
                <PropertyReservation id={id}></PropertyReservation>
            )}

        </div>

    );
};

export default PropertyDetail;