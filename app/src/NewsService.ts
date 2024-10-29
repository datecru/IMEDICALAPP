import axios from 'axios';


export const getNewsByCity = async (city: string) => {
    try {
        const response = await axios.get(`http://localhost:5000/api/news/${city}`);
        return response.data;

    }
    catch (error) {
        console.error('Error consiguiendo datos de noticias', error);
        return null;
    }
    
};
