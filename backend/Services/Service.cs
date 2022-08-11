using backend.Repositories;

namespace backend.Services
{
    public class Service
    {
        public Service(Repository repository)
        {
            this._repo = repository;
            this.ProductService = new ProductService(this._repo.ProductRepository);
        }

        private Repository _repo;
        public ProductService ProductService { get; private set; }
    }
}
