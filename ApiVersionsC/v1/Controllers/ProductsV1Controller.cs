namespace ApiVersionsC.v1.Controllers
{
    using Domain.Product;
    using Microsoft.Web.Http;
    using System.Web.Http;

    [ApiVersion("1")]   
    [RoutePrefix("api/v{version:apiVersion}/products")]
    public class ProductsV1Controller : ApiController
    {
        private readonly ProductRepository _productRepository;

        public ProductsV1Controller()
            : this(new ProductRepository())
        {
        }

        public ProductsV1Controller(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [Route("~/api/products/{id}")]
        [Route("{id}")]
        [HttpGet]
        public Product GetProductV1(uint id)
        {
            return _productRepository.GetProduct(id);
        }
    }
}