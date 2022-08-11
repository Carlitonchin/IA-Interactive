using backend.Services;
using backend.Models;
namespace backend.Handlers
{
    internal class ProductHandler : IHandler
    {
        private ProductService _serv;
        public string urlbase {get; set;}
        public ProductHandler(ProductService service, WebApplication app)
        {
            this._serv = service;
            this.urlbase = "/products";
            this.endpoints(app);
        }
        public void endpoints(WebApplication app)
        {
            app.MapGet(this.urlbase, GetProducts);

            app.MapPost(this.urlbase + "/new", (Product p) => CreateProduct(p));
        }

        public List<Product> GetProducts()
        {
            return this._serv.GetProducts();
        }

        public IResult CreateProduct(Product product)
        {
            var p = this._serv.CreateProduct(product);
            return Results.Created(urlbase, p.SKU);
        }
    }
}
