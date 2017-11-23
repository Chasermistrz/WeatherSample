/// <reference path="../Main.ts" />
var WeatherApp;
(function (WeatherApp) {
    var Weather;
    (function (Weather) {
        var Controllers;
        (function (Controllers) {
            var WeatherController = /** @class */ (function () {
                function WeatherController($scope, weatherService) {
                    $scope.ctrl = this;
                    this.scope = $scope;
                    this.weatherService = weatherService;
                    this.showPleaseWait = false;
                    this.locationNotFound = false;
                    this.weatherData = null;
                    this.dataError = "";
                }
                WeatherController.prototype.checkWeather = function () {
                    var _this = this;
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
                        .then(function (data) {
                        if (typeof data.Temperature !== "undefined" && data.Temperature != null)
                            _this.weatherData = data;
                        else
                            _this.locationNotFound = true;
                        _this.showPleaseWait = false;
                    }, function (error) {
                        _this.dataError = error;
                        _this.showPleaseWait = false;
                    });
                };
                return WeatherController;
            }());
            Controllers.WeatherController = WeatherController;
            Main.App.controller('WeatherController', ['$scope', 'weatherService', WeatherController]);
        })(Controllers = Weather.Controllers || (Weather.Controllers = {}));
    })(Weather = WeatherApp.Weather || (WeatherApp.Weather = {}));
})(WeatherApp || (WeatherApp = {}));
//# sourceMappingURL=WeatherController.js.map