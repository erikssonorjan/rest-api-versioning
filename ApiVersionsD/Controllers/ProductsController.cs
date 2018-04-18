namespace ApiVersionsD.Controllers
{
    using Domain.Product;
    using Microsoft.Web.Http;
    using System.Web.Http;

    [ApiVersion("1")]   
    [ApiVersion("2")]
    public class ProductsController : ApiController
    {
        private readonly ProductRepository _productRepository;

        public ProductsController()
            : this(new ProductRepository())
        {
        }

        public ProductsController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [MapToApiVersion("1")]
        [Route("{id}")]
        [HttpGet]
        public Product GetProductV1(uint id)
        {
            return _productRepository.GetProduct(id);
        }

        [MapToApiVersion("2")]
        [Route("{id}")]
        [HttpGet]
        public Product GetProductV2(uint id)
        {
            var product = _productRepository.GetProduct(id);

            product.Name += " - from version 2";

            return product;
        }
    }
}