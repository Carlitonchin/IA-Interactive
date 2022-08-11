using backend.Services;

namespace backend.Handlers
{
    public class Handler
    {
        public Handler(Service service)
        {
            this._service = service;
        }

        private Service _service;
    }
}
