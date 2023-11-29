import axios from 'axios';


const api = axios.create({
    baseURL: 'http://localhost:47251/api/Property',
});

const handleError = (error) => {
    console.error('API request error:', error);

    if (error.response) {
        console.error('Response error:', error.response.data);
        throw error.response.data;
    } else if (error.request) {
        console.error('No response received:', error.request);
        throw 'No response from the server. Please check your connection.';
    } else {
        console.error('Error setting up the request:', error.message);
        throw 'An error occurred. Please try again.';
    }
};


const getAllProperties = async () => {
    try {
        const response = await api.get('/GetAllProperties');
        return response.data;
    } catch (error) {
        console.error('Error fetching data:', error);
        handleError(error);
    }
}

const getAllTypes = async () => {
    try {
        const response = await api.get('/GetPTypes');
        return response.data;
    } catch (error) {
        console.error('Error fetching data:', error);
        handleError(error);
    }
}

const getAllByTypes = async (id) => {
    try {
        const response = await api.get(`/PropertyTypes/${id}`);
        return response.data;
    } catch (error) {
        console.error('Error fetching data:', error);
        handleError(error);

    }
}

const getPropertyDetails = async (id) => {
    try {
        const response = await api.get(`/Details/${id}`);
        return response.data;
    } catch (error) {
        console.error('Error fetching data:', error);
        handleError(error);
    }
}

const getCreateData = async () => {
    try {
        const response = await api.get('/GetCreateData');
        return response.data;
    } catch (error) {
        console.error('Error fetching data:', error);
        handleError(error);
    }
}

const submitProperty = async (formData) => {
    try {
        const response = await api.post('/Create', formData);
        console.log('Success:', response.data);
        return response.data;
    } catch (error) {
        handleError(error);
    }
};

const getUpdateData = async (id) => {
    try {
        const response = await api.get(`/GetUpdateData/${id}`)
        return response.data;
    } catch (error) {
        console.error('Error fetching data:', error);
        handleError(error);
    }
};

const deleteImage = async (imageId) => {
    try {
        const response = await api.delete(`/DeleteImage/${imageId}`);
        console.log('Success:', response.data);
        return response.data;
    } catch (error) {
        handleError(error);
    }
};

const putInProperty = async (id, formData) => {
    try {
        const response = await api.put(`/Update/${id}`, formData);
        console.log('Success:', response.data);
        return response.data;
    } catch (error) {
        handleError(error);
    }
};

const deleteProperty = async (id) => {
    try {
        const response = await api.delete(`/Delete/${id}`);
        console.log('Deleted:', response.data);
        return response.data;
    } catch (error) {
        handleError(error);
    }
};

const listPropertiesByCustomer = async () => {
    try {
        const response = await api.get('/List')
        return response.data;
    }
    catch (error) {
        console.error('Error fetching properties:', error);
        handleError(error);
    }
}


export {
    handleError,
    getAllProperties,
    getAllTypes,
    getAllByTypes,
    getPropertyDetails,
    getCreateData,
    submitProperty,
    getUpdateData,
    deleteImage,
    putInProperty,
    deleteProperty,
    listPropertiesByCustomer
};