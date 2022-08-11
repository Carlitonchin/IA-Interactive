namespace backend.Models
{

    public enum Status{
        Pending,
        InProcess,
        Completed,
        Delivered,
        Canceled
    }

    public class Order
    {
        public Order(int id, Status status)
        {
            this.Id = id;
            this.Status = status;
        }

        public int Id { get; private set; }
        public Status Status { get; set; }
    }
}
