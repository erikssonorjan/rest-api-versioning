namespace ApiVersionsC.Controllers
{
    using Domain.Order;
    using Microsoft.Web.Http;
    using System.Web.Http;

    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [RoutePrefix("api/v{version:apiVersion}/orders")]
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

        [MapToApiVersion("1.0")]
        [Route("~/api/orders/{id}")]
        [Route("{id}")]
        [HttpGet]
        public Order GetOrderV1(string id)
        {
            return _ordersRepository.GetOrder(id);
        }

        [MapToApiVersion("2.0")]
        [Route("{id}")]
        [HttpGet]
        public Order GetOrderV2(string id)
        {
            var order = _ordersRepository.GetOrder(id);

            order.Reference = "From version 2";

            return order;
        }
    }
}