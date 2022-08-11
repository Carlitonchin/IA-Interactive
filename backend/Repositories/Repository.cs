using backend.Models;

namespace backend.Repositories
{
    public class Repository
    {
        public Repository(Context context)
        {
            this.ProductRepository = new ProductRepository(context.Products);
        }
        public ProductRepository ProductRepository { get; private set; }
    }
}
