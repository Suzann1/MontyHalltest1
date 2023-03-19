using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MontyHall.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            configuration.MapHttpAttributeRoutes();
            configuration.Routes.MapHttpRoute("DefaultAPI", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
        }
    }
}