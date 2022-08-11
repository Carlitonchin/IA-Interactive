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

        public void CreateProduct(Product product)
        {
            this._repo.CreateProduct(product);
        }

        public Product? FindBySKU(string? sku)
        {
            return this._repo.FindBySKU(sku);
        }

        public void ModifyStock(Product p, int cant)
        {
            this._repo.ModifyStock(p, cant);
        }

        public void DeleteProduct(Product p)
        {
            this._repo.DeleteProduct(p);
        }
    }
}
