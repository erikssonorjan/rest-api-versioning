namespace ApiVersionsB.v2_0.Controllers
{
    using Domain.Product;
    using System.Web.Http;

    [RoutePrefix("api/v2.0/products")]
    public class ProductsV2_0Controller : ApiController
    {
        private readonly ProductRepository _productRepository;

        public ProductsV2_0Controller()
            : this(new ProductRepository())
        {
        }

        public ProductsV2_0Controller(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("{id}")]
        public Product GetProduct(uint id)
        {
            var product = _productRepository.GetProduct(id);

            product.Name += " - from version 2";

            return product;
        }
    }
}