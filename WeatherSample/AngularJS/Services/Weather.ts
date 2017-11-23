module WeatherApp.Weather.Services.WebApi {

    export interface IWeatherService {
        getWeather(country: string, city: string): ng.IPromise<Weather.Models.WeatherVm>;
    }

    export class WeatherService implements IWeatherService {
        private $http: ng.IHttpService;
        private $q: ng.IQService;

        constructor($http, $q: ng.IQService) {
            this.$http = $http;
            this.$q = $q;
        }

        getWeather(country: string, city: string): ng.IPromise<Weather.Models.WeatherVm> {
            var deferred = this.$q.defer<Weather.Models.WeatherVm>();

            this.$http.get<Weather.Models.WeatherVm>(
                WEB_API_SERVICES + "weather/" + country + "/" + city,
                {}
            ).then(
                data => { deferred.resolve(data.data); },
                error => { deferred.reject(error.data.Message || error.data); });

            return deferred.promise;
        }
    }

    Main.WebApi.service("weatherService", ["$http", "$q", WeatherService]);
}