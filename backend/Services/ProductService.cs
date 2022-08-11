using backend.Repositories;

namespace backend.Services
{
    public class ProductService
    {
        public ProductService(Repository repository)
        {
            this._repo = repository;
        }

        private Repository _repo;
    }
}
