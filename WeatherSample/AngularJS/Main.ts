/// <reference path="../Scripts/typings/angularjs/angular.d.ts" />

declare var WEB_API_SERVICES;

class Main {
    public static WebApi: ng.IModule = angular.module("WeatherApp.WebApi", []);
    public static App: any = angular.module("WeatherApp", ["WeatherApp.WebApi"]);
}
