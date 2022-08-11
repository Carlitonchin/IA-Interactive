using backend.Services;

namespace backend.Handlers
{
    public class Handler
    {
        public Handler(Service service, WebApplication app)
        {
            this._productHandler = new ProductHandler(service.ProductService, app);

            this._orderHandler = new OrderHandler(service.OrderService, service.ProductService, app);
        }
        private ProductHandler _productHandler;
        private OrderHandler _orderHandler;
    }
}
