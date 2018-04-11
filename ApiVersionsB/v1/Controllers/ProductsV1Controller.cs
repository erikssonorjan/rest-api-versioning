namespace ApiVersionsB.v1.Controllers
{
    using Domain.Product;
    using System.Web.Http;

    [RoutePrefix("api/v1/products")]
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

        [HttpGet]
        [Route("{id}")]
        public Product GetProduct(uint id)
        {
            var product = _productRepository.GetProduct(id);

            product.Name += " - from version 1";

            return product;
        }
    }
}