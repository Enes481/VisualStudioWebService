using Newtonsoft.Json.Serialization;
using Programming.API.Attributes;
using Programming.API.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Programming.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Filters.Add(new ApiExceptionAttribute()); // exceptionları application çapında belirlemek için WebApiConfig.cs içine yazdık
            config.MessageHandlers.Add(new APIKeyHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;//verilerin Json formatında çıktı vermesi yazılan kod satırı
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();//propertylerin ilk harflerinin büyük olmaması için 
        }
    }
}
