//Information: Config.js is not pushed, but looks like this ('value' replaced by the API Key)
/*
var config = {
    OPENWEATHER_API_KEY : 'value'
}
*/

async function getWeather(lat, lon) {
    console.log("func call: getWeather, " + lat + ", " + lon);
    let url =   'https://api.openweathermap.org/data/2.5/weather?lat=' + lat + 
                '&lon=' + lon + '&appid=' + config.OPENWEATHER_API_KEY + '&lang=de';
    try {
        let res = await fetch(url);
        return await res.json();
    } catch (error) {
        console.log(error);
    }
}

async function getGeoByCityname(city) {
    console.log("func call: getGeoByCityName, " + city);
    if(city)
    {
        let url =   'http://api.openweathermap.org/geo/1.0/direct?q=' + city + 
        '&limit=5&appid=' + config.OPENWEATHER_API_KEY; 
        try {
            let res = await fetch(url);
            return await res.json();
        } catch (error) {
            console.log(error);
        }
    }
    else
    {
        return false;
    }
}

async function giveSuggestions(cityname) {
    console.log("func call: giveSuggestions, " + cityname);
    let cities = await getGeoByCityname(cityname);

    if(cities)
    {
        let suggestions = document.getElementById('suggestions');
        let buttonClassName = "suggestionButton";
        suggestions.innerHTML = '';
    
        for (const city of cities)
        {
            let suggestionButton = document.createElement("button");
            suggestionButton.innerHTML = `${city.name}, ${city.country} (${city.state})`;
            suggestionButton.className = buttonClassName;
            suggestionButton.addEventListener("click", function() {
                fillWeatherData(city.lat, city.lon);
            });
            suggestions.appendChild(suggestionButton);
        }    
    }
  
}

function fillWeatherData(lat, lon) {
    console.log("func call: fillWeatherData, " + lat + ", " + lon);

    getWeather(lat, lon).then(data => {
        console.log("weather result: " + JSON.stringify(data));
        let weatherResult = document.getElementById("weatherResult");
        weatherResult.innerHTML = 
        `<h2>Aktuelle Wetterlage in ${data.name}</h2>
    
        <p>Temperatur: ${(data.main.temp - 273.15).toFixed(2)}°C</p>
        <p>Luftdruck: ${data.main.pressure} hPa</p>
        <p>Feuchtigkeit: ${data.main.humidity}%</p>
        <p>geringste Temperatur: ${(data.main.temp_min - 273.15).toFixed(2)}°C</p>
        <p>höchste Temperatur: ${(data.main.temp_max - 273.15).toFixed(2)}°C</p>
        <p>Windgeschwindigkeit: ${data.wind.speed}m/s</p>
        <p>Windrichtung: ${data.wind.deg}°</p>`;

        let weatherDescription = document.getElementById("weatherDescription");
        weatherDescription.innerHTML =
        `<img src="http://openweathermap.org/img/wn/${data.weather[0].icon}@2x.png">
        <p>${data.weather[0].description}</p>`;
    });
}

window.onload = function() {
    let searchButton = document.getElementById("searchButton");
    searchButton.addEventListener("click", function() {
        giveSuggestions(document.getElementById("searchText").value);
        console.log("Search button clicked");
    });
}