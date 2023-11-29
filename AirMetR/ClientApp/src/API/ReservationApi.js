import axios from 'axios';
import { handleError } from './Services';


const api = axios.create({
    baseURL: 'http://localhost:47251/api/Reservation',
});


const getReservationDetails = async (id) => {
    try {
        const response = await api.get(`/Details/${id}`);
        return response.data;
    } catch (error) {
        console.error('Reservation Error fetching data:', error);
        handleError(error);
    }
};

const getAllResByPropertyId = async (id) => {
    try {
        const response = await api.get(`/ListReservations/${id}`);
        return response.data;
    } catch (error) {
        console.error('Reservation Error fetching data:', error);
        handleError(error);
    }
};

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


export {
    getReservationDetails,
    getAllResByPropertyId,
    getAllResByUserId,
    getUnavailableDates,
    postReservation,
    deleteReservation,
    putInReservation
}