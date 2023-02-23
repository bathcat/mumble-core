# Lab: Weather


## Summary
Due to overwhelming customer demand, you are building a command-line tool to get the latest weather forecast. Use web services to get the data. 


## Requirements
1. Get the current latitude and longitude via the geoplugin service here:  
`http://www.geoplugin.net/json.gp`


2. Using the current latitude and longitude, get the associated grid location from weather.gov like this:
`https://api.weather.gov/points/39,-105`

In the example-- 
* Latitude: 39
* Longitude: -105

Note: NOAA doesn't need an API key, but it does insist on a `user-agent` header in the [request](https://weather-gov.github.io/api/general-faqs).  


3. Using the grid location, get the current forecast from weather.gov like this:
`https://api.weather.gov/gridpoints/BOU/63,72/forecast`

In the example-- 
* Office: BOU
* Grid X: 63
* Grid Y: 72

Note: You'll need the `user-agent` header here too.



## Stretch Goals
* Write tests
* Beautify output












## Hints

### To Set the `user-agent` Header
```csharp
        using var client = new HttpClient(handler);
        client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 Safari/537.36");
```

