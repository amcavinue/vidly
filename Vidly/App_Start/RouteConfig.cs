using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            // Routing for VidlyAngular.
            routes.MapRoute(
                name: "VidlyAngular",
                url: "",
                defaults: new { controller = "Angular", action = "Index" }
            );

            routes.MapRoute(
                name: "one",
                url: "One",
                defaults: new { controller = "Angular", action = "One" }
            );

            routes.MapRoute(
                name: "classifieds",
                url: "ClassifiedsPartial",
                defaults: new { controller = "Angular", action = "ClassifiedsPartial" }
            );

            routes.MapRoute(
                name: "classifiedCard",
                url: "ClassifiedCard",
                defaults: new { controller = "Angular", action = "ClassifiedCard"}
            );

            // Default routing for ASP.NET MVC.
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Angular", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
