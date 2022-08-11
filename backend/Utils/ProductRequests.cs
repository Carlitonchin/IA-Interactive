namespace backend.Utils
{
    // this file is for write class for binding body request
    public class UpdateStockRequest
    {
        public string? sku { get; set; }
        public int? cant { get; set; }
    }

    public class DeleteProductRequest
    {
        public string? sku { get; set; }
    }

}
