using backend.Services;

namespace backend.Handlers
{
    public class Handler
    {
        public Handler(Service service, WebApplication app)
        {
            this._service = service;
            this._productHandler = new ProductHandler(this._service.ProductService, app);
        }

        private Service _service;
        private ProductHandler _productHandler;
    }
}
