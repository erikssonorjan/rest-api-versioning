namespace ApiVersionsD.Controllers
{
    using Domain.Product;
    using Microsoft.Web.Http;
    using System.Web.Http;

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

        [HttpGet]
        public Product GetProductV1(uint id)
        {
            return _productRepository.GetProduct(id);
        }

        [HttpGet]
        public Product GetProductV2(uint id)
        {
            var product = _productRepository.GetProduct(id);

            product.Name += " - from version 2";

            return product;
        }
    }
}