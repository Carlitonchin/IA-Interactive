namespace backend.Errors
{
    public class Error
    {
        public string error {get; private set;}
        public Error(string msg)
        {
            this.error = msg;
        }
    }
}
