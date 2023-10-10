using YungChingHomework.DTOs.Infos;
using YungChingHomework.DTOs.ViewModels;

namespace YungChingHomework.Services
{
    public interface IProductService
    {
        public IEnumerable<ProductView> GetProducts();
        public ProductView GetProduct(long Id);
        public long CreateProduct(NewProductInfo NewProduct);
        public bool UpdateProduct(ProductInfo UpdatedProduct);
        public bool DeleteProduct(long Id);
    }
}
