using backend.Services;
using backend.Models;

namespace backend.Handlers
{
    public class OrderHandler : IHandler
    {
        public string urlbase {get; set;}
        private OrderService _orderServ;

        public OrderHandler(OrderService orderService, WebApplication app)
        {
            this.urlbase = "/orders";
            this.endpoints(app);
            this._orderServ = orderService;
        }
        public void endpoints(WebApplication app)
        {
            app.MapGet(urlbase, GetOrders);
        }

        public List<Order> GetOrders()
        {
            return this._orderServ.GetOrders();
        }
    }
}
