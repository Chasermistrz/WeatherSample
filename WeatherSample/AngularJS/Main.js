/// <reference path="../Scripts/typings/angularjs/angular.d.ts" />
var Main = /** @class */ (function () {
    function Main() {
    }
    Main.WebApi = angular.module("WeatherApp.WebApi", []);
    Main.App = angular.module("WeatherApp", ["WeatherApp.WebApi"]);
    return Main;
}());
//# sourceMappingURL=Main.js.map