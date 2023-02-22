# Lab: Get-Weather


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


3. Using the grid location, get the current forecast from weather.gov like this:
`https://api.weather.gov/gridpoints/BOU/63,72/forecast`

In the example-- 
* Office: BOU
* Grid X: 63
* Grid Y: 72


## Stretch Goals
* Write tests
* Beautify output
* Model the data structures with classes
* Make functions pipe-friendly
* Add it to your modules directory so it's imported automatically





## Hints
* Good article on JSON and Powershell [here](https://adamtheautomator.com/powershell-json/)
* Weather API [FAQ](https://weather-gov.github.io/api/general-faqs)
* To get just the 'short forecast' from the weather.gov forecast JSON:
```powershell
$response.properties.periods[0].shortForecast
```

