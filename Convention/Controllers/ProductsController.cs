namespace ApiVersionsConvention.Controllers
{
    using Domain.Product;
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

        public Product GetProduct(uint id)
        {
            return _productRepository.GetProduct(id);
        }
    }
}