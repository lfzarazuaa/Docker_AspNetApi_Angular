import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeatherForecastSummaryComponent } from './weather-forecast-summary.component';

describe('WeatherForecastSummaryComponent', () => {
  let component: WeatherForecastSummaryComponent;
  let fixture: ComponentFixture<WeatherForecastSummaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WeatherForecastSummaryComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WeatherForecastSummaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
