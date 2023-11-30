import React from 'react';
import { Link } from 'react-router-dom'; // Add this line to import Link
import { Carousel } from './Carousel';
import './PropertyCard.css';

function PropertyCard({ property }) {
    const { propertyId, images, description, address, price } = property;
    return (
        <Link to={`/property/${propertyId}`}>
            <div className="col property-card">
            
            <Carousel property={property} />
            
                <div className="card-body">
                    <h5 id="card-title" className="card-title">{address}</h5>
                    <p id="card-text" className="card-text">Price: {price.toFixed(2)} NOK</p>
            
            </div>
        </div>
        </Link >
    );
}

export default PropertyCard;
