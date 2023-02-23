using System.Net.Http.Json;

namespace MC.Weather.Core;

public readonly record struct WeatherReport(
        string Name,
        DateTime StartTime,
        DateTime EndTime,
        bool IsDaytime,
        Single Temperature,
        string TemperatureUnit,
        string TemperatureTrend,
        string WindSpeed,
        string WindDirection,
        string ShortForecast,
        string DetailedForecast
)
{
    public static string GetUri(GridLocation location)
        => $"https://api.weather.gov/gridpoints/{location.GridID}/{location.X},{location.Y}/forecast";

    private readonly record struct ResponsePropertiesDTO(WeatherReport[] Periods);
    private readonly record struct ResponseDTO(ResponsePropertiesDTO Properties);

    public static async Task<WeatherReport> FromGridLocation(GridLocation location, HttpMessageHandler handler)
    {
        using var client = new HttpClient(handler);
        client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 Safari/537.36");

        var uri = GetUri(location);
        using var response = await client.GetAsync(uri);
        response.EnsureSuccessStatusCode();
        var dto = await response.Content.ReadFromJsonAsync<ResponseDTO>();
        return dto.Properties.Periods[0];
    }

    public static Task<WeatherReport> FromGridLocation(GridLocation location)
    {
        using var handler = new HttpClientHandler();
        return FromGridLocation(location, handler);
    }


    public static async Task<WeatherReport> GetReport()
    {
        var position = await Position.GetCurrent();
        var location = await GridLocation.FromPosition(position);
        return await FromGridLocation(location);
    }
}



