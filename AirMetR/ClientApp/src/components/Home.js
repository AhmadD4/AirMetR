import React, { useState, useEffect } from 'react';
import axios from 'axios';
import PropertyCard from './PropertyCard';

const Home = () => {
    const [properties, setProperties] = useState([]);

    useEffect(() => {
        axios.get('http://localhost:47251/api/Property/GetAllProperties')
            .then(response => { 
                setProperties(response.data);

                console.log(response.data);
            })
            .catch(error => {
                console.error('Error fetching data:', error);
            });
    }, []);

    return (
        <div>
            <h1>Properties</h1>
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
