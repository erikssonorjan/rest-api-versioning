namespace ApiVersionsD.Controllers
{
    using Domain.Order;
    using Microsoft.Web.Http;
    using System.Web.Http;

    [ApiVersion(Versions.V1_0)]
    [ApiVersion(Versions.V2_0)]
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

        [MapToApiVersion(Versions.V1_0)]
        [HttpGet]
        public Order GetOrderV1(string id)
        {
            return _ordersRepository.GetOrder(id);
        }

        [MapToApiVersion(Versions.V2_0)]
        [HttpGet]
        public Order GetOrderV2(string id)
        {
            var order = _ordersRepository.GetOrder(id);

            order.Reference = "From version 2";

            return order;
        }
    }
}