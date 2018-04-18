namespace ApiVersionsD.Controllers
{
    using Domain.Order;
    using Microsoft.Web.Http;
    using System.Web.Http;

    [ApiVersion("1")]
    [ApiVersion("2")]
    public class OrdersController : ApiController
    {
        private readonly OrderRepository _ordersRepository;

        public OrdersController()
            : this(new OrderRepository())
        {
        }

        public OrdersController(OrderRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public Order GetOrderV1(string id)
        {
            return _ordersRepository.GetOrder(id);
        }

        [MapToApiVersion("2")]
        [HttpGet]
        public Order GetOrderV2(string id)
        {
            var order = _ordersRepository.GetOrder(id);

            order.Reference = "From version 2";

            return order;
        }
    }
}