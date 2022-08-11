using backend.Errors;
namespace backend.Models
{
    public interface IValidable
    {
        public Error Validate();
    }
}
