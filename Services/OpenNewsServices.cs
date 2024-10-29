using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;


public class OpenNewsService

{   
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "fcf443fd4af246cf97d01fe58793779b"; //Api key del servicio del clima

    public OpenNewsService(HttpClient httpClient)

    {
        _httpClient = httpClient;

        //esta api requiere un User-Agent
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "MyNewsApp/1.0");
    }

    public async Task<Object> GetNewsByCityAsync(string city)

    {
        string url = $"https://newsapi.org/v2/everything?q={city}&sortBy=publishedAt&language=es&apiKey={_apiKey}"; //url para leer solicitud

        var response = await _httpClient.GetAsync(url); //solicitud http

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            
            var newsData = JsonSerializer.Deserialize<Object>(content, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true

            });

            return newsData;
        }
        else
        {
            var errorContent =await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error:{response.StatusCode}, Content:{errorContent}");
            return null;
        }
    }
}