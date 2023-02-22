using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MC.Weather.Core.Tests;

[TestClass()]
public class WeatherReportTests
{
    [TestMethod()]
    public async Task GetWeather_Should_Be_NonEmpty()
    {
        var result = await WeatherReport.GetReport();
        Assert.AreNotEqual(String.Empty, result);
    }
}