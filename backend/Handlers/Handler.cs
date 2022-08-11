using backend.Services;

namespace backend.Handlers
{
    public class Handler
    {
        public Handler(Service service, WebApplication app)
        {
            this._service = service;
        }

        private Service _service;
    }
}
