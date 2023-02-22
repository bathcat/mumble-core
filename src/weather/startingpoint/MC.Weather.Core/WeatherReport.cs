namespace MC.Weather.Core;

public static class WeatherReport
{
    public static Task<string> GetReport()
        => Task.FromResult("Partial clouds.");
}



