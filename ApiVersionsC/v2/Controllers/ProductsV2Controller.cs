namespace ApiVersionsC.v2.Controllers
{
    using Domain.Product;
    using Microsoft.Web.Http;
    using System.Web.Http;

    [ApiVersion("2")]
    [RoutePrefix("api/v{version:apiVersion}/products")]
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