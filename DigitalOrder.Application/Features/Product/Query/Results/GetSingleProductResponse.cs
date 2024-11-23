namespace DigitalOrder.Application.Features.Product.Query.Results
{
    public class GetSingleProductResponse
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDetails { get; set; }

        public string ProductType { get; set; }

        public decimal ProductPrice { get; set; }
    }
}
