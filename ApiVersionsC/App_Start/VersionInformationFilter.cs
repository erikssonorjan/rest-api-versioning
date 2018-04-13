namespace ApiVersionsC
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    public class VersionInformationFilter : IActionFilter
    {
        public bool AllowMultiple => false;

        public async Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            var response = await continuation.Invoke();

            response.Headers.Add("Api-Version", actionContext.Request.GetRequestedApiVersion().ToString());

            return response;
        }
    }
}