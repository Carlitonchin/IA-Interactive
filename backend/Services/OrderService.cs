using backend.Repositories;
using backend.Models;

namespace backend.Services
{
    public class OrderService
    {
        private OrderRepository _repoOrder;
        private ProductRepository _repoProducts;
        public OrderService(OrderRepository repoOrder, ProductRepository repoProduct)
        {
            this._repoOrder = repoOrder;
            this._repoProducts = repoProduct;
        }

        public List<Order> GetOrders()
        {
            return this._repoOrder.GetOrders();
        }

        public Order CreateOrder(IEnumerable<OrderProduct> orderList)
        {
            var order = this._repoOrder.CreateOrder(orderList);

            foreach(var item in order.products)
            {
                this._repoProducts.ModifyStock(item.product, -item.cant);
            }

            return order;
        }

        public Order? FindOrderById(int id)
        {
            return this._repoOrder.FindOrderById(id);
        }

        public Order ChangeOrderStatus(Order order)
        {
            return this._repoOrder.ChangeOrderStatus(order);
        }

        public Order CancelOrder(Order order)
        {
            bool pending = order.Status == Status.Pending;
            order = this._repoOrder.CancelOrder(order);

            //only if order was in pending, products are retorned to stock
            if(pending)
            {
                foreach (var item in order.products)
                {
                    this._repoProducts.ModifyStock(item.product, item.cant);
                }
            }

            return order;
        }
    }
}
