using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using System.Net;

namespace MC.Weather.Core.Tests
{
    [TestClass()]
    public class WeatherReportTests
    {
        /// <summary>
        /// Inspired by:
        ///     https://stackoverflow.com/questions/36425008/mocking-httpclient-in-unit-tests
        /// </summary>
        [TestMethod()]
        public async Task FromGridLocation_Should_Parse_Response()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
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
            var result = await WeatherReport.FromGridLocation(new GridLocation { X = 10, Y = 20, GridID = "xyz" }, handlerMock.Object);

            //
            Assert.AreEqual("Mostly cloudy, with a low around 2. North northeast wind around 2 mph.", result.DetailedForecast);


        }

        private const string responseString = """
            {
              "@context": [
                "https://geojson.org/geojson-ld/geojson-context.jsonld",
                {
                  "@version": "1.1",
                  "wx": "https://api.weather.gov/ontology#",
                  "geo": "http://www.opengis.net/ont/geosparql#",
                  "unit": "http://codes.wmo.int/common/unit/",
                  "@vocab": "https://api.weather.gov/ontology#"
                }
              ],
              "type": "Feature",
              "geometry": {
                "type": "Polygon",
                "coordinates": [
                  [
                    [
                      -105.00451940000001,
                      39.7383126
                    ],
                    [
                      -105.0024056,
                      39.716320400000001
                    ],
                    [
                      -104.97384770000001,
                      39.717941799999998
                    ],
                    [
                      -104.9759554,
                      39.739934099999999
                    ],
                    [
                      -105.00451940000001,
                      39.7383126
                    ]
                  ]
                ]
              },
              "properties": {
                "updated": "2023-02-23T12:04:57+00:00",
                "units": "us",
                "forecastGenerator": "BaselineForecastGenerator",
                "generatedAt": "2023-02-23T12:55:44+00:00",
                "updateTime": "2023-02-23T12:04:57+00:00",
                "validTimes": "2023-02-23T06:00:00+00:00/P7DT19H",
                "elevation": {
                  "unitCode": "wmoUnit:m",
                  "value": 1608.1248000000001
                },
                "periods": [
                  {
                    "number": 1,
                    "name": "Overnight",
                    "startTime": "2023-02-23T05:00:00-07:00",
                    "endTime": "2023-02-23T06:00:00-07:00",
                    "isDaytime": false,
                    "temperature": 2,
                    "temperatureUnit": "F",
                    "temperatureTrend": null,
                    "probabilityOfPrecipitation": {
                      "unitCode": "wmoUnit:percent",
                      "value": null
                    },
                    "dewpoint": {
                      "unitCode": "wmoUnit:degC",
                      "value": -21.666666666666668
                    },
                    "relativeHumidity": {
                      "unitCode": "wmoUnit:percent",
                      "value": 64
                    },
                    "windSpeed": "2 mph",
                    "windDirection": "NNE",
                    "icon": "https://api.weather.gov/icons/land/night/cold?size=medium",
                    "shortForecast": "Mostly Cloudy",
                    "detailedForecast": "Mostly cloudy, with a low around 2. North northeast wind around 2 mph."
                  },
                  {
                    "number": 2,
                    "name": "Thursday",
                    "startTime": "2023-02-23T06:00:00-07:00",
                    "endTime": "2023-02-23T18:00:00-07:00",
                    "isDaytime": true,
                    "temperature": 24,
                    "temperatureUnit": "F",
                    "temperatureTrend": "falling",
                    "probabilityOfPrecipitation": {
                      "unitCode": "wmoUnit:percent",
                      "value": 40
                    },
                    "dewpoint": {
                      "unitCode": "wmoUnit:degC",
                      "value": -13.333333333333334
                    },
                    "relativeHumidity": {
                      "unitCode": "wmoUnit:percent",
                      "value": 67
                    },
                    "windSpeed": "2 to 8 mph",
                    "windDirection": "ENE",
                    "icon": "https://api.weather.gov/icons/land/day/bkn/snow,40?size=medium",
                    "shortForecast": "Partly Sunny then Chance Light Snow",
                    "detailedForecast": "A chance of snow after 2pm. Partly sunny. High near 24, with temperatures falling to around 20 in the afternoon. Wind chill values as low as -1. East northeast wind 2 to 8 mph, with gusts as high as 16 mph. Chance of precipitation is 40%. New snow accumulation of less than half an inch possible."
                  }
                ]
              }
            }
            """;


    }
}