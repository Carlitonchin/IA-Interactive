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

        public IEnumerable<Product> GetProducts()
        {
            return this._db.Where(p=>!p.Deleted);
        }

        public void CreateProduct(Product product)
        {
            this._db.Add(product);
        }

        public Product? FindBySKU(string? sku)
        {
            return this._db.Where(p=>!p.Deleted).FirstOrDefault(p=>p.SKU == sku);
        }

        public Product? FindActiveAndDeleted(string? sku)
        {
            return this._db.FirstOrDefault(p=>p.SKU == sku);
        }

        public void ModifyStock(Product p, int cant)
        {
            p.Stock += cant;
        }

        public void DeleteProduct(Product p)
        {
            p.Delete();
        }
    }
}
