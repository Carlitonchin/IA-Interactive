using backend.Services;
using backend.Models;
using backend.Errors;
using backend.Utils;

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

            app.MapPut(this.urlbase + "/update-stock",
            (UpdateStockRequest body) => ModifyStock(body));

            app.MapDelete(this.urlbase + "/delete/{sku}",
            (string? sku) => DeleteProduct(sku));
        }

        public IEnumerable<Product> GetProducts()
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
            if(this._serv.FindActiveAndDeleted(product.SKU) != null)
            {
                return Results.BadRequest(new Error($"sku {product.SKU} already exists"));
            }

            this._serv.CreateProduct(product);

            return Results.Created(urlbase, product.SKU);
        }

        public IResult ModifyStock(UpdateStockRequest body)
        {
            if(Validate.EmptyOrNull(body.sku))
                return Results.BadRequest(new Error("sku is required"));

            if(body.cant == null)
                return Results.BadRequest(new Error("cant is required"));

            var p = this._serv.FindBySKU(body.sku);

            if(p == null)
                return Results.NotFound(new Error("sku not found"));

            if(p.Stock + body.cant < 0)
                return Results.BadRequest(new Error("the stock field must be non negative"));

            this._serv.ModifyStock(p, (int)body.cant);

            return Results.NoContent();
        }

        public IResult DeleteProduct(string? sku)
        {
            if(Validate.EmptyOrNull(sku))
                return Results.BadRequest(new Error("sku is required"));

            var p = this._serv.FindBySKU(sku);

            if(p == null)
                return Results.NotFound(new Error("sku not found"));

            this._serv.DeleteProduct(p);

            return Results.Ok(p);
        }
    }
}
