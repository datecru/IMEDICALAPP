using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly OpenWeatherService _weatherService;
    private readonly OpenSearchService _searchService;



    public WeatherController(OpenWeatherService weatherService, OpenSearchService searchService)
    {
        _weatherService = weatherService;
        _searchService = searchService;
    }

    [HttpGet("{city}")]
    public async Task<IActionResult> GetWeather(string city)
    {
        var weather = await _weatherService.GetWeatherByCityAsync(city);
        if (weather == null)
        {
            return NotFound(new { message = "No se encuentra la ciudad o error en la Api"});

        }

        await _searchService.SaveSearchAsync(city);
        return Ok(weather);
        
    }
}
