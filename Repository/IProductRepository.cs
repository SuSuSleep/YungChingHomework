using YungChingHomework.DBModels;
using YungChingHomework.DTOs.Infos;

namespace YungChingHomework.Repository
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetList();
        public Product Get(long Id);
        public long Create(NewProductInfo NewOrderDetailInfo);
        public bool Update(ProductInfo OrderDetailInfo);
        public bool Delete(long Id);
    }
}
