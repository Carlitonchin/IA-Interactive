using backend.Models;

namespace backend.Repositories
{
    public class Repository
    {
        public Repository(Context context)
        {
            this._db = context;
            this.ProductRepository = new ProductRepository(this._db.Products);
        }

        private Context _db;
        public ProductRepository ProductRepository { get; private set; }
    }
}
