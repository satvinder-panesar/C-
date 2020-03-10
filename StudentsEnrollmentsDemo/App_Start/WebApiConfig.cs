using StudentsEnrollmentsDemo.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace StudentsEnrollmentsDemo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            config.Formatters.Add(GlobalConfiguration.Configuration.Formatters.JsonFormatter);

            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            config.Services.Replace(typeof(IExceptionLogger), new GlobalExceptionLogger());

            config.MessageHandlers.Add(new ReqResHandler());
        }
    }
}
