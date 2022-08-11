using backend.Errors;

namespace backend.Models
{

    public enum Status{
        Pending,
        InProcess,
        Completed,
        Delivered,
        Canceled
    }

    public class OrderProduct
    {
        public Product product {get; set;}
        public int cant {get; private set;}
        public OrderProduct(Product p, int c)
        {
            this.product = p;
            this.cant = c;
        }

    }

    public class ListOrderProduct
    {
        private List<OrderProduct> _list;
        private Dictionary<string, bool> _skus;

        public ListOrderProduct()
        {
            this._list = new List<OrderProduct>();
            this._skus = new Dictionary<string, bool>();
        }

        public Error? Add(OrderProduct op)
        {
            if(this._skus.ContainsKey(op.product.SKU))
                return new Error($"Product {op.product.Name} is 2 times in the order");

            this._skus[op.product.SKU] = true;
            this._list.Add(op);

            return null;
        }

        public IEnumerable<OrderProduct> GetOrderProducts()
        {
            return this._list.AsEnumerable<OrderProduct>();
        }

    }
    public class Order : IValidable
    {
        public Order(int id, Status status, IEnumerable<OrderProduct> list)
        {
            this.Id = id;
            this.Status = status;
            this.products = list;
        }

        public int Id { get; private set; }
        public Status Status { get; set; }

        public IEnumerable<OrderProduct> products { get; private set; }
        public Error? Validate()
        {
            return null;
        }
    }
}
