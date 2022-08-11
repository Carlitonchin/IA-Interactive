namespace backend.Models
{
    public class OrderProducts
    {
        public OrderProducts(int order_id, string product_sku, int cant)
        {
            this.OrderId = order_id;
            this.ProductSKU = product_sku;
            this.Cant = cant;
        }

        public int OrderId { get; private set; } // reference to an order
        public string ProductSKU { get; private set; } // reference to an Product SKU
        public int Cant {get; private set;} // how many items of this product there are in the order
    }
}
