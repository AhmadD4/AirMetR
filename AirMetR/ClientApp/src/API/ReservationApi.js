import axios from 'axios';
import { handleError } from './Services';

// Set up an axios instance with a base URL for the Reservation API.
const api = axios.create({
    baseURL: 'http://localhost:47251/api/Reservation',
});


// Async function to get reservation details by ID.
const getReservationDetails = async (id) => {
    try {
        // Sending a GET request.
        const response = await api.get(`/Details/${id}`);
        // Return the data from the response.
        return response.data;
    } catch (error) {
        console.error('Reservation Error fetching data:', error);
        // Handle errors using a custom function.
        handleError(error);
    }
};

// Async function to get all reservations by a specific property ID.
const getAllResByPropertyId = async (id) => {
    try {
        const response = await api.get(`/ListReservations/${id}`);
        return response.data;
    } catch (error) {
        console.error('Reservation Error fetching data:', error);
        handleError(error);
    }
};

// Async function to get all reservations by a specific user ID.
const getAllResByUserId = async () => {
    try {
        const response = await api.get('/Reservation');
        return response.data;
    } catch (error) {
        console.error('Reservation Error fetching data:', error);
        handleError(error);
    }
};


const getUnavailableDates = async (id) => {
    try {
        const response = await api.get(`/GetUnavailableDates/${id}`);
        return response.data;
    } catch (error) {
        console.error('Reservation Error fetching GetUnavailableDates:', error);
        handleError(error);
    }
};

const postReservation = async (id, formData) => {
    try {
        const response = await api.post(`/CompleteReservation/${id}`, formData);
        return response;
    } catch (error) {
        handleError(error);
    }
};

const deleteReservation = async (id) => {
    try {
        const response = await api.delete(`/DeleteReservation/${id}`);
        return response.data;
    } catch (error) {
        handleError(error);
    }
};

const putInReservation = async (id, formData) => {
    try {
        const response = await api.put(`/UpdateReservation/${id}`, formData);
        return response.data;
    } catch (error) {
        handleError(error);
    }
};


// Export the functions to be used elsewhere in the application.
export {
    getReservationDetails,
    getAllResByPropertyId,
    getAllResByUserId,
    getUnavailableDates,
    postReservation,
    deleteReservation,
    putInReservation
}