namespace backend.Handlers
{
    public interface IHandler
    {
        public void endpoints(WebApplication app);
        public string urlbase {set; get;}
    }
}
