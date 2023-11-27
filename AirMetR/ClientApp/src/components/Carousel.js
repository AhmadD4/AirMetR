import React from 'react';
import './Carousel.css';

function Carousel({ property }) {
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

function ThumbNail({ property }) {
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
export { Carousel, ThumbNail };