using backend.Errors;
using backend.Utils;

namespace backend.Models
{
    public class Product : IValidable
    {
        public string? SKU { get; private set; }
        public string? Name { get; set; }
        public int? Stock { get; set; }
        public bool Deleted {get; private set;}

        public Product(string? sku, string? name, int? stock)
        {
            this.SKU = sku;
            this.Name = name;
            this.Stock = stock;
            this.Deleted = false;
        }

        public void Delete()
        {
            this.Deleted = true;
        }
        public Error? Validate()
        {
            if(Utils.Validate.EmptyOrNull(this.SKU))
                return new Error("sku is required");

            if(Utils.Validate.EmptyOrNull(this.Name))
                return new Error("name is required");

            if(this.Stock == null)
                return new Error("stock is required");

            if(this.Stock < 0)
                return new Error("stock must be non-negative");

            return null;
        }
    }
}
