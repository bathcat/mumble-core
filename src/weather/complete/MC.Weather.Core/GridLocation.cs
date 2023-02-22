using System.Net;
using System.Net.Http.Json;

namespace MC.Weather.Core;

public readonly record struct GridLocation
{
    /// <summary>
    /// 3 Characters
    /// </summary>
    public required string GridID { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required Byte X { get; init; }


    public required Byte Y { get; init; }

    public static string GetUri(Position position)
        => $"http://api.weather.gov/points/{position.Latitude},{position.Longitude}";

    private readonly record struct ResponsePropertiesDTO(string GridId, byte GridX, byte GridY);
    private readonly record struct ResponseDTO(ResponsePropertiesDTO Properties);


    public static async Task<GridLocation> FromPosition(Position position, HttpMessageHandler handler)
    {
        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

        var client = new HttpClient(handler);
        client.DefaultRequestHeaders.Add("Accept", "*/*");
        client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 Safari/537.36");
        var uri = GetUri(position);
        using var response = await client.GetAsync(uri);
        response.EnsureSuccessStatusCode();
        var dto = await response.Content.ReadFromJsonAsync<ResponseDTO>();
        return new GridLocation
        {
            GridID = dto.Properties.GridId,
            X = dto.Properties.GridX,
            Y = dto.Properties.GridY,
        };
    }

    public static Task<GridLocation> FromPosition(Position position)
        => FromPosition(position, new HttpClientHandler());
}