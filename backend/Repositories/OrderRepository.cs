using backend.Models;

namespace backend.Repositories
{
    public class OrderRepository
    {
        private class AutoIncrement
        {
            private int _id;

            public AutoIncrement()
            {
                this._id = 1;
            }

            public int getId()
            {
                return this._id++;
            }
        }
        private List<Order> _db;
        private AutoIncrement _autoIncrement;
        public OrderRepository(List<Order> orders)
        {
            this._db = orders;
            this._autoIncrement = new AutoIncrement();
        }

        public List<Order> GetOrders()
        {
            return this._db;
        }

        public Order CreateOrder(IEnumerable<OrderProduct> orderList)
        {
            int id = this._autoIncrement.getId();
            Order order = new Order(id, Status.Pending, orderList);
            this._db.Add(order);
            return order;
        }

        public Order? FindOrderById(int id)
        {
            return this._db.FirstOrDefault(o=>o.Id == id);
        }

        public Order ChangeOrderStatus(Order order)
        {
            order.Status++;
            return order;
        }
    }
}
