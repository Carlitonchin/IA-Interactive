using backend.Models;

namespace backend.Repositories
{
    public class Repository
    {
        public Repository(Context context)
        {
            this._db = context;
        }

        private Context _db;
    }
}
