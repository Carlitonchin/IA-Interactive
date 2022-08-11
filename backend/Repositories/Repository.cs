using backend.Models;

namespace backend.Repositories
{
    public class Repository
    {
        public Repository(Context context)
        {
            this.ProductRepository = new ProductRepository(context.Products);
            this.OrderRepository = new OrderRepository(context.Orders);
        }
        public ProductRepository ProductRepository { get; private set; }
        public OrderRepository OrderRepository { get; private set; }
    }
}
