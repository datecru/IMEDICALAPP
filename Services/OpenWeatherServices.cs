using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;


public class OpenWeatherService

{   
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "37cf0faffe1ec431aa8e5f7fad28d6d9"; //Api key del servicio del clima

    public OpenWeatherService(HttpClient httpClient)

    {
        _httpClient = httpClient;
    }

    public async Task<object> GetWeatherByCityAsync(string city)

    {
        string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&lang=es&appid={_apiKey}"; //url para leer solicitud
        
        var response = await _httpClient.GetAsync(url); //solicitud http

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            
            var weatherData = JsonSerializer.Deserialize<object>(content, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true

            });

            return weatherData;
        }
        else
        {
            return null;
        }
    }
}