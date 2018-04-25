namespace ApiVersionsC
{
    using Microsoft.Web.Http;
    using Microsoft.Web.Http.Routing;
    using System.Web.Http;
    using System.Web.Http.Routing;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //
            // Use Microsoft.AspNet.WebApi.Versioning
            //

            // Custom filter to expose used version.
            GlobalConfiguration.Configuration.Filters.Add(new VersionInformationFilter());

            // Web API routes

            //
            // No magic! Routes are used to resolve versions.
            //

            var constraintResolver = new DefaultInlineConstraintResolver
            {
                ConstraintMap = { ["apiVersion"] = typeof(ApiVersionRouteConstraint) }
                // E.g. [RoutePrefix("api/v{version:apiVersion}/resource")]
            };

            config.MapHttpAttributeRoutes(constraintResolver);

            config.AddApiVersioning(o =>
            {
                o.DefaultApiVersion = new ApiVersion(1, 0);
                
                o.AssumeDefaultVersionWhenUnspecified = true;
                
                o.ReportApiVersions = true;
            });
        }
    }
}