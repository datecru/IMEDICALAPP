import React, { useState, useEffect } from 'react';
import { getWeatherByCity } from './WeatherService';
import { getNewsByCity } from './NewsService';

import './index.css';



interface NewsArticle {
    title: string;
    description: string;
    url: string;
    urlToImage: string;
    publishedAt: string;
}

const Weather: React.FC = () => {
    const [city, setCity] = useState<string>('');
    const [weatherData, setWeatherData] = useState<any>(null);
    const [newsData, setNewsData] = useState<any>(null);
    const [recentSearches, setRecentSearches] = useState<any[]>([]);

    const handleSearch = async () => {

        try {
        const weather = await getWeatherByCity(city);
        setWeatherData(weather);
        

        const news = await getNewsByCity(city);
        setNewsData(news);
        

        await saveRecentSearch(city);

        await fetchRecentSearches();

        } catch (error) {
            console.error('Error al obtener los datos:', error);
        }
    };

    const fetchRecentSearches = async () => {
        try {
            const response = await fetch('http://localhost:5000/api/recentsearch/recent');
            if (!response.ok){
                throw new Error('Error al obtener las búsquedas recientes');
            }
            const data = await response.json();
            setRecentSearches(data);
        } catch (error) {
            console.error('Error al obtener las búsquedas recientes:', error);
        }
    };

    const saveRecentSearch = async (city: string) => {
        try {
            const response =await fetch('http://localhost:5000/api/recentsearch', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({city}),
            });

            if (!response.ok) {
                throw new Error('Error al guardar la búsqueda reciente');
            }
        } catch (error) {
            console.error('Error al guardar la búsqueda reciente:', error);
        }
    };
    

    useEffect(() => {
        // Cargar las búsquedas recientes al cargar la página
        fetchRecentSearches();
    }, []);

    return (
        <div id="busqueda">
            <h1>CITY <span style={{color: 'grey'}}>NEWS</span></h1>
            <div className="seccion-busqueda">
                <input id="barra-busqueda" type ="text" value ={city} onChange={(e)=> setCity(e.target.value)} placeholder="Ingrese la Ciudad"/>
            
                <button className="button-2" onClick={handleSearch}>Buscar</button>
            </div>
            {weatherData && (
                <div>
                    <div className="seccion-clima">
                    <h2>
                        {weatherData.name}
                    </h2>
                    <div className="descripcion-clima">Temperatura: {weatherData.main.temp}°C</div>
                    <div className="descripcion-clima">Humedad: {weatherData.main.humidity}%</div>
                    <div className="descripcion-clima">Descripcion: {weatherData.weather[0].description}</div>
                    </div>
                    
                </div>
            )}
            {newsData && (
             <div>
                
                <div id="cards_container">
                {newsData.articles.map((article: NewsArticle) => (
                    <div key={article.url} className="article">
                    <img className="article-image" src={article.urlToImage} alt={article.title} />
                    <h2>{article.title}</h2>
                    <p>{article.description}</p>   
          
                    <p>Publicado el: {new Date(article.publishedAt).toLocaleDateString()}</p>
                    <a href={article.url}>Leer mas</a>
                  </div>
                ))}
                </div>
             </div>   
            )}

            <div>
                <div id="busquedas-recientes">Busquedas Recientes</div>
                <div className="font-lista">
                    {recentSearches.map((search) => (
                        <div className="font-lista-div" key={search.id}>
                            {search.city} 
                        </div>
                    ))}
                </div>
            </div>

        </div>
    );

};

export default Weather;
