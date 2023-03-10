using System;

namespace Acme.Core;

public class WeatherReport
{
    public Guid ID { get; init; } = Guid.NewGuid();
    public DateTime Date { get; init; } = DateTime.UtcNow;
    public int Temperature { get; init; }
    public string Summary { get; init; } = String.Empty;
}
