import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import PropertyCard from './PropertyCard';
import { getAllTypes, getAllProperties, getAllByTypes } from '../API/Services';


const Home = () => {
    // State variables to store properties, types, and any errors.
    const [properties, setProperties] = useState([]);
    const [types, setTypes] = useState([]);
    const [error, setError] = useState(null);

    // Handler to fetch all properties.
    const getAllPropertiesHandler = async () => {
        try {
            const propertiesData = await getAllProperties();
            // Update the properties state with fetched data.
            setProperties(propertiesData);
        } catch (err) {
            // Set error state in case of an exception.
            setError(err.message);
        }
    };

    // Handler to fetch properties by type.
    const getByTypes = async (id) => {
        try {
            const propertiesData = await getAllByTypes(id);
            setProperties(propertiesData);
        } catch (err) {
            setError(err.message);
        }
    };

    // useEffect hook to fetch data on component mount.
    useEffect(() => {
        const fetchData = async () => {
            try {
                getAllPropertiesHandler();

                const typesData = await getAllTypes();
                setTypes(typesData);
            } catch (err) {
                setError(err.message);
            }
        };

        // Execute the fetchData function.
        fetchData();

    }, []);// Empty dependency array to ensure this runs once on mount.

    return (
        <div>
            <nav className="navbar navbar-expand-lg navbar-light bg-light">
                <div className="collapse navbar-collapse d-flex justify-content-center" id="navbarNav">
                    <ul className="navbar-nav">
                        <li className="nav-item">
                            <div className="text-center">
                                <Link className="nav-link" onClick={() => { getAllPropertiesHandler() }}>
                                    <i className="fas fa-home"></i>
                                    <div>All</div>
                                </Link>
                            </div>
                        </li>
                        {
                            types.map((type) => {
                                return (
                                    <li key={type.pTypeId} className="navbar-item">
                                        <div className="text-center">
                                            {/* Link to filter properties by type */}
                                            <Link className="nav-link ms-3" onClick={() => { getByTypes(type.pTypeId) }}>
                                                <i className={type.pTypeIcon}></i>
                                                <div>{type.pTypeName}</div>
                                            </Link>
                                        </div>
                                    </li>
                                )
                            })
                        }
                    </ul>
                </div>
            </nav>

            <div className="row row-cols-1 row-cols-md-4 g-3">
            {properties.map(property => (
                
                <div key={property.propertyId}>
                    <PropertyCard property={property}/>
                    </div>
                
            ))}
            </div>
        </div>
    );
};

export default Home;
