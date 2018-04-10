namespace ApiVersionsB.Controllers.v1
{
    using Domain.Order;
    using System.Web.Http;

    [RoutePrefix("api/v1/orders")]
    public class OrdersV1Controller : ApiController
    {
        private readonly OrderRepository _ordersRepository;

        public OrdersV1Controller()
            : this(new OrderRepository())
        {
        }

        public OrdersV1Controller(OrderRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        [HttpGet]
        [Route("{id}")]
        public Order GetOrder(string id)
        {
            var order = _ordersRepository.GetOrder(id);

            order.Reference = "From version 1";

            return order;
        }
    }
}