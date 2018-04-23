namespace ApiVersionsD.Controllers
{
    using Microsoft.Web.Http;
    using System.Web.Http;

    [ApiVersionNeutral]
    public class VersionsController : ApiController
    {
        [HttpGet]
        public string Get()
        {
            return Request.GetRequestedApiVersion().ToString();
        }
    }
}