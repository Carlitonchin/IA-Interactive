namespace backend.Errors
{
    public class Error
    {
        public string message {get; private set;}
        public Error(string msg)
        {
            this.message = msg;
        }
    }
}
