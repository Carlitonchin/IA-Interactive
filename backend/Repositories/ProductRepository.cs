using backend.Models;

namespace backend.Repositories
{
    public class ProductRepository
    {
        public ProductRepository(List<Product> product_db)
        {
            this._db = product_db;
        }

        private List<Product> _db;
    }
}
