using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.WebApi;
using TEST6.SERVICE;
using TEST6.DATAS.Infrastructure;
using TEST6.DATAS.Repository;
using TEST6.MODELS.Model;
using Microsoft.Practices.Unity;
using Unity.Exceptions;

namespace TEST6.API
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
        }
    }
}
