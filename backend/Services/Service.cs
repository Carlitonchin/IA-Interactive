using backend.Repositories;

namespace backend.Services
{
    public class Service
    {
        public Service(Repository repository)
        {
            this.ProductService = new ProductService(repository.ProductRepository);
            this.OrderService = new OrderService(repository.OrderRepository);
        }
        public ProductService ProductService { get; private set; }
        public OrderService OrderService {get; private set;}
    }
}
