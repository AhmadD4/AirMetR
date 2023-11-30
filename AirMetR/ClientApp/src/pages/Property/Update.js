import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { deleteImage, getUpdateData, putInProperty } from '../../API/Services';
import Swal from 'sweetalert2';


function UpdateProperty() {
    let { id } = useParams();
    let navigate = useNavigate();

    const [property, setProperty] = useState({
        customerId: 2,
        title: '',
        address: '',
        pTypeId: '',
        guest: 1,
        bed: '',
        bedRooms: '',
        bathRooms: '',
        price: '',
        description: '',
    });
    const [propertyTypes, setPropertyTypes] = useState([]);
    const [amenities, setAmenities] = useState([]);
    const [selectedAmenities, setSelectedAmenities] = useState([]);
    const [imageInputs, setImageInputs] = useState([]);
    const [formError, setFormError] = useState("");
    const [isSubmitting, setIsSubmitting] = useState(false);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const data = await getUpdateData(id);
                setProperty(data.property);
                setPropertyTypes(data.pTypes);
                setAmenities(data.amenities);

                // Set existing images
                const existingImages = data.property.images.map(img => ({
                    id: img.id, // or any unique identifier
                    preview: img.imageUrl, // URL of the image
                    existing: true // flag to indicate these are existing images
                }));
                setImageInputs(existingImages);

            } catch (err) {
                setFormError('Failed to load property data');
                setError(err.message);
            }
        };
        fetchData();
    }, [id]);

    const handleAmenityChange = (amenityId) => {
        setSelectedAmenities(prevSelected => {
            if (prevSelected.includes(amenityId)) {
                return prevSelected.filter(id => id !== amenityId);
            } else {
                return [...prevSelected, amenityId];
            }
        });
    };


    const removeImage = (index) => {
        const image = imageInputs[index];
        if (image && image.existing && image.id) {
            // Mark the image for deletion
            const newImageInputs = [...imageInputs];
            newImageInputs[index] = {
                ...newImageInputs[index],
                toBeDeleted: true
            };
            setImageInputs(newImageInputs);
        } else {
            // Remove the new image
            const newImageInputs = imageInputs.filter((_, i) => i !== index);
            setImageInputs(newImageInputs);
            if (image.preview) {
                URL.revokeObjectURL(image.preview);
            }
        }
    };

    const handleImageChange = (event, index) => {
        const file = event.target.files[0];
        if (file) {
            const newImageInputs = [...imageInputs];
            newImageInputs[index] = {
                ...newImageInputs[index],
                file: file,
                preview: URL.createObjectURL(file),
                existing: false, // Mark as new image
                toBeDeleted: false // Reset deletion flag
            };
            setImageInputs(newImageInputs);
        }
    };

    const addImageInput = () => {
        setImageInputs([...imageInputs, { file: null, preview: null, existing: false }]);
    };


    const handleSubmit = async (event) => {
        event.preventDefault();
        setIsSubmitting(true);
        setFormError("");
        const formData = new FormData();
        formData.append('title', property.title);
        formData.append('address', property.address);
        formData.append('pTypeId', property.pTypeId);
        formData.append('guest', property.guest);
        formData.append('bed', property.bed);
        formData.append('bedRooms', property.bedRooms);
        formData.append('bathRooms', property.bathRooms);
        formData.append('price', property.price);
        formData.append('description', property.description);
        formData.append('customerId', property.customerId);

        // Append selected amenities
        selectedAmenities.forEach(amenityId => {
            formData.append('selectedAmenities', amenityId);
        });


        // Append new images
        imageInputs.forEach((input) => {
            if (input.file && !input.existing) {
                formData.append('Files', input.file);
            }
        });

        // Append IDs of images to be deleted
        const imagesToDelete = imageInputs.filter(img => img.existing && img.toBeDeleted).map(img => img.id);
        formData.append('ImagesToDelete', JSON.stringify(imagesToDelete));

        try {
            await putInProperty(id, formData);
            Swal.fire({
                position: "top-end",
                icon: "success",
                title: "Your property has been updated",
                showConfirmButton: false,
                timer: 1500
            });
            setIsSubmitting(false);
            navigate('/properties/2'); // Redirect after update
        } catch (error) {
            console.error('Error updating property:', error.response || error);
            setIsSubmitting(false);
            setFormError("Failed to update property.");
        }
    };
    const handleCancel = () => {
        navigate('/properties/2');
    }

    return (
        <form onSubmit={handleSubmit}>
            <div className="form-group">
                <label htmlFor="title">Title</label><span className="text-danger">*</span>
                <input
                    value={property.title}
                    onChange={e => setProperty({ ...property, title: e.target.value })}
                    className="form-control custom-resize"
                    placeholder="Title"
                />
            </div>

            <div className="form-group">
                <label htmlFor="address">Address</label><span className="text-danger">*</span>
                <input
                    value={property.address}
                    onChange={e => setProperty({ ...property, address: e.target.value })}
                    className="form-control custom-resize"
                    placeholder="Address"
                />
            </div>

            <div className="form-group">
                <label htmlFor="propertyType">Type</label><span className="text-danger">*</span>
                <select
                    id="propertyType"
                    value={property.pTypeId}
                    onChange={e => setProperty({ ...property, pTypeId: e.target.value })}
                    className="form-control custom-resize"
                >
                    <option value="">Select an item...</option>
                    {propertyTypes.map((type) => (
                        <option key={type.pTypeId} value={type.pTypeId}>{type.pTypeName}</option>
                    ))}
                </select>
            </div>

            <div className="form-group">
                <label htmlFor="guest">Guest</label><span className="text-danger">*</span>
                <input
                    type="number"
                    id="guest"
                    name="guest"
                    value={property.guest}
                    onChange={e => setProperty({ ...property, guest: e.target.value })}
                    className="form-control number-resize"
                    min="1"
                />
            </div>

            <div className="form-group">
                <label htmlFor="bed">Bed</label><span className="text-danger">*</span>
                <input
                    type="number"
                    id="bed"
                    name="bed"
                    value={property.bed}
                    onChange={e => setProperty({ ...property, bed: e.target.value })}
                    className="form-control number-resize"
                    min="0"
                />
            </div>

            <div className="form-group">
                <label htmlFor="bedRooms">BedRooms</label><span className="text-danger">*</span>
                <input
                    type="number"
                    id="bedRooms"
                    name="bedRooms"
                    value={property.bedRooms}
                    onChange={e => setProperty({ ...property, bedRooms: e.target.value })}
                    className="form-control number-resize"
                    min="0"
                />
            </div>

            <div className="form-group">
                <label htmlFor="bathRooms">BathRooms</label><span className="text-danger">*</span>
                <input
                    type="number"
                    id="bathRooms"
                    name="bathRooms"
                    value={property.bathRooms}
                    onChange={e => setProperty({ ...property, bathRooms: e.target.value })}
                    className="form-control number-resize"
                    min="0"
                />
            </div>

            <div className="form-group">
                <label className="mb-2">Amenities:</label>
                <div className="grid grid--cols2to3">
                    {amenities.map((amenity, index) => (
                        <label key={index} className="custom-checkbox">
                            {amenity.amenityName}
                            <i className={amenity.amenityIcon}></i>
                            <input
                                type="checkbox"
                                checked={selectedAmenities.includes(amenity.amenityId)}
                                onChange={() => handleAmenityChange(amenity.amenityId)}
                            />
                            <span className="checkmark"></span>
                        </label>
                    ))}
                </div>
            </div>

            <div className="form-group">
                <label htmlFor="price" className="form-label">Price</label><span className="text-danger">*</span>
                <div className="input-group mb-3 custom-resize">
                    <input
                        id="price"
                        name="price"
                        type="text"
                        value={property.price}
                        onChange={e => setProperty({ ...property, price: e.target.value })}
                        className="form-control custom-resize"
                        placeholder="0.00 NOK"
                    />
                    <span className="input-group-text">NOK</span>
                </div>
            </div>

           

            <div className="form-group">
                <label>Images</label>
                <div id="image-container">
                    {imageInputs.map((image, index) => (
                        <div key={index}>
                            <img src={image.preview} alt="Preview" width="100" />
                            <button onClick={() => removeImage(index)}>Remove</button>
                            <input
                                type="file"
                                id={`file-upload-${index}`}
                                multiple
                                onChange={(e) => handleImageChange(e, index)}
                                style={{ display: 'none' }}
                            />
                        </div>
                    ))}
                </div>
                <button type="button" onClick={addImageInput} className="btn btn-secondary">
                    Add Image
                </button>
            </div>


            <div className="form-group">
                <label htmlFor="description">Description</label><span className="text-danger">*</span>
                <textarea
                    id="description"
                    name="description"
                    value={property.description}
                    onChange={e => setProperty({ ...property, description: e.target.value })}
                    className="form-control custom-resize"
                    rows="5"
                    placeholder="Description..."
                ></textarea>
                {/* Validation Message */}
            </div>
            {formError && <div className="alert alert-danger" role="alert">{formError}</div>}
            <div className="form-group action-buttons">
                <button type="submit" className="btn btn-primary" disabled={isSubmitting}>
                    {isSubmitting ? 'Creating...' : 'Create'}
                </button>
                <button type="button" className="btn btn-secondary" onClick={handleCancel}>Cancel</button>
            </div>
        </form>
    );
}

export default UpdateProperty;
