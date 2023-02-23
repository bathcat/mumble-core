using System.Net.Http.Json;

namespace MC.Weather.Core;

public record struct Position
{
    /// <summary>
    /// From -90 to 90
    /// </summary>
    public required Single Latitude { get; init; }

    /// <summary>
    /// From -180 to 180
    /// </summary>
    public required Single Longitude { get; init; }

    private static readonly string uri = "http://www.geoplugin.net/json.gp";


    private readonly record struct GeopluginDTO(float geoplugin_latitude, float geoplugin_longitude);

    public static async Task<Position> GetCurrent(HttpMessageHandler handler)
    {
        var client = new HttpClient(handler);
        using var response = await client.GetAsync(uri);
        response.EnsureSuccessStatusCode();
        var dto = await response.Content.ReadFromJsonAsync<GeopluginDTO>();
        return new Position
        {
            Latitude = dto.geoplugin_latitude,
            Longitude = dto.geoplugin_longitude
        };

    }

    public static Task<Position> GetCurrent()
    {
        using var handler = new HttpClientHandler();
        return GetCurrent(handler);
    }
}