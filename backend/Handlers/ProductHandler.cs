using backend.Services;

namespace backend.Handlers
{
    public class ProductHandler : IHandler
    {
        private Service _serv;

        public ProductHandler(Service service, WebApplication app)
        {
            this._serv = service;
            this._endpoints(app);
        }
        public void _endpoints(WebApplication app)
        {

        }
    }
}
