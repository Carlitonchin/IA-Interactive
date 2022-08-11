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
        public Product? product {get; private set;}
        public int? cant {get; private set;}

        public OrderProduct(Product? p, int? c)
        {
            this.product = p;
            this.cant = c;
        }
    }
    public class Order : IValidable
    {
        public Order(int id, Status status)
        {
            this.Id = id;
            this.Status = status;
            this.products = new List<OrderProduct>();
        }

        public int Id { get; private set; }
        public Status Status { get; set; }

        public List<OrderProduct> products { get; set; }
        public Error? Validate()
        {
            return null;
        }
    }
}
