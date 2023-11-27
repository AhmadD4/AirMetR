import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Carousel, ThumbNail } from '../components/Carousel';
import { useParams } from 'react-router-dom'; // Import useParams
import './Details.css';
import AmenitiesList from '../components/AmenitiesList';


function PropertyDetail() {
    const [property, setProperty] = useState();
    let { id } = useParams();

    useEffect(() => {
        axios.get(`http://localhost:47251/api/Property/Details/${id}`)
        .then(response => {
            setProperty(response.data);
            console.log(response.data);
        })
            .catch(error => {
                console.log(property);
                console.error('Error fetching data:', error);
            });
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
                        <h3>{property.pType.pTypeName} hosted by {property.customer}</h3>
                        <span className="property-info-item">Guests: {property.guest}</span>
                        <span className="property-info-item">Bed: {property.bed}</span>
                        <span className="property-info-item">Bedrooms: {property.bedRooms}</span>
                        <span className="property-info-item">Bathrooms: {property.bathRooms}</span>
                        <p className="fs-5 border-bottom border-2 mb-4 space">{property.description}</p>

                    </div>
                    <AmenitiesList propertyAmenities={property.propertyAmenities}></AmenitiesList>
                </div>
            </div>
            
        </div>

    );
};

export default PropertyDetail;