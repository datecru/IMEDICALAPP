import axios from 'axios';


export const getWeatherByCity = async (city: string) => {
    try {
        const response = await axios.get(`http://localhost:5000/api/weather/${city}`);
        return response.data;

    }
    catch (error) {
        console.error('Error consiguiendo datos del clima', error);
        return null;
    }
    
};
