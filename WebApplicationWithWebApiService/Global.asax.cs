using System;
using System.Web.Http;
using WebApplicationWithWebApiService.App_Start;

namespace WebApplicationWithWebApiService
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // Together with WebAPiConfig 
            // This enables attribute routing
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}