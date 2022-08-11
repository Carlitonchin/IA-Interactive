namespace backend.Models
{
    public class Product
    {
        public string SKU { get; private set; }
        public string Name { get; set; }
        public int Stock { get; set; }

        public Product(string sku, string name, int stock)
        {
            this.SKU = sku;
            this.Name = name;
            this.Stock = stock;
        }
    }
}
