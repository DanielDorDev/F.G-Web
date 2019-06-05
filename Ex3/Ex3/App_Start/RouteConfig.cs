using System.Web.Mvc;
using System.Web.Routing;
using Ex3.Controllers;

namespace Ex3
{
    public class RouteConfig
    {
        // Route for base client request, use mvc api.
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Route for display by ip server connection, use constraints to determine ip value.
            routes.MapRoute("DisplayServer", "display/{ip}/{port}/{time}",
            defaults: new { controller = "display", action = "DisplayServer", time = 0 },
            constraints: new { ip = new IPConstraint() });

            // Route for display by file import.
            routes.MapRoute("DisplayFile", "display/{name}/{time}",
            defaults: new { controller = "display", action = "DisplayFile", time = 0 });

            // Route for save and display(save first and use view display).
            routes.MapRoute("SaveFlight", "save/{ip}/{port}/{rate}/{time}/{name}",
            defaults: new { controller = "display", action = "Save" },
            constraints: new { ip = new IPConstraint() });

            // 404 error handle.
            routes.MapRoute("404-PageNotFound", "{*url}",
                    new { controller = "display", action = "Home" });

            // Default.
            routes.MapRoute(
                name: "Default", url: "{controller}",
                defaults: new { controller = "display", action = "Home" });
        }
    }
}
