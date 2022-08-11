using backend.Services;

namespace backend.Handlers
{
    internal class ProductHandler : IHandler
    {
        private ProductService _serv;

        public ProductHandler(ProductService service, WebApplication app)
        {
            this._serv = service;
            this._endpoints(app);
        }
        public void _endpoints(WebApplication app)
        {

        }
    }
}
