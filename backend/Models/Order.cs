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

        public int Id { get; private set; }
        public Status Status { get; private set; }
    }
}
