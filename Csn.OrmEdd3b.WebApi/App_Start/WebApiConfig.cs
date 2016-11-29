using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiContrib.Formatting.Jsonp;

namespace Csn.OrmEdd3b.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Cross Dmmain Ajax Solutions

            // 1. JSONP
            // Nuget Package: install-package WebApiContrib.Formatting.Jsonp

            //var jsonpFormatter = new JsonpMediaTypeFormatter(config.Formatters.JsonFormatter);
            //config.Formatters.Insert(0, jsonpFormatter); // inject the new formatter into the collection of formatters as the first formatter

            // 2. CORS Cross Origin Resource Sharing
            // Nuget package: install-package Microsoft.AspNet.WebApi.Cors

            EnableCorsAttribute cors = new EnableCorsAttribute("http://localhost:1843,http://coolcsn.com", "*", "GET,POST"); // "*" - for all websites | "Accept,Content-type" or "*" | GET,POST
            config.EnableCors(cors);
        }
    }
}
