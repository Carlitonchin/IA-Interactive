using backend.Services;
using backend.Models;
using backend.Errors;

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
            //validation for non empty fields
            var err = product.Validate();
            if(err != null)
                return Results.BadRequest(err);

            //validation for duplicate sku
            if(this._serv.FindBySKU(product.SKU) != null)
            {
                return Results.BadRequest(new Error($"sku {product.SKU} already exists"));
            }

            this._serv.CreateProduct(product);

            return Results.Created(urlbase, product.SKU);
        }
    }
}
