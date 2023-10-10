using YungChingHomework.DBModels;

namespace YungChingHomework.DTOs.ViewModels
{
    public class ProductView
    {
        public long ProductId { get; set; }

        public string ProductName { get; set; }

        public long SupplierId { get; set; }

        public long CategoryId { get; set; }

        public string Unit { get; set; }

        public double Price { get; set; }
        public ProductView() 
        {
            ProductId = 0;
            ProductName = string.Empty;
            SupplierId = 0;
            CategoryId = 0;
            Unit = string.Empty;
            Price = 0;
        }

        public ProductView(Product product)
        {
            ProductId = product.ProductId;
            ProductName = product.ProductName ?? "";
            SupplierId = product.SupplierId ?? 0;
            CategoryId = product.CategoryId ?? 0;
            Unit = product.Unit ?? "";
            if (product.Price == null) Price = 0;
            else
            {
                string temp = "";
                foreach (byte b in product.Price)
                {
                    temp += Convert.ToChar(b);
                }
                Price = Convert.ToDouble(temp);
            }
        }
    }
}
