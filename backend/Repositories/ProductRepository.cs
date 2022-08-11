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

        public List<Product> GetProducts()
        {
            return this._db;
        }

        public void CreateProduct(Product product)
        {
            this._db.Add(product);
        }

        public Product FindBySKU(string sku)
        {
            return this._db.FirstOrDefault(p=>p.SKU == sku);
        }
    }
}
