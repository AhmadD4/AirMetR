import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import './Create.css';

function CreateProperty() {

    let navigate = useNavigate(); // This is for redirecting for the cancel action

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
    const [imageInputs, setImageInputs] = useState([{ file: null, preview: null }]);
    const [formError, setFormError] = useState(""); // State to store the error message
    const [isSubmitting, setIsSubmitting] = useState(false); // State to indicate submission status

    useEffect(() => {
        console.log('Making API call to get create data...');
        axios.get(`http://localhost:47251/api/Property/GetCreateData`)
            .then(response => {
                console.log('Response:', response.data);
                setPropertyTypes(response.data.pTypes);
                setAmenities(response.data.amenities);
            })
            .catch(error => {
                console.error('Error fetching data:', error);
            });
    }, []);

    const handleAmenityChange = (amenityId) => {
        setSelectedAmenities(prevSelected => {
            if (prevSelected.includes(amenityId)) {
                return prevSelected.filter(id => id !== amenityId);
            } else {
                return [...prevSelected, amenityId];
            }
        });
    };

    const handleImageChange = (index, file) => {
        const newImageInputs = [...imageInputs];
        newImageInputs[index] = {
            file,
            preview: file ? URL.createObjectURL(file) : null
        };
        setImageInputs(newImageInputs);
    };

    const addImageInput = () => {
        setImageInputs([...imageInputs, { file: null, preview: null }]);
    };

    const removeImage = (index) => {
        const newImageInputs = imageInputs.filter((_, i) => i !== index);
        setImageInputs(newImageInputs);
        // Revoke URL to free memory
        if (imageInputs[index].preview) {
            URL.revokeObjectURL(imageInputs[index].preview);
        }
    };

    const handleSubmit = (event) => {
        event.preventDefault();
        setIsSubmitting(true); // Indicate the start of form submission
        setFormError(""); // Reset any existing errors
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

        // Append images
        imageInputs.forEach((input, index) => {
            if (input.file) {
                formData.append('Files', input.file);
            }
        });

        console.log(property);
        console.log(selectedAmenities);
        console.log(imageInputs);
        for (let [key, value] of formData.entries()) {
            console.log(key, value);
        }


        axios.post(`http://localhost:47251/api/Property/Create`, formData)
            .then(response => {
                // Handle successful submission
                console.log('Success:', response.data);
                setIsSubmitting(false); // Reset submission status
                navigate('/'); // Redirect to a success page, or home, etc.
            })
            .catch(error => {
                // Handle errors
                console.error('Error submitting form:', error.response || error);
                setIsSubmitting(false); // Reset submission status
                if (error.response) {
                    // The request was made and the server responded with a status code
                    // that falls out of the range of 2xx
                    setFormError(error.response.data.message || "An error occurred. Please try again.");
                } else if (error.request) {
                    // The request was made but no response was received
                    setFormError("No response from the server. Please check your connection.");
                } else {
                    // Something happened in setting up the request that triggered an Error
                    setFormError("Error: " + error.message);
                }
            });
    };

    const handleCancel = () => {
        // If you want to redirect to a different page
        navigate('/');
        // ... other handler functions
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
                    {imageInputs.map((input, index) => (
                        <div key={index}>
                            <input
                                type="file"
                                className="form-control-file mb-2"
                                onChange={(e) => handleImageChange(index, e.target.files[0])}
                            />
                            {input.preview && (
                                <div className="img-div">
                                    <img src={input.preview} alt="Preview" width="100" />
                                    <button type="button" className="delete-btn" onClick={() => removeImage(index)}>x</button>
                                </div>
                            )}
                        </div>
                    ))}
                </div>

                <button type="button" className="btn btn-secondary" onClick={addImageInput}>Add Image</button>
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

export default CreateProperty;
