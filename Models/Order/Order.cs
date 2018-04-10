namespace Domain.Order
{
    public class Order
    {
        public string Id { get; set; }

        public string Reference { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
