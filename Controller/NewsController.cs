using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class NewsController : ControllerBase
{
    private readonly OpenNewsService _newsService;
    private readonly OpenSearchService _searchService;


    public NewsController(OpenNewsService newsService, OpenSearchService searchService)
    {
        _newsService = newsService;
        _searchService = searchService;
    }

    [HttpGet("{city}")]
    public async Task<IActionResult> GetNews(string city)
    {
        var news = await _newsService.GetNewsByCityAsync(city);
        if (news == null)
        {
            return NotFound(new { message = "No se encuentra la ciudad o error en la Api"});

        }

        await _searchService.SaveSearchAsync(city);
        return Ok(news);
        
    }
}