using backend.Services;

namespace backend.Handlers
{
    public class OrderHandler : IHandler
    {
        public string urlbase {get; set;}
        private OrderService _orderServ;

        public OrderHandler(OrderService orderService, WebApplication app)
        {
            this.urlbase = "/order";
            this.endpoints(app);
            this._orderServ = orderService;
        }
        public void endpoints(WebApplication app)
        {

        }
    }
}
