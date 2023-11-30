import React from 'react';

function AmenitiesList({ propertyAmenities }) {
    return (
        <>
            {propertyAmenities && propertyAmenities.length > 0 && (
                <div className="col-sm-10 fs-6 mb-4">
                    <div className="row row-cols-2">
                        {propertyAmenities.map((propertyAmenity, index) => (
                            <span key={index} className="amenity-item">
                                <i className={propertyAmenity?.amenity?.amenityIcon}></i>
                                {propertyAmenity?.amenity?.amenityName}
                            </span>
                        ))}
                    </div>
                </div>
                
            )}
        </>
    );
}

export default AmenitiesList;

