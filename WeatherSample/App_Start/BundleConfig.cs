using System.Web.Optimization;

namespace WeatherSample
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundle/lib").Include(
                "~/Scripts/jquery-1.10.2.js",
                "~/Scripts/angular.js",
                "~/AngularJS/Main.js",
                "~/AngularJS/Services/Weather.js",
                "~/AngularJS/Models/WeatherVm.js",
                "~/AngularJS/Controllers/WeatherController.js"));
            
            bundles.Add(new StyleBundle("~/bundle/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/Site.css"));
        }
    }
}