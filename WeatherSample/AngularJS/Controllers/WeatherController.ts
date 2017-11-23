/// <reference path="../Main.ts" />

module WeatherApp.Weather.Controllers {
    export class WeatherController {
        scope: any;
        weatherService: Weather.Services.WebApi.IWeatherService;
        showPleaseWait: boolean;
        locationNotFound: boolean;
        country: string;
        city: string;
        weatherData: Weather.Models.WeatherVm;
        dataError: string;

        constructor($scope, weatherService) {
            $scope.ctrl = this;

            this.scope = $scope;
            this.weatherService = weatherService;
            this.showPleaseWait = false;
            this.locationNotFound = false;
            this.weatherData = null;
            this.dataError = "";
        }

        checkWeather() {
            this.dataError = "";

            if (this.country == null || this.country.length === 0) {
                this.dataError = "Please provide a country";
                return;
            }

            if (this.city == null || this.city.length === 0) {
                this.dataError = "Please provide a city";
                return;
            }

            this.showPleaseWait = true;
            this.locationNotFound = false;
            this.weatherData = null;
            this.weatherService.getWeather(this.country, this.city)
                .then(data => {
                    if (typeof data.Temperature !== "undefined" && data.Temperature != null)
                        this.weatherData = data;
                    else
                        this.locationNotFound = true;

                    this.showPleaseWait = false;
                }, error => {
                    this.dataError = error;
                    this.showPleaseWait = false;
                });
        }
    }

    Main.App.controller('WeatherController', ['$scope', 'weatherService', WeatherController]);
}