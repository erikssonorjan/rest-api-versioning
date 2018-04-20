namespace ApiVersionsB.v2.Controllers
{
    using Domain.Order;
    using System.Web.Http;

    [RoutePrefix("api/v2.0/orders")]
    public class OrdersV2_0Controller : ApiController
    {
        private readonly OrderRepository _ordersRepository;

        public OrdersV2_0Controller()
            : this(new OrderRepository())
        {
        }

        public OrdersV2_0Controller(OrderRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        [HttpGet]
        [Route("{id}")]
        public Order GetOrder(string id)
        {
            var order = _ordersRepository.GetOrder(id);

            order.Reference = "From version 2";

            return order;
        }
    }
}