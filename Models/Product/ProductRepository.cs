namespace Domain.Product
{
    public class ProductRepository
    {
        public Product GetProduct(uint id)
        {
            return new Product
            {
                Id = id,
                Name = "Product-" + id
            };
        }

        public Product GetExtendedProduct(uint id)
        {
            return new Product
            {
                Id = id,
                Name = "ProductExtended-" + id
            };
        }
    }
}
