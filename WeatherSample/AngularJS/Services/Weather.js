var WeatherApp;
(function (WeatherApp) {
    var Weather;
    (function (Weather) {
        var Services;
        (function (Services) {
            var WebApi;
            (function (WebApi) {
                var WeatherService = /** @class */ (function () {
                    function WeatherService($http, $q) {
                        this.$http = $http;
                        this.$q = $q;
                    }
                    WeatherService.prototype.getWeather = function (country, city) {
                        var deferred = this.$q.defer();
                        this.$http.get(WEB_API_SERVICES + "weather/" + country + "/" + city, {}).then(function (data) { deferred.resolve(data.data); }, function (error) { deferred.reject(error.data.Message || error.data); });
                        return deferred.promise;
                    };
                    return WeatherService;
                }());
                WebApi.WeatherService = WeatherService;
                Main.WebApi.service("weatherService", ["$http", "$q", WeatherService]);
            })(WebApi = Services.WebApi || (Services.WebApi = {}));
        })(Services = Weather.Services || (Weather.Services = {}));
    })(Weather = WeatherApp.Weather || (WeatherApp.Weather = {}));
})(WeatherApp || (WeatherApp = {}));
//# sourceMappingURL=Weather.js.map