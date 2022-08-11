using backend.Repositories;
using backend.Models;

namespace backend.Services
{
    public class OrderService
    {
        private OrderRepository _repo;
        public OrderService(OrderRepository repo)
        {
            this._repo = repo;
        }

        public List<Order> GetOrders()
        {
            return this._repo.GetOrders();
        }
    }
}
