import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface Weather {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-weather-forecast-summary',
  templateUrl: './weather-forecast-summary.component.html',
  styleUrls: ['./weather-forecast-summary.component.scss']
})
export class WeatherForecastSummaryComponent implements OnInit {
  weatherData: Weather[] = [];
  apiUrl = 'https://localhost:5001/WeatherForecast';

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<Weather[]>(this.apiUrl).subscribe(data => {
      this.weatherData = data;
    }, error => {
      console.error('Error fetching weather data:', error);
    });
  }

  fetchWeatherData(): void {
    this.http.get<Weather[]>(this.apiUrl).subscribe(data => {
      this.weatherData = data;
    }, error => {
      console.error('Error fetching weather data:', error);
    });
  }
}

