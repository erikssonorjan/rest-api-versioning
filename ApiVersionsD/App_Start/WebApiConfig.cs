﻿namespace ApiVersionsD
{
    using Microsoft.Web.Http;
    using Microsoft.Web.Http.Routing;
    using Microsoft.Web.Http.Versioning;
    using System.Web.Http;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            GlobalConfiguration.Configuration.Filters.Add(new VersionInformationFilter());
            
            // Web API routes

            config.Routes.MapHttpRoute(
                "VersionedQueryString",
                "api/{controller}/{Id}",
                defaults: null);

            config.Routes.MapHttpRoute(
                "VersionedUrl",
                "api/v{apiVersion}/{controller}/{Id}",
                defaults: null,
                constraints: new { apiVersion = new ApiVersionRouteConstraint() });

            config.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;

                o.DefaultApiVersion = new ApiVersion(1, 0);

                o.ReportApiVersions = true;

                o.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader("ver"),         // svc?ver=2.0
                    new HeaderApiVersionReader("X-Api-Version"),
                    new MediaTypeApiVersionReader("ver"));          // Content-Type: application/json;ver=2.0
            });
        }
    }
}