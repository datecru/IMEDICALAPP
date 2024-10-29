using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient(); //añadir el servicio para http
builder.Services.AddScoped<OpenWeatherService>();
builder.Services.AddScoped<OpenNewsService>();
builder.Services.AddScoped<OpenSearchService>();


var connectionString = "Server=localhost;Port=3306;Database=imedical_database;User Id=root;Password=247755ca80;";
builder.Services.AddScoped<MySqlConnection>(_ => new MySqlConnection(connectionString));


builder.Services.AddControllers();

builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowLocalhost3000", builder => builder
            
                .WithOrigins("http://localhost:3000") // Permitir la peticion desde local en el puerto 3001
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
        );
        
    }
);

var app = builder.Build();

app.UseCors("AllowLocalhost3000");

app.UseAuthorization();

app.MapControllers();

/*
app.MapGet("/weather/{city}", async (string city, OpenWeatherService weatherService) =>
{
    var weather = await weatherService.GetWeatherByCityAsync(city);
    return weather != null ? Results.Ok(weather) : Results.NotFound();
});


app.MapGet("/news/{city}", async (string city, OpenNewsService newsService) =>
{
    var news = await newsService.GetNewsByCityAsync(city);
    return news != null ? Results.Ok(news) : Results.NotFound();
});
*/

/*app.MapGet("/api/recentsearch/recent", async (OpenSearchService searchService) =>
{
    var searches = await searchService.GetRecentSearchesAsync();
    return searches.Count > 0 ? Results.Ok(searches) : Results.NotFound();
});*/



app.Run();

