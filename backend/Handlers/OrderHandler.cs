using backend.Services;
using backend.Models;
using backend.Utils;
using backend.Errors;

namespace backend.Handlers
{
    public class OrderHandler : IHandler
    {
        public string urlbase {get; set;}
        private OrderService _orderServ;
        private ProductService _productServ;

        public OrderHandler(OrderService orderService, ProductService productService, WebApplication app)
        {
            this.urlbase = "/orders";
            this.endpoints(app);
            this._orderServ = orderService;
            this._productServ = productService;
        }
        public void endpoints(WebApplication app)
        {
            app.MapGet(urlbase, GetOrders);

            app.MapPost(urlbase + "/new",
            (List<CreateOrderRequest> products) => CreateOrder(products));

            app.MapPut(urlbase + "/change-status/{order_id}",
            (int? order_id) => ChangeStatus(order_id));

            app.MapPut(urlbase + "/cancel/{order_id}",
            (int? order_id) => CancelOrder(order_id));
        }

        public List<Order> GetOrders()
        {
            return this._orderServ.GetOrders();
        }

        public IResult CreateOrder(List<CreateOrderRequest> products)
        {
            ListOrderProduct orderList = new ListOrderProduct();
            foreach(var item in products)
            {
                if(Validate.EmptyOrNull(item.sku))
                    return Results.BadRequest(new Error("sku is required for every order item"));

                if(item.cant == null)
                    return Results.BadRequest(new Error("cant is required for every order item"));

                if(item.cant <= 0)
                    return Results.BadRequest(new Error("cant must be positive for every order item"));

                var product = this._productServ.FindBySKU(item.sku);
                if(product == null)
                    return Results.NotFound($"the product with sku: {item.sku} dont exist");

                if(product.Stock - item.cant < 0)
                    return Results.BadRequest(
                        new Error($"There are {product.Stock} items in stock for product: {product.Name}, and {item.cant} were ordered")
                        );

                var op = new OrderProduct(product, (int)item.cant);
                var err = orderList.Add(op);
                if(err != null)
                    return Results.BadRequest(err);
            }

            var order = this._orderServ.CreateOrder(orderList.GetOrderProducts());
            return Results.Created(urlbase, order);
        }

        public IResult ChangeStatus(int? order_id)
        {
            if(order_id == null)
                return Results.BadRequest(new Error("order_id is required"));

            var order = this._orderServ.FindOrderById((int)order_id);

            if(order == null)
                return Results.NotFound(new Error($"order_id = {order_id} does not exist"));

            if(order.Status == Status.Delivered)
                return Results.BadRequest(new Error("An delivered order only can change his status to canceled"));

            order = this._orderServ.ChangeOrderStatus(order);

            return Results.Ok(order);

        }

        public IResult CancelOrder(int? order_id)
        {
            if(order_id == null)
                return Results.BadRequest(new Error("order_id is required"));

            var order = this._orderServ.FindOrderById((int)order_id);

            if(order == null)
                return Results.NotFound(new Error($"order_id:{order_id} does not exist"));

            if(order.Status == Status.Canceled)
                return Results.BadRequest(new Error($"Order whit order_id:{order_id} was already canceled"));

            order = this._orderServ.CancelOrder(order);

            return Results.Ok(order);
        }

    }
}
