namespace ApiVersionsA.Controllers
{
    using Domain.Product;
    using System.Web.Http;

    [RoutePrefix("api/products")]
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
        [Route("{id}")]
        public Product GetProduct(uint id)
        {
            return _productRepository.GetProduct(id);
        }
    }
}