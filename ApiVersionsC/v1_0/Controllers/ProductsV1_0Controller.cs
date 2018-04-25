namespace ApiVersionsC.v1_0.Controllers
{
    using Domain.Product;
    using Microsoft.Web.Http;
    using System.Web.Http;

    [ApiVersion("1.0")]   
    [RoutePrefix("api/v{version:apiVersion}/products")]
    public class ProductsV1_0Controller : ApiController
    {
        private readonly ProductRepository _productRepository;

        public ProductsV1_0Controller()
            : this(new ProductRepository())
        {
        }

        public ProductsV1_0Controller(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [Route("~/api/products/{id}")] // Route without prefix.
        [Route("{id}")]
        [HttpGet]
        public Product GetProductV1(uint id)
        {
            return _productRepository.GetProduct(id);
        }
    }
}