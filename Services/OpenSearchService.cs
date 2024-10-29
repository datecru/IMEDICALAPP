using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

public class OpenSearchService
{
    private readonly MySqlConnection _connection;

    public OpenSearchService(MySqlConnection connection)
    {
        _connection = connection;
    }

    public async Task<List<object>> GetRecentSearchesAsync()
    {
        var searches = new List<object>();

        await _connection.OpenAsync();
        string query = "SELECT * FROM recent_searches ORDER BY search_time DESC LIMIT 5";
        using (var cmd = new MySqlCommand(query, _connection))
        {
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    searches.Add(new
                    { 
                        Id = reader["id"],
                        City = reader["city"], 
                        SearchTime = reader["search_time"]
                    });
                }
            }
        }
        await _connection.CloseAsync();
        return searches;
    }

    public async Task SaveSearchAsync(string city)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO recent_searches (city, search_time) VALUES (@city, NOW())";
            using (var cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@city", city);

                try
                {
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected == 0)
                    {
                        Console.WriteLine("Error guardando la busqueda: no filas insertadas");
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"MySqlException Error al guardar la busqueda: {ex.Message}, mensaje: {ex.Message}");
                }
                
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al guardar la busqueda: {ex.Message}");
                }
            }
            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al abrir la conexion: {ex.Message}");
        }
        finally
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                await _connection.CloseAsync();
            } 
        }
    }
}
