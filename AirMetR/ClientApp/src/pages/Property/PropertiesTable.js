import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
import { listPropertiesByCustomer } from '../../API/Services';

function PropertyList() {
    const [properties, setProperties] = useState([]);
    const [customer, setCustomer] = useState();

    useEffect(() => {
        const fetchData = async () => {
            try {
                const data = await listPropertiesByCustomer();
                setProperties(data.properties);
                setCustomer(data.customerInfo);
            } catch (error) {
                console.error('Error fetching properties:', error);
            }
        };

        fetchData();

    }, []);

    return (
        <div className="container">
            <table className='table table-striped table-hover'>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Title</th>
                        <th>Price</th>
                        <th>Address</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {properties.map((item) => (
                        <tr key={item.propertyId}>
                            <td>{item.propertyId}</td>
                            <td>
                                <Link to={`/property/${item.propertyId}`}>{item.title}</Link>
                            </td>
                            <td>{`${item.price.toFixed(2)} NOK`}</td>
                            <td>{item.address}</td>
                            <td>
                                <Link className="link-dark" to={`/property/update/${item.propertyId}`}>Update</Link>
                                {' | '}
                                <Link className="link-danger" to={`/property/delete/${item.propertyId}`}>Delete</Link>
                                {' | '}
                                <Link className="link-success" to={`/reservations/list/${item.propertyId}`}>Reservations</Link>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
            <p>
                <Link className="btn btn-secondary" to="/property/create">Add new home</Link>
            </p>
        </div>
    );
}

export default PropertyList;

