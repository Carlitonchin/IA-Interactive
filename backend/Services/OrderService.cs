using backend.Repositories;

namespace backend.Services
{
    public class OrderService
    {
        private OrderRepository _repo;
        public OrderService(OrderRepository repo)
        {
            this._repo = repo;
        }
    }
}
