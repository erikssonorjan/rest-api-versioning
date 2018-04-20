namespace ApiVersionsB.v1_0.Controllers
{
    using Domain.Order;
    using System.Web.Http;

    [RoutePrefix("api/v1.0/orders")]
    public class OrdersV1_0Controller : ApiController
    {
        private readonly OrderRepository _ordersRepository;

        public OrdersV1_0Controller()
            : this(new OrderRepository())
        {
        }

        public OrdersV1_0Controller(OrderRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        [HttpGet]
        [Route("{id}")]
        public Order GetOrder(string id)
        {
            return _ordersRepository.GetOrder(id);
        }
    }
}