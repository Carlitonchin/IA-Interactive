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
    }
}
