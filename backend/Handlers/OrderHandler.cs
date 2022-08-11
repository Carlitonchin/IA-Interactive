using backend.Services;
using backend.Models;
using backend.Utils;

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

            app.MapPost(urlbase + "/new",
            (List<CreateOrderRequest> products) => CreateOrder(products));
        }

        public List<Order> GetOrders()
        {
            return this._orderServ.GetOrders();
        }

        public List<CreateOrderRequest> CreateOrder(List<CreateOrderRequest> products)
        {
            return products;
        }
    }
}
