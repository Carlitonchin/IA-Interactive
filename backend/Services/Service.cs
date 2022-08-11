using backend.Repositories;

namespace backend.Services
{
    public class Service
    {
        public Service(Repository repository)
        {
            this._repo = repository;
        }

        private Repository _repo;
    }
}
