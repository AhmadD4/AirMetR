import React from 'react';

// Carousel component to display images of a property in a carousel format.
function Carousel({ property }) {
    // Destructuring property object to get propertyId, images array, and description.
    const { propertyId, images, description } = property;
    return (
        <div id={`carousel-${propertyId}`} className="carousel slide" data-bs-ride="carousel" data-bs-interval="false">
            <div className="carousel-inner">
                {images.map((image, index) => (
                    <div key={image.imageUrl} className={`carousel-item ${index === 0 ? "active" : ""}`}>
                        <img src={image.imageUrl} className="d-block w-100" alt={description} />
                    </div>
                ))}
            </div>
            <button className="carousel-control-prev" type="button" data-bs-target={`#carousel-${propertyId}`} data-bs-slide="prev">
                <span className="carousel-control-prev-icon" aria-hidden="true"></span>
                <span className="visually-hidden">Previous</span>
            </button>
            <button className="carousel-control-next" type="button" data-bs-target={`#carousel-${propertyId}`} data-bs-slide="next">
                <span className="carousel-control-next-icon" aria-hidden="true"></span>
                <span className="visually-hidden">Next</span>
            </button>
        </div>
    );
}

// ThumbNail component to display thumbnails of a property's images.
function ThumbNail({ property }) {
    // Destructuring to get propertyId and images array from the property object.
    const { propertyId, images } = property;
    return (
        <div className="row mt-4">
            {images.map((image, index) => (
                <div key={image.imageUrl} className="col-2">
                    <img src={image.imageUrl} className="img-thumbnail" data-bs-target="#propertyCarousel" data-bs-slide-to={index} alt="Thumbnail" />
                </div>
            ))}
        </div>
    );
}

// Exporting both components for use in other parts of the application.
export { Carousel, ThumbNail };