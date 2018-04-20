namespace ApiVersionsA.v1_0.Controllers
{
    using Domain.Product;
    using System.Web.Http;

    [RoutePrefix("api/v1.0/products")]
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