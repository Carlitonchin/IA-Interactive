namespace backend.Models
{
    public class Context
    {
        public Context()
        {
            this.Products = new List<Product>();
            this.Orders = new List<Order>();
        }

        public List<Product> Products { get; private set; }
        public List<Order> Orders { get; private set; }
    }
}
