namespace ApiVersionsB.Controllers
{
    using Domain.Order;
    using System.Web.Http;

    [RoutePrefix("api/orders")]
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

        [HttpGet]
        [Route("{id}")]
        public Order GetOrder(string id)
        {
            return _ordersRepository.GetOrder(id);
        }
    }
}