using System.Web.Http;

namespace Ex3
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Sql server requests route, use web api.
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
