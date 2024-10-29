using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class RecentsearchController : ControllerBase

{
    private readonly OpenSearchService _searchService;

    public RecentsearchController(OpenSearchService searchService)
    {
        _searchService = searchService;
    }

    [HttpGet("recent")]
    public async Task<IActionResult> GetRecentSearches()
    {   
        Console.WriteLine("Se alcanzo /api/recentsearch/recent");
        var searches = await _searchService.GetRecentSearchesAsync();
        if (searches.Count == 0)
        {
            Console.WriteLine("No hay busquedas recientes");
            return NotFound(new { message = "No hay busquedas recientes" });
        }
        return Ok(searches);
    }

    [HttpPost]
    public async Task<IActionResult> SaveSearch([FromBody]string city)
    {
        await _searchService.SaveSearchAsync(city);
        return Ok();
    }
    
}
