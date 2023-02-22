using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using System.Net;

namespace MC.Weather.Core.Tests
{
    [TestClass()]
    public class PositionTests
    {
        private const string responseString = """
            {
              "geoplugin_request":"185.238.231.169",
              "geoplugin_status":200,
              "geoplugin_delay":"2ms",
              "geoplugin_credit":"Some of the returned data includes GeoLite data created by MaxMind, available from <a href='http:\/\/www.maxmind.com'>http:\/\/www.maxmind.com<\/a>.",
              "geoplugin_city":"Denver",
              "geoplugin_region":"Colorado",
              "geoplugin_regionCode":"CO",
              "geoplugin_regionName":"Colorado",
              "geoplugin_areaCode":"",
              "geoplugin_dmaCode":"751",
              "geoplugin_countryCode":"US",
              "geoplugin_countryName":"United States",
              "geoplugin_inEU":0,
              "geoplugin_euVATrate":false,
              "geoplugin_continentCode":"NA",
              "geoplugin_continentName":"North America",
              "geoplugin_latitude":"39.7388",
              "geoplugin_longitude":"-104.9868",
              "geoplugin_locationAccuracyRadius":"20",
              "geoplugin_timezone":"America\/Denver",
              "geoplugin_currencyCode":"USD",
              "geoplugin_currencySymbol":"$",
              "geoplugin_currencySymbol_UTF8":"$",
              "geoplugin_currencyConverter":0
            }
            """;

        /// <summary>
        /// Inspired by:
        ///     https://stackoverflow.com/questions/36425008/mocking-httpclient-in-unit-tests
        /// </summary>
        [TestMethod()]
        public async Task GetCurrent_Should_Parse_Response()
        {

            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(responseString),
               })
               .Verifiable();

            //
            var result = await Position.GetCurrent(handlerMock.Object);

            //
            const double tolerance = .0001;
            Assert.AreEqual(39.7388, result.Latitude, tolerance);
            Assert.AreEqual(-104.9868, result.Longitude, tolerance);

        }
    }
}