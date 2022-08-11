namespace backend.Models
{
    public class Context
    {
        public Context()
        {
            this.Products = new List<Product>();
        }

        public List<Product> Products { get; private set; }
    }
}
