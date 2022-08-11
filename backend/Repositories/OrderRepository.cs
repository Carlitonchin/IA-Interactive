using backend.Models;

namespace backend.Repositories
{
    public class OrderRepository
    {
        private List<Order> _db;
        public OrderRepository(List<Order> orders)
        {
            this._db = orders;
        }
    }
}
