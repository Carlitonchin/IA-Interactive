using backend.Repositories;
using backend.Models;

namespace backend.Services
{
    public class ProductService
    {
        public ProductService(ProductRepository repository)
        {
            this._repo = repository;
        }

        private ProductRepository _repo;

        public List<Product> GetProducts()
        {
            return this._repo.GetProducts();
        }
    }
}
