namespace ApiVersionsD
{
    using ApiVersionsD.Controllers;
    using Microsoft.Web.Http;
    using Microsoft.Web.Http.Routing;
    using Microsoft.Web.Http.Versioning;
    using Microsoft.Web.Http.Versioning.Conventions;
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
                defaults: new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                "VersionedUrl",
                "api/v{apiVersion}/{controller}/{Id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new { apiVersion = new ApiVersionRouteConstraint() });

            config.AddApiVersioning(o =>
            {
                o.DefaultApiVersion = new ApiVersion(1, 0);

                o.AssumeDefaultVersionWhenUnspecified = true;
                
                o.ReportApiVersions = true;

                o.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader("ver"),         // svc?ver=2.0
                    new HeaderApiVersionReader("X-Api-Version"),
                    new MediaTypeApiVersionReader("ver"));          // Content-Type: application/json;ver=2.0
                
                // Use conventions for the product resources.
                o.Conventions.Controller<ProductsController>()
                    .HasApiVersion(1, 0)
                    .HasApiVersion(2, 0)
                    .Action(c => c.GetProductV1(default(int))).MapToApiVersion(1, 0)
                    .Action(c => c.GetProductV2(default(int))).MapToApiVersion(2, 0);
            });
        }
    }
}
