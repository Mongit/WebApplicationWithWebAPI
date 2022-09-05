using System.Web.Http;

namespace WebApplicationWithWebApiService.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            // Enable attribute routing for controllers
            //  use can combined with routing tables
            config.MapHttpAttributeRoutes();

            // Routing tables
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}