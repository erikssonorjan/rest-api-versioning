namespace ApiVersionsC
{
    using Microsoft.Web.Http;
    using Microsoft.Web.Http.Routing;
    using Microsoft.Web.Http.Versioning;
    using System.Web.Http;
    using System.Web.Http.Routing;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            GlobalConfiguration.Configuration.Filters.Add(new VersionInformationFilter());

            // Web API routes

            var constraintResolver = new DefaultInlineConstraintResolver
            {
                ConstraintMap = { ["apiVersion"] = typeof(ApiVersionRouteConstraint) }
            };

            config.MapHttpAttributeRoutes(constraintResolver);

            config.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;

                o.DefaultApiVersion = new ApiVersion(1, 0);

                o.ReportApiVersions = true;

                o.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader());
            });
        }
    }
}