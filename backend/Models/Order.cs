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

    public class Order : IValidable
    {
        public Order(int id, Status status)
        {
            this.Id = id;
            this.Status = status;
        }

        public int Id { get; private set; }
        public Status Status { get; set; }

        public Error Validate()
        {
            return null;
        }
    }
}
