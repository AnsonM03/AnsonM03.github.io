const weatherStatus = document.querySelector("#weather-status");
const weatherResult = document.querySelector("#weather-result");
const refreshWeatherButton = document.querySelector("#refresh-weather");

const weatherUrl =
  "https://api.open-meteo.com/v1/forecast?latitude=52.0705&longitude=4.3007&current=temperature_2m,weather_code&timezone=Europe%2FAmsterdam";

const weatherDescriptions = {
  0: "Onbewolkt",
  1: "Overwegend helder",
  2: "Gedeeltelijk bewolkt",
  3: "Bewolkt",
  45: "Mist",
  48: "Rijpmist",
  51: "Lichte motregen",
  61: "Lichte regen",
  63: "Regen",
  65: "Zware regen",
  71: "Lichte sneeuw",
  80: "Regenbuien",
  95: "Onweer"
};

const showWeather = (weatherData) => {
  const temperature = weatherData.current.temperature_2m;
  const weatherCode = weatherData.current.weather_code;
  const description =
    weatherDescriptions[weatherCode] || "Weersituatie onbekend";

  const weatherText = document.createElement("p");
  weatherText.textContent =
    `In Den Haag is het ${temperature} °C en ${description.toLowerCase()}.`;

  weatherResult.replaceChildren(weatherText);
};

const loadWeather = async () => {
  weatherStatus.textContent = "Weerbericht wordt geladen.";
  weatherResult.replaceChildren();

  try {
    const response = await fetch(weatherUrl);

    if (!response.ok) {
      throw new Error("De weergegevens konden niet worden opgehaald.");
    }

    const weatherData = await response.json();

    showWeather(weatherData);
    weatherStatus.textContent = "Het actuele weerbericht is geladen.";
  } catch (error) {
    weatherStatus.textContent =
      "Het weerbericht kan nu niet worden geladen. Probeer het later opnieuw.";
  }
};

refreshWeatherButton.addEventListener("click", loadWeather);

loadWeather();