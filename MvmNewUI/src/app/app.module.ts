import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainPageComponent } from './Pages/main-page/main-page.component';
import { WeatherForecastSummaryComponent } from './Components/WeatherForecast/weather-forecast-summary/weather-forecast-summary.component';

@NgModule({
  declarations: [
    AppComponent,
    MainPageComponent,
    WeatherForecastSummaryComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
