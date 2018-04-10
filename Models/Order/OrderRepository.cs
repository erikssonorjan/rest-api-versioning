namespace Domain.Order
{
    public class OrderRepository
    {
        public Order GetOrder(string id)
        {
            return new Order
            {
                Id = id,
                TotalAmount = 123m
            };
        }
    }
}
