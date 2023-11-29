import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import PropertyCard from './PropertyCard';
import { getAllTypes, getAllProperties, getAllByTypes } from '../API/Services';


const Home = () => {
    const [properties, setProperties] = useState([]);
    const [types, setTypes] = useState([]);
    const [error, setError] = useState(null);

    const getAllPropertiesHandler = async () => {
        try {
            const propertiesData = await getAllProperties();
            setProperties(propertiesData);
        } catch (err) {
            setError(err.message);
        }
    };

    const getByTypes = async (id) => {
        try {
            const propertiesData = await getAllByTypes(id);
            setProperties(propertiesData);
        } catch (err) {
            setError(err.message);
        }
    };

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

        fetchData();

    }, []);

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
                                            <Link className="nav-link ms-3" onClick={() => {getByTypes(type.pTypeId) }}>
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
