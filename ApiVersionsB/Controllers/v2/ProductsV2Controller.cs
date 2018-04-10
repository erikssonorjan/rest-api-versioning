namespace ApiVersionsB.Controllers.v2
{
    using Domain.Product;
    using System.Web.Http;

    [RoutePrefix("api/v2/products")]
    public class ProductsV2Controller : ApiController
    {
        private readonly ProductRepository _productRepository;

        public ProductsV2Controller()
            : this(new ProductRepository())
        {
        }

        public ProductsV2Controller(ProductRepository productRepository)
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