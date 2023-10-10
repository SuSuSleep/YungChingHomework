namespace YungChingHomework.DTOs.Infos
{
    public class NewProductInfo
    {
        public string? ProductName { get; set; }

        public long? SupplierId { get; set; }

        public long? CategoryId { get; set; }

        public string? Unit { get; set; }

        public double Price { get; set; }
    }
    public class ProductInfo
    {
        public long ProductId { get; set; }
        public string? ProductName { get; set; }

        public long? SupplierId { get; set; }

        public long? CategoryId { get; set; }

        public string? Unit { get; set; }

        public double Price { get; set; }
    }
}
